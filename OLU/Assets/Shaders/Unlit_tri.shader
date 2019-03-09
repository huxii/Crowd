// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Lit_tri"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_ShadowColor("Shadow Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader
	{
		Tags 
		{ 
			"RenderType" = "Transparent" 
			//"Queue" = "Transparent" 
			"LightMode" = "ForwardBase"
		}
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_fwdbase
			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform fixed4 _Color;
			uniform fixed4 _ShadowColor;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uvWorld : TEXCOORD1;

				LIGHTING_COORDS(2, 3)
			};

			v2f vert(appdata_img v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;

				float2 worldXY = mul(unity_ObjectToWorld, v.vertex).xy;
				// Use the worldspace coords instead of the mesh's UVs.
				o.uvWorld = TRANSFORM_TEX(worldXY, _MainTex);

				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}

			fixed4 frag(v2f i) :COLOR
			{	
				float attenuation = LIGHT_ATTENUATION(i);
				float4 c = lerp(_ShadowColor, tex2D(_MainTex, i.uv) * _Color, attenuation);
				return c;
			}

		ENDCG
		}
	}

	Fallback "VertexLit"
}