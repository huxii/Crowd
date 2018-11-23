Shader "Custom/Cutout_flag" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3

		_Speed("Speed", Range(0, 5.0)) = 1
		_Frequency("Frequency", Range(0, 1.3)) = 1
		_Amplitude("Amplitude", Range(0, 5.0)) = 1

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
		uniform float _AlphaCutOff;

		uniform float _Speed;
		uniform float _Frequency;
		uniform float _Amplitude;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			v.vertex.y += cos((v.vertex.x + _Time.y * _Speed) * _Frequency) * _Amplitude * (v.vertex.x - 5);
		}

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			clip(c.a - _AlphaCutOff);
		}

		ENDCG
	}

	FallBack "Diffuse"
}
