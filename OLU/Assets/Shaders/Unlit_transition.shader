// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Unlit_transition"
{
	Properties
	{
		_Progress("Progress", Range(0.0, 1.0)) = 0.0
		_MainTex("Base (RGB)", 2D) = "white" {}
		_PatternTex("Transition Pattern", 2D) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			uniform float _Progress;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform sampler2D _PatternTex;
			uniform float4 _PatternTex_ST;
			uniform fixed4 _Color;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uvWorld : TEXCOORD1;
			};

			v2f vert(appdata_img v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;

				float2 worldXY = mul(unity_ObjectToWorld, v.vertex).xy;
				// Use the worldspace coords instead of the mesh's UVs.
				o.uvWorld = TRANSFORM_TEX(worldXY, _MainTex);
				return o;
			}

			fixed4 frag(v2f i) :COLOR
			{
				float4 patternColor = tex2D(_PatternTex, TRANSFORM_TEX(i.uvWorld, _PatternTex));
				clip(patternColor.r - _Progress);
				return tex2D(_MainTex, i.uv) * _Color;
			}

		ENDCG
		}
	}

	FallBack off
}