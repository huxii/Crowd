Shader "Custom/Cutout_dynamic" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3

		_MinX("Min X", Range(-20, 20)) = -20
		_MaxX("Max X", Range(-20, 20)) = 20
		_MinY("Min Y", Range(0, 20)) = 0
		_MaxY("Max Y", Range(0, 20)) = 20
		_Offset("Offset", float) = 0

		[Header(Lighting)]
		_ShadowColor("Shadow Color", Color) = (1, 1, 1, 1)
		_BrightColor("Bright Color", Color) = (1, 1, 1, 1)
		_ShadowLineColor("Shadow Line Color", Color) = (1, 1, 1, 1)
		_ShadowLineWidth("Shadow Line Width", Range(0, 1)) = 0.01
		_DiffuseLineWidth("Diffuse Line Width", Range(0, 1)) = 0.01
		_DiffuseTransitionRange("Diffuse Transition Range", Range(0, 1)) = 0.1

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Cull Off

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
			uniform float _AlphaCutOff;

			uniform float _MinX;
			uniform float _MaxX;
			uniform float _MinY;
			uniform float _MaxY;
			uniform float _Offset;

			uniform float4 _ShadowColor;
			uniform float4 _BrightColor;
			uniform float4 _ShadowLineColor;
			uniform float _ShadowLineWidth;
			uniform float _DiffuseLineWidth;
			uniform float _DiffuseTransitionRange;

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
				o.normalDir = normalize(mul(v.normal, unity_WorldToObject).xyz);
				o.tex = v.texcoord; 
				o.tex.y += _Offset;

				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{ 				
				float4 tex = tex2D(_MainTex, i.tex.xy);
				clip(tex.a - _AlphaCutOff);
				clip(i.posWorld.x - _MinX);
				clip(_MaxX - i.posWorld.x);
				clip(i.posWorld.y - _MinY);
				clip(_MaxY - i.posWorld.y);

				float atten = LIGHT_ATTENUATION(i);
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

				if (_ShadowLineWidth != 0 && atten < 0.99 && atten > 0.01 && diffuseReflection > 0.4 && diffuseReflection < 0.9)
				{
					diffuseColor = lerp(_ShadowLineColor * _LightColor0, diffuseColor, atten - 0.8);
				}

				if (diffuseReflection > 0.5 - _DiffuseLineWidth / 128 && diffuseReflection < 0.5 + _DiffuseLineWidth / 128)
				{
					diffuseColor = _ShadowLineColor * _LightColor0;
				}

				float rim = 1.0f - saturate(dot(viewDirection, normalDirection));
				float4 rimLight = atten * _LightColor0 * _RimColor *
					saturate(dot(normalDirection, lightDirection)) *
					pow(rim, _RimPower);

				float4 lightFinal = diffuseColor * tex + UNITY_LIGHTMODEL_AMBIENT + rimLight;

				return lightFinal;
			}

			ENDCG
		}

		Pass
		{
			Name "Caster"
			Tags
			{
				"LightMode" = "ShadowCaster"
				"Queue" = "AlphaTest"
				"IgnoreProjector" = "True"
				"RenderType" = "TransparentCutout"
			}
			Offset 1, 1

			Fog {Mode Off}
			ZWrite On ZTest Less Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_shadowcaster
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float _AlphaCutOff;
			uniform float _MinY;
			uniform float _MaxY;

            struct v2f 
			{
				V2F_SHADOW_CASTER;
				float4 posWorld : TEXCOORD0;
                float2 tex : TEXCOORD1;					
            };
               
            v2f vert( appdata_base v ) 
			{
                v2f o;
                TRANSFER_SHADOW_CASTER(o)
                o.tex = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

			float4 frag(v2f i) : COLOR
			{
				float4 tex = tex2D(_MainTex, i.tex.xy);
				clip(tex.a - _AlphaCutOff);
				clip(i.posWorld.y - _MinY);
				clip(_MaxY - i.posWorld.y);
				SHADOW_CASTER_FRAGMENT(i)
			}
			
			ENDCG
		}
	}
	FallBack "Diffuse"
}
