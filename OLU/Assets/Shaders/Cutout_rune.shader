Shader "Custom/Cutout_rune"
{
	Properties
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3
		_Speed("Speed", Float) = 0
		_Amplitude("Amplitude", Float) = 0
	}


	SubShader
	{			
		Tags 
		{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
		}
		LOD 200
		Cull Off 
		Lighting Off

		CGPROGRAM
		#include "ToonLightingUtils.cginc"
		#include "ToonVertUtils.cginc"
		#pragma surface surf ToonCutout vertex:vert_rune addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float4 _Color;
		uniform float _AlphaCutOff;
		uniform float _Speed;
		uniform float _Amplitude;

		void vert_rune(inout appdata_full v)
		{
			v.vertex.y = v.vertex.y + sin(_Time * _Speed) * _Amplitude;
		}

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			clip(c.a - _AlphaCutOff);
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}