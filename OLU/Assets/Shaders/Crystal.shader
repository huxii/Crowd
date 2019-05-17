Shader "Custom/Crystal"
{
	Properties
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_Speed("Speed", Float) = 0
		_Amplitude("Amplitude", Float) = 0
		_Offset("Offset", Float) = 0
		_MotionTex("Motion Texture", 2D) = "white" {}
		_MotionSpeed("Motion Speed", Float) = 0
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
		#pragma surface surf ToonCutout vertex:vert_crystal addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float4 _Color;
		uniform float _Speed;
		uniform float _Amplitude;
		uniform float _Offset;
		uniform sampler2D _MotionTex;
		uniform float _MotionSpeed;

		void vert_crystal(inout appdata_full v)
		{
			v.vertex.y += sin(_Time * _Speed) * _Amplitude + _Offset;
		}

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			float2 motionUV = IN.uv_MainTex + _Time * _MotionSpeed;
			half4 motion = tex2D(_MotionTex, motionUV);

			half4 c = motion * tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}