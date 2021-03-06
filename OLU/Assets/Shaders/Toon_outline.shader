﻿Shader "Custom/Toon_outline" 
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

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_SpecMap("Specular Map", 2D) = "black" {}

		_AOMap("AO Map", 2D) = "white" {}
		_AOMinColor("AO Min Color", Color) = (1, 1, 1, 1)
		_AOMaxColor("AO Max Color", Color) = (1, 1, 1, 1)

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0

		_EmissionIntensity("Emission Intensity", Range(0, 1.0)) = 0.5
		_EmissionMap("Emission", 2D) = "black" {}
		[HDR]_EmissionColor("Emission Color", Color) = (0, 0, 0, 1)

		[Header(Outline)]
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 1.0)) = 0.05

		[Header(Overlay)]
		_OverlayFactor("Overlay Factor", Range(0, 1.0)) = 0
		_OverlayTex("Overlay Texture", 2D) = "white" {}
		_OverlaySpeed("Overlay Speed", float) = 1
	}

	SubShader
	{
		Name "Base"
		Tags
		{
			//"LightMode" = "ForwardBase"
			"RenderType" = "Opaque"
			"IgnoreProjector" = "True"
		}
		LOD 200
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB

		CGPROGRAM
		#include "ToonLightingUtils.cginc"

		#pragma surface surf Toon vertex:vert addshadow
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform sampler2D _ReplaceTex;
		uniform float _ReplaceFactor;
		uniform float4 _Color;
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

		uniform float _OverlayFactor;
		uniform sampler2D _OverlayTex;
		uniform float4 _OverlayTex_ST;
		uniform float _OverlaySpeed;

		struct Input
		{
			float2 uv_MainTex;
			float4 screenPos : TEXCOORD0;
		};

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.screenPos = ComputeScreenPos(UnityObjectToClipPos(v.vertex));
		}

		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half4 c0 = tex2D(_MainTex, IN.uv_MainTex);
			half4 c1 = tex2D(_ReplaceTex, IN.uv_MainTex);
			half4 p = pow(tex2D(_Pattern, TRANSFORM_TEX(IN.uv_MainTex, _Pattern)), _PatternPower);
			half4 c = lerp(c0, c1, _ReplaceFactor) * p * _Color;

			float ce = tex2D(_EmissionMap, IN.uv_MainTex).r * _EmissionIntensity;
			o.Albedo = lerp(c.rgb, _EmissionColor.rgb, ce);
			o.Alpha = c.a;

			// overlay
			float2 screenUVs = (IN.screenPos.xy / IN.screenPos.w);
			screenUVs += _OverlaySpeed * _Time;
			half4 overlayTex = tex2D(_OverlayTex, TRANSFORM_TEX(screenUVs.xy, _OverlayTex));
			o.Albedo = GetOverlayColor(half4(o.Albedo, 1), float4(1, 1, 1, 1), overlayTex.a * _OverlayFactor).rgb;

			half4 ao = tex2D(_AOMap, IN.uv_MainTex);
			half4 aoColor = lerp(_AOMinColor, _AOMaxColor, ao);
			o.Ao = aoColor.rgb;

			half4 specGloss = tex2D(_SpecMap, IN.uv_MainTex);
			o.Specular = specGloss.r;
			o.Gloss = specGloss.a;
		}
		ENDCG
		
		Pass
		{
			Name "Outline"
			Tags
			{				
				"RenderType" = "Transparent"
			}
			Blend SrcAlpha OneMinusSrcAlpha

			Cull Front

			CGPROGRAM
			#include "Utils.cginc"

			#pragma vertex vert_outline
			#pragma fragment frag_outline

			uniform float _OutlineWidth;
			uniform float4 _OutlineColor;

			float4 vert_outline(appdata_color v) : SV_POSITION
			{
				return GetClipPosition(v.vertex, normalize(v.color.xyz), _OutlineWidth);
			}

			float4 frag_outline() : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
