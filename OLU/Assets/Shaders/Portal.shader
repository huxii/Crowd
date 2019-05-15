Shader "Custom/Portal"
{
	Properties
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_MotionTex("Motion Texture", 2D) = "white" {}
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_AlphaCutOff("Alpha Cut Off", Range(0, 1)) = 0.3
		_Speed("Speed", Float) = 0
		_Deform("Deform", Range(0, 1)) = 0
		_Swirl("Swirlness", Range(0.01, 1)) = 0.01
		_Rotation("Rotation", Range(0, 1)) = 0
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
		#pragma surface surf ToonCutout vertex:vert_portal addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform sampler2D _MotionTex;
		uniform sampler2D _NoiseTex;
		uniform float4 _Color;
		uniform float _AlphaCutOff;
		uniform float _Speed;
		uniform float _Deform;
		uniform float _Swirl;
		uniform float _Rotation;

		void vert_portal(inout appdata_full v)
		{
			fixed4 motion = tex2Dlod(_MotionTex, float4(v.texcoord.xy, 0, 0));
			v.vertex.xyz += v.normal * _Deform * (1 - motion.r);
		}

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			float pi = 3.1415926;
			float2 uv = IN.uv_MainTex;
			float2 pivot = float2(0.5, 0.5);

			float2 p = uv - pivot;
			fixed4 motion = tex2D(_MotionTex, uv);
			p = rotate(motion.r * _Time * _Rotation, p);

			float a = atan2(p.y, p.x) + pi;
			float r = sqrt(dot(p, p));
			float2 uvPolar = float2(r, a / pi / 2);
			uvPolar.x = (_Time * _Speed) - 1 / r * _Swirl;

			fixed4 noise = tex2D(_NoiseTex, uvPolar);

			half4 c = tex2D(_MainTex, float2(noise.r, 0)) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			clip(c.a - _AlphaCutOff);
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}