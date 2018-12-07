Shader "Custom/Cutout"
{
	Properties
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color Tint", Color) = (1, 1, 1, 1)
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
		#pragma surface surf ToonCutout addshadow
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float4 _Color;
		uniform float _AlphaCutOff;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb * _Color.rgb;
			o.Alpha = c.a;
			clip(c.a - _AlphaCutOff);
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}