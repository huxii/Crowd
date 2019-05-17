Shader "Custom/Thunder"
{
	Properties
	{
		[Header(Base)]
		_Color("Color Tint", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_Width("Width", Range(0, 1)) = 0
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_NoiseSpeed("Noise Speed", Float) = 0
		_NoiseStrength("Noise Strength", Range(0, 1)) = 0
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
		#pragma surface surf ToonCutout addshadow alpha:blend
		#pragma target 3.0

		uniform sampler2D _MainTex;
		uniform float4 _Color;
		uniform float _Width;
		uniform sampler2D _NoiseTex;
		uniform float _NoiseSpeed;
		uniform float _NoiseStrength;

		void surf(Input IN, inout SurfaceCustomOutput o) 
		{
			float2 uv = IN.uv_MainTex;
			float4 noise = tex2D(_NoiseTex, uv + _Time * _NoiseSpeed);
			float noiseSample = (0.5 - noise.r) * _NoiseStrength;

			clip(uv.x - (0.5 + noiseSample - _Width / 2));
			clip(0.5 + noiseSample + _Width / 2 - uv.x);

			
			//float2 motionUV = IN.uv_MainTex + _Time * _MotionSpeed;
			//half4 motion = tex2D(_MotionTex, motionUV);

			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}