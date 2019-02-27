// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Unlit_loading"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Alpha("Alpha", Range(0.0, 1.0)) = 1.0
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Speed("Speed", float) = 1
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform fixed4 _Color;
			uniform float _Speed;
			uniform float _Alpha;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata_img v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = float2(v.texcoord.x + _Speed * _Time.x, v.texcoord.y);

				return o;
			}

			fixed4 frag(v2f i) :COLOR
			{
				float4 c = tex2D(_MainTex, TRANSFORM_TEX(i.uv, _MainTex)) * _Color;
				c.a = _Alpha * c.a;
				return c;
			}

		ENDCG
		}
	}

	FallBack off
}