Shader "Testing/Cel_outlined" 
{
	Properties
	{
		_MainTex("Diffuse Texture", 2D) = "white" {}
		_ShadowColor("Shadow Color", Color) = (0.0, 0.0, 0.0, 1.0)
		_SpecColor("Specular Color", Color) = (1.0, 1.0, 1.0, 1.0)

		[KeywordEnum(Solid, Dotted)] _OutlineStyle("Outline Style", Float) = 0
		[Toggle] _ColoredOutline("Colored Outline", Float) = 0 
		_OutlineColor("Outline Color", Color) = (0.0, 0.0, 0.0, 1.0)
		_OutlineThickness("Outline Thickness", Range(0, 0.5)) = 0.2
		_DottedLineThickness("Dotted-line Thickness", Range(0, 2)) = 0.2
		_DottedLineFreq("Dotted-line Frequency", Range(0, 2)) = 0.2
	}

	SubShader
	{
		LOD 200
		Tags { "RenderType" = "Opaque" }
		Pass
		{
			Lighting On
			Tags {"LightMode" = "ForwardBase"}

			CGPROGRAM
			#include "AutoLight.cginc"
			#include "UnityCG.cginc"
			#pragma multi_compile_fwdbase

			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float4 _ShadowColor;
			uniform float4 _SpecColor;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
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
				o.normalDir = normalize( mul(float4(v.normal, 0.0f), unity_WorldToObject).xyz );	
				o.tex = v.texcoord;

				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;	
			}

			float antialias(float radius, float dist, float width)
			{
				return smoothstep(radius - width, radius + width, dist);
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
				float3 normalDirection = i.normalDir;
				float3 lightDirection;
				
				// Directional light
				if (_WorldSpaceLightPos0.w == 0.0)
				{
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				}
				// Point light
				else
				{
					float3 fragmentToLightSource = _WorldSpaceLightPos0.xyz - i.posWorld.xyz;
					lightDirection = normalize(fragmentToLightSource);
				}

				float atten = LIGHT_ATTENUATION(i);
			
				float4 lightingColor;
				float ramp = clamp(dot(normalDirection, lightDirection), 0, 1.0);
				if (ramp > 0.5)
				{
					lightingColor = _SpecColor;
				}
				else
				{
					lightingColor = _ShadowColor;
				}

				float4 tex = tex2D(_MainTex, i.tex.xy);
				float4 final = lightingColor * tex;

				return final;
				
			}

			ENDCG

			Stencil
			{
				Ref 4
				Comp always
				Pass replace
				ZFail keep
			}
		}

		Pass
		{
			Tags {"LightMode" = "ForwardBase"}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float _OutlineStyle;
			uniform bool _ColoredOutline;
			uniform float4 _OutlineColor;
			uniform float _OutlineThickness;
			uniform float _DottedLineThickness;
			uniform float _DottedLineFreq;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 texColor : TEXCOORD0;
			};

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				// scale up the whole mesh
				float4 newPos = v.vertex;
				float3 normal = normalize(v.vertex);
				newPos += float4(normal, 0.0) * _OutlineThickness;

				o.pos = UnityObjectToClipPos(newPos);
				o.texColor = tex2Dlod(_MainTex, float4(v.texcoord.xy, 0, 0));

				return o;	
			}

			float antialias(float radius, float dist, float width)
			{
				return smoothstep(radius - width, radius + width, dist);
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float4 col;
				if (_ColoredOutline)
				{
					col = i.texColor * _OutlineColor;
				}
				else
				{
					col = _OutlineColor;
				}

				if (_OutlineStyle == 0)
				{
					return col;		
				}
				else
				{
					_DottedLineThickness --;
					float skip = cos(_DottedLineFreq * i.pos.y) + _DottedLineThickness;
					clip(skip);
					return col;
				}
			}

			ENDCG

			Cull OFF
			ZWrite OFF
			ZTest ON
			Stencil
			{
				Ref 4
				Comp notequal
				Fail keep
				Pass replace
			}
		}
	}
	FallBack "Diffuse"
}
