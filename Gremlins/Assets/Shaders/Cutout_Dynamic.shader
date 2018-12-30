// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Cutout_dynamic" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_ReplaceTex("Replace Texture", 2D) = "white" {}
		_ReplaceFactor("Replace Factor", Range(0, 1)) = 0
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3

		_MinX("Min X", Range(-20, 20)) = -20
		_MaxX("Max X", Range(-20, 20)) = 20
		_MinY("Min Y", Range(0, 20)) = 0
		_MaxY("Max Y", Range(0, 20)) = 20
		_Offset("Offset", float) = 0

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}

	SubShader 
	{
		Tags
		{
			"Queue" = "AlphaTest"
			"RenderType" = "TransparentCutout"
		}
		LOD 200
		Cull Off
		Lighting Off

		CGPROGRAM
		#include "ToonUtils.cginc"

		#pragma surface surf ToonCutout vertex:vert addshadow
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform sampler2D _ReplaceTex;
		uniform float _ReplaceFactor;
		uniform float _AlphaCutOff;
		uniform float _MinX;
		uniform float _MinY;
		uniform float _MaxX;
		uniform float _MaxY;
		uniform float _Offset;

		struct Input
		{
			float2 uv_MainTex;
			float4 posWorld;
		};

		void vert(inout appdata_full v, out Input o) 
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		}

		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half2 uv = IN.uv_MainTex;
			uv.y += _Offset;

			half4 c0 = tex2D(_MainTex, IN.uv_MainTex);
			half4 c1 = tex2D(_ReplaceTex, IN.uv_MainTex);
			half4 c = lerp(c0, c1, _ReplaceFactor);
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			clip(c.a - _AlphaCutOff);
			clip(IN.posWorld.x - _MinX);
			clip(_MaxX - IN.posWorld.x);
			clip(IN.posWorld.y - _MinY);
			clip(_MaxY - IN.posWorld.y);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
