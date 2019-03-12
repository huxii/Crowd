// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Unlit_transition"
{
	Properties
	{
		_Alpha("Alpha", Range(0.0, 1.0)) = 0.0
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

			uniform float _Alpha;
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
				clip(_Progress - patternColor.r);
	
				float4 c = tex2D(_MainTex, i.uv) * _Color;
				c.a = _Alpha;
				return c;
			}

		ENDCG
		}
	}

	FallBack off
}


//// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
//
//// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
//
//Shader "Custom/Unlit_transition"
//{
//	Properties
//	{
//		_Alpha("Alpha", Range(0.0, 1.0)) = 0.0
//		_Progress("Progress", Range(0.0, 1.0)) = 0.0
//		_MainTex("Base (RGB)", 2D) = "white" {}
//		_PatternTex("Transition Pattern", 2D) = "white" {}
//		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
//		_Scale("Scale", Float) = 1.0
//		_Offset("Offset", Float) = 0
//	}
//
//	SubShader
//	{
//		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
//		Blend SrcAlpha OneMinusSrcAlpha
//		Lighting Off
//
//			CGPROGRAM
//			#include "TriPlanarUtils.cginc"
//			#pragma surface surf Unlit alpha:blend
//			#pragma exclude_renderers flash
//
//			uniform float _Alpha;
//			uniform float _Progress;
//			uniform sampler2D _MainTex;
//			uniform sampler2D _PatternTex;
//			uniform float4 _PatternTex_ST;
//			uniform fixed4 _Color;
//
//			void surf(Input IN, inout SurfaceOutput o)
//			{
//				float4 ct = GetTriPlanarColor(_PatternTex, IN.worldPos, IN.worldNormal, _Scale, _Offset);
//				float4 cb = tex2D(_MainTex, IN.uv_MainTex);
//				o.Albedo = cb * _Color.rgb;
//				o.Alpha = _Alpha;
//				clip(_Progress - ct.r - 0.01);
//			}
//
//			fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
//			{
//				fixed4 c;
//				c.rgb = s.Albedo;
//				c.a = s.Alpha;
//				return c;
//			}
//	ENDCG
//	}
//
//	FallBack off
//}