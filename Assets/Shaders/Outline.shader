Shader "Custom/Outline" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}

		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 1)) = 0.03 
	}

	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			Name "Base"
			//Tags {"LightMode" = "Forward"}

			CGPROGRAM
			#include "AutoLight.cginc"
			#include "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float4 _Color;
			//uniform float4 _SpecColor;

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
				//LIGHTING_COORDS(4, 5)
			};

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.normalDir = normalize(mul(float4(v.normal, 0.0f), unity_WorldToObject).xyz);
				o.tex = v.texcoord;

				//TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float4 tex = tex2D(_MainTex, i.tex.xy);

				return tex * _Color;

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

				float ramp = 0;
				//float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				//float ramp = clamp(dot(normalDirection, lightDirection), 0, 0.8);

				float4 clipPosition = UnityObjectToClipPos(position);
				float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normalDirection));

				clipPosition.xy += normalize(clipNormal.xy) * _OutlineWidth * clipPosition.w / _ScreenParams.xy * 50;

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
