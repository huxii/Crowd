Shader "Custom/Toon" 
{
	Properties 
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_ReplaceTex("Replace Texture", 2D) = "white" {}
		_ReplaceFactor("Replace Factor", Range(0, 1)) = 0
		_Pattern("Pattern", 2D) = "white" {}
		_PatternPower("Pattern Power", Float) = 1.0

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
		[MaterialToggle]_MirrorLightDirection("Mirror Light Direction", Float) = 0
		_LightRamp("Light Ramp", 2D) = "white" {}
		_SpecMap("Specular Map", 2D) = "black" {}
		_AOMap("AO Map", 2D) = "white" {}
		_AOMinColor("AO Min Color", Color) = (1, 1, 1, 1)
		_AOMaxColor("AO Max Color", Color) = (1, 1, 1, 1)

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0

		_EmissionIntensity("Emission Intensity", Range(0, 1.0)) = 0
		_EmissionMap("Emission", 2D) = "black" {}
		[HDR]_EmissionColor("Emission Color", Color) = (0, 0, 0, 1)
	}

	SubShader
	{
		Name "Base"
		Tags
		{
			//"LightMode" = "ForwardBase"
			"RenderType" = "Opaque"
		}

		CGPROGRAM
		#include "ToonLightingUtils.cginc"
		#include "ToonVertUtils.cginc"

		#pragma surface surf Toon vertex:vert addshadow
		#pragma target 3.0

		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform sampler2D _ReplaceTex;
		uniform float _ReplaceFactor;
		uniform sampler2D _Pattern;
		uniform float4 _Pattern_ST;
		uniform float _PatternPower;
		uniform sampler2D _SpecMap;
		uniform float _EmissionIntensity;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionColor;

		uniform sampler2D _AOMap;
		uniform float4 _AOMap_ST;
		uniform float4 _AOMinColor;
		uniform float4 _AOMaxColor;

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
			half4 p = pow(tex2D(_Pattern, TRANSFORM_TEX(IN.uv_MainTex, _Pattern)), _PatternPower);
			half4 c = lerp(c0, c1, _ReplaceFactor) * p * _Color;

			float gradientX = max(0.0, min(1.0, (IN.posWorld.x - _XGradientMin) / (_XGradientMax - _XGradientMin)));
			float gradientY = max(0.0, min(1.0, (IN.posWorld.y - _YGradientMin) / (_YGradientMax - _YGradientMin)));
			half4 gradientColor = lerp(_XNegativeColor, _XPositiveColor, gradientX) * lerp(_YNegativeColor, _YPositiveColor, gradientY);

			float ce = tex2D(_EmissionMap, IN.uv_MainTex).r * _EmissionIntensity;
			o.Albedo = lerp(c.rgb, _EmissionColor.rgb, ce) * gradientColor.rgb;
			o.Alpha = c.a;

			half4 ao = tex2D(_AOMap, IN.uv_MainTex);
			half4 aoColor = lerp(_AOMinColor, _AOMaxColor, ao);
			o.Ao = aoColor.rgb;

			half4 specGloss = tex2D(_SpecMap, IN.uv_MainTex);
			o.Specular = specGloss.r;
			o.Gloss = specGloss.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
