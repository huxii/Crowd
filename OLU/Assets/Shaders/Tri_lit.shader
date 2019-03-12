Shader "Custom/Tri_lit" 
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Scale("Scale", Float) = 1.0
		_Offset("Offset", Float) = 0
	}
	
	SubShader 
	{
		Tags 
		{
			"Queue"="Geometry"
			"IgnoreProjector"="False"
			"RenderType"="Opaque"
		}

		Cull Back
		ZWrite On
		
		CGPROGRAM
		#include "TriPlanarUtils.cginc"
		#pragma surface surf Lambert
		#pragma exclude_renderers flash

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _Scale;
		uniform float _Offset;
		uniform fixed4 _Color;
			
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			float4 c = GetTriPlanarColor(_MainTex, IN.worldPos, IN.worldNormal, _Scale, _Offset) * _Color;
			o.Albedo = c.rgb;
		} 
		ENDCG
	}
	Fallback "Diffuse"
}