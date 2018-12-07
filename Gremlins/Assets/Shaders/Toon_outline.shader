Shader "Custom/Toon_outline" 
{
	Properties 
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_Pattern("Pattern", 2D) = "white" {}
		_PatternPower("Pattern Power", Float) = 1.0
		_XPositiveColor("X+ Color", Color) = (1, 1, 1, 1)
		_XNegativeColor("X- Color", Color) = (1, 1, 1, 1)
		_YPositiveColor("Y+ Color", Color) = (1, 1, 1, 1)
		_YNegativeColor("Y- Color", Color) = (1, 1, 1, 1)

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_SpecMap("Specular Map", 2D) = "black" {}

		_AOMap("AO Map", 2D) = "white" {}
		_AOMinColor("AO Min Color", Color) = (1, 1, 1, 1)
		_AOMaxColor("AO Max Color", Color) = (1, 1, 1, 1)

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0

		_EmissionMap("Emission", 2D) = "white" {}
		[HDR]_EmissionColor("Emission Color", Color) = (0, 0, 0, 1)

		[Header(Outline)]
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 1.0)) = 0.05
	}

	SubShader
	{
		CGPROGRAM
		#include "ToonUtils.cginc"

		#pragma surface surf Toon addshadow
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float4 _Color;
		uniform sampler2D _Pattern;
		uniform float4 _Pattern_ST;
		uniform float _PatternPower;
		uniform sampler2D _SpecMap;

		uniform sampler2D _AOMap;
		uniform float4 _AOMap_ST;
		uniform float4 _AOMinColor;
		uniform float4 _AOMaxColor;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			half4 p = pow(tex2D(_Pattern, TRANSFORM_TEX(IN.uv_MainTex, _Pattern)), _PatternPower);
			o.Albedo = c.rgb * p.rgb * _Color.rgb;
			o.Alpha = c.a;

			half4 ao = tex2D(_AOMap, IN.uv_MainTex);
			half4 aoColor = lerp(_AOMinColor, _AOMaxColor, ao);
			o.Ao = aoColor.rgb;

			o.Emission = tex2D(_EmissionMap, IN.uv_MainTex).rgb * _EmissionColor.rgb;

			half4 specGloss = tex2D(_SpecMap, IN.uv_MainTex);
			o.Specular = specGloss.r;
			o.Gloss = specGloss.a;
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
		
		Pass
		{
			Name "Outline"

			Cull Front

			CGPROGRAM
			#include "OutlineUtils.cginc"

			#pragma vertex vert
			#pragma fragment frag

			uniform float _OutlineWidth;
			uniform float4 _OutlineColor;

			float4 vert(vertexInput v) : SV_POSITION
			{
				return GetClipPosition(v.vertex, normalize(v.color.xyz), _OutlineWidth);
			}

			float4 frag() : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
