﻿Shader "Custom/Cutout" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3

		_XPositiveColor("X+ Color", Color) = (1, 1, 1, 1)
		_XNegativeColor("X- Color", Color) = (1, 1, 1, 1)
		_YPositiveColor("Y+ Color", Color) = (1, 1, 1, 1)
		_YNegativeColor("Y- Color", Color) = (1, 1, 1, 1)

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}

	SubShader 
	{
		Cull Off

		CGPROGRAM
		#include "ToonUtils.cginc"

		#pragma surface surf ToonCutout addshadow
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float _AlphaCutOff;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			clip(c.a - _AlphaCutOff);
		}
		ENDCG

		Pass
		{
			Name "Base"
			Tags
			{
				"LightMode" = "ForwardBase"
				"Queue" = "Opaque"
				"RenderType" = "Opaque"
				"IgnoreProjector" = "True"
			}
			LOD 200
			ZWrite On
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
		}
	}
	FallBack "Diffuse"
}
