Shader "Custom/Cutout"
{
	Properties
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_ReplaceTex("Replace Texture", 2D) = "white" {}
		_ReplaceFactor("Replace Factor", Range(0, 1)) = 0
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3

		[Header(Gradient)]
		_XGradientMax("Max Gradient X", Float) = 20
		_XGradientMin("Min Gradient X", Float) = -20
		_YGradientMax("Max Gradient Y", Float) = 20
		_YGradientMin("Min Gradient Y", Float) = -20
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
		#include "ToonLightingUtils.cginc"
		#include "ToonVertUtils.cginc"
		#pragma surface surf ToonCutout vertex:vert addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform sampler2D _ReplaceTex;
		uniform float _ReplaceFactor;
		uniform float4 _Color;
		uniform float _AlphaCutOff;

		uniform float _XGradientMax;
		uniform float _XGradientMin;
		uniform float _YGradientMax;
		uniform float _YGradientMin;
		uniform float4 _XPositiveColor;
		uniform float4 _XNegativeColor;
		uniform float4 _YPositiveColor;
		uniform float4 _YNegativeColor;

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			half4 c0 = tex2D(_MainTex, IN.uv_MainTex);
			half4 c1 = tex2D(_ReplaceTex, IN.uv_MainTex);
			half4 c = lerp(c0, c1, _ReplaceFactor) * _Color;

			float gradientX = max(0.0, min(1.0, (IN.posWorld.x - _XGradientMin) / (_XGradientMax - _XGradientMin)));
			float gradientY = max(0.0, min(1.0, (IN.posWorld.y - _YGradientMin) / (_YGradientMax - _YGradientMin)));
			half4 gradientColor = lerp(_XNegativeColor, _XPositiveColor, gradientX) * lerp(_YNegativeColor, _YPositiveColor, gradientY);

			o.Albedo = c.rgb * gradientColor.rgb;
			o.Alpha = c.a;

			clip(c.a - _AlphaCutOff);
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}