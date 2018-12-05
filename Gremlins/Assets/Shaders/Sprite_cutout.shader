Shader "Sprites/Cutout"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_Cutoff ("Shadow alpha cutoff", Range(0,1)) = 0.5

		[Header(Lighting)]
		_MinX("Min X", Range(-20, 20)) = -20
		_MaxX("Max X", Range(-20, 20)) = 20
		_MinY("Min Y", Range(0, 20)) = 0
		_MaxY("Max Y", Range(0, 20)) = 20

		[Header(Lighting)]
		_LightRamp("Light Ramp", 2D) = "white" {}

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.1, 10.0)) = 3.0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="TransparentCutOut" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite On
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		#include "ToonUtils.cginc"
		#pragma surface surf ToonCutout alpha vertex:vert
		#pragma multi_compile DUMMY PIXELSNAP_ON

		sampler2D _MainTex;
		fixed4 _Color;
		uniform float _Cutoff;
		uniform float _MinX;
		uniform float _MinY;
		uniform float _MaxX;
		uniform float _MaxY;

		struct Input
		{
			float2 uv_MainTex;
			fixed4 color;
			float4 posWorld;
		};
		
		void vert (inout appdata_cutout v, out Input o)
		{
			#if defined(PIXELSNAP_ON) && !defined(SHADER_API_FLASH)
			v.vertex = UnityPixelSnap (v.vertex);
			#endif
			v.normal = float3(0,0,-1);
			
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.color = _Color;
			o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		}

		void surf (Input IN, inout SurfaceCustomOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;

			clip(IN.posWorld.x - _MinX);
			clip(_MaxX - IN.posWorld.x);
			clip(IN.posWorld.y - _MinY);
			clip(_MaxY - IN.posWorld.y);
			clip(IN.color.a - _Cutoff);
		}
		ENDCG
	}

Fallback "Transparent/Cutout/VertexLit"
}