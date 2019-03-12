Shader "Custom/Tri_cutout" 
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Scale("Scale", Float) = 1.0
		_Offset("Offset", Float) = 0
		_AlphaCutout("Alpha Cutout", Range(0.0, 1.0)) = 1.0
	}
	
	SubShader 
	{
		Tags 
		{
			//"Queue" = "Geometry"
			"IgnoreProjector" = "False"
			"RenderType" = "Transparent"
		}
		Blend SrcAlpha OneMinusSrcAlpha

		Cull Back
		ZWrite On
		
		CGPROGRAM
		#include "TriPlanarUtils.cginc"
		#pragma surface surf Unlit
		#pragma exclude_renderers flash

		uniform fixed4 _Color;
		uniform sampler2D _MainTex;
		uniform float _Scale;
		uniform float _Offset;
		uniform float _AlphaCutout;
		
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			float4 color: Color;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			float4 c = GetTriPlanarColor(_MainTex, IN.worldPos, IN.worldNormal, _Scale, _Offset) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a * IN.color.a;
			clip(o.Alpha - _AlphaCutout);
		} 

		fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}
		ENDCG
	}
	Fallback "Diffuse"
}