Shader "Custom/Outline" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_XPositiveColor("X+ Color", Color) = (1, 1, 1, 1)
		_XNegativeColor("X- Color", Color) = (1, 1, 1, 1)
		_YPositiveColor("Y+ Color", Color) = (1, 1, 1, 1)
		_YNegativeColor("Y- Color", Color) = (1, 1, 1, 1)

		[Header(Lighting)]
		_ShadowColor("Shadow Color", Color) = (1, 1, 1, 1)
		_BrightColor("Bright Color", Color) = (1, 1, 1, 1)
		_ShadowLineWidth("Shadow Line Width", Range(0, 1)) = 0.01
		_ShadowLineColor("Shadow Line Color", Color) = (1, 1, 1, 1)
		_DiffuseTransitionRange("Diffuse Transition Range", Range(0, 1)) = 0.1

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0

		[Header(Outline)]
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 1.0)) = 0.05
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			Name "Base"
			Tags {"LightMode" = "ForwardBase"}

			CGPROGRAM
			#include "AutoLight.cginc"
			#include "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash
			#pragma multi_compile_fwdbase

			uniform float4 _LightColor0;

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			uniform float4 _ShadowColor;
			uniform float4 _BrightColor;
			uniform float _ShadowLineWidth;
			uniform float4 _ShadowLineColor;
			uniform float _DiffuseTransitionRange;

			uniform float4 _XPositiveColor;
			uniform float4 _XNegativeColor;
			uniform float4 _YPositiveColor;
			uniform float4 _YNegativeColor;

			uniform float4 _RimColor;
			uniform float _RimPower;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				float4 color : COLOR;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 tex : TEXCOORD0;
				float4 posWorld : TEXCOORD1;
				float3 normalDir : TEXCOORD2;
				LIGHTING_COORDS(4, 5)
			};

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.normalDir = mul(v.normal, unity_WorldToObject).xyz;
				o.tex = v.texcoord;

				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float atten = LIGHT_ATTENUATION(i);
				float4 tex = tex2D(_MainTex, i.tex.xy);

				float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld);
				float3 normalDirection = i.normalDir;
				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				float diffuseReflection = atten * min(1.0, max(0.0, dot(normalDirection, lightDirection)));
				float4 diffuseColor;
				if (diffuseReflection <= 0.5 - _DiffuseTransitionRange / 2)
				{
					diffuseColor = _ShadowColor * _LightColor0;
				}
				else
				if (diffuseReflection >= 0.5 + _DiffuseTransitionRange / 2)
				{
					diffuseColor = _BrightColor * _LightColor0;
				}
				else
				{
					//return float4(0, 0, 0, 1);
					diffuseColor = lerp(_ShadowColor, _BrightColor, (diffuseReflection - 0.5 + _DiffuseTransitionRange / 2) / _DiffuseTransitionRange) * _LightColor0;
				}

				if (atten < 0.99 && atten > 0.01 && diffuseReflection > 0.49 && diffuseReflection < 0.95)
				{
					diffuseColor = lerp(_ShadowLineColor * _LightColor0, diffuseColor, atten - 0.8);
				}

				if (diffuseReflection > 0.5 - _ShadowLineWidth / 128 && diffuseReflection < 0.5 + _ShadowLineWidth / 128)
				{
					diffuseColor = _ShadowLineColor * _LightColor0;
				}

				float rim = 1.0f - saturate(dot(viewDirection, normalDirection));
				float4 rimLight = atten * _LightColor0 * _RimColor *
					saturate(dot(normalDirection, lightDirection)) *
					pow(rim, _RimPower);

				float4 yColor = lerp(_YNegativeColor * tex, _YPositiveColor * tex, i.tex.y);

				float4 lightFinal = diffuseColor * yColor + UNITY_LIGHTMODEL_AMBIENT + rimLight;

				return lightFinal;

			}

			ENDCG
		}

		Pass
		{
			Name "Outline"

			Cull Front

			CGPROGRAM
			#include "AutoLight.cginc"
			#include "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			uniform float _OutlineWidth;
			uniform float4 _OutlineColor;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				float4 color : COLOR;
			};

			float4 vert(vertexInput v) : SV_POSITION
			{
				float3 normalDirection = v.color.xyz;
				float4 position = v.vertex;

				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				float ramp = clamp(dot(normalDirection, lightDirection), 0, 1.0) * 0.8;
				  
				float4 clipPosition = UnityObjectToClipPos(position);
				float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normalDirection));

				clipPosition.xy += normalize(clipNormal.xy) * _OutlineWidth * clipPosition.w / _ScreenParams.xy * 50 * (1 - ramp);

				return clipPosition;
			}

			float4 frag() : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}

	}
	FallBack "Diffuse"
}
