Shader "Custom/Toon_transparent" 
{
	Properties 
	{
		[Header(Base)]
		_MainTex("Texture", 2D) = "white" {}
		_XPositiveColor("X+ Color", Color) = (1, 1, 1, 1)
		_XNegativeColor("X- Color", Color) = (1, 1, 1, 1)
		_YPositiveColor("Y+ Color", Color) = (1, 1, 1, 1)
		_YNegativeColor("Y- Color", Color) = (1, 1, 1, 1)

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_SpecMap("Specular Map", 2D) = "black" {}

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}

	SubShader
	{
		Name "Base"
		Tags
		{
			//"LightMode" = "ForwardBase"
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"IgnoreProjector" = "True"
		}
		LOD 200
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB

		CGPROGRAM
		#include "ToonUtils.cginc"

		#pragma surface surf Toon addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform sampler2D _SpecMap;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			float3 specGloss = tex2D(_SpecMap, IN.uv_MainTex).rgb;
			o.Specular = specGloss.r;
			o.Gloss = specGloss.g;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
