// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/WaterColorFilter" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_WobbSpeed("Wobbing Speed", Float) = 1

		[Header(Base Color)]
		_WobbTex ("Wobbing Tex", 2D) = "grey" {}
		_WobbScale ("Wobbing Tex Scale", Float) = 1
		_WobbPower ("Wobbing Power", Float) = 1
		
		[Header(Dark Edge)]
		_EdgeSize ("Edge Size", Float) = 1
		_EdgePower ("Edge Power", Float) = 1
		_WobbTex0("Wobbing Edge Tex", 2D) = "grey" {}
		_WobbScale0("Wobbing Edge Tex Scale", Float) = 1
		_WobbPower0("Wobbing Edge Power", Float) = 1

		[Header(Paper)]
		_PaperTex ("Paper", 2D) = "grey" {}
		_PaperScale ("Paper Scale", Float) = 1
		_PaperPower ("Paper Power", Float) = 1
		[HideInInspector]_CleanMainTex("Clean Main Texture", 2D) = "white" {}
	}
	SubShader {
		Cull Off ZWrite Off ZTest Always

		CGINCLUDE			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct v2f {
				float2 uv_Main : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_TexelSize;

			float4 ColorMod(float4 c, float d) {
				return c - (c - c * c) * (d - 1);
			}

			v2f vert(appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_Main = v.uv;
				return o;
			}
		ENDCG

		// Edge Darkening
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			sampler2D _CleanMainTex;
			float _EdgeSize;

			fixed4 frag(v2f i) : SV_Target {
				float2 uv_offset = _MainTex_TexelSize.xy * _EdgeSize;
				fixed4 src_l = tex2D(_MainTex, i.uv_Main + float2(-uv_offset.x, 0));
				fixed4 src_r = tex2D(_MainTex, i.uv_Main + float2(+uv_offset.x, 0));
				fixed4 src_b = tex2D(_MainTex, i.uv_Main + float2(           0, -uv_offset.y));
				fixed4 src_t = tex2D(_MainTex, i.uv_Main + float2(           0, +uv_offset.y));
				fixed4 src = tex2D(_MainTex, i.uv_Main);
				//return  tex2D(_CleanMainTex, i.uv_Main);
				fixed4 grad = abs(src_r - src_l) + abs(src_b - src_t);
				return grad;
				
				//float intens = saturate(0.333 * (grad.x + grad.y + grad.z));
				//float d = _EdgePower * intens + 1;
				//return ColorMod(src, d);
			}
			ENDCG
		}

		// Wobbing
		Pass {
			CGPROGRAM
			#pragma vertex vert_wobb
			#pragma fragment frag

			struct v2f_wobb {
				float2 uv_Main : TEXCOORD0;
				float2 uv_Wobb : TEXCOORD1;
				float2 uv_Wobb0 : TEXCOORD2;
				float4 vertex : SV_POSITION;
			};

			float _WobbSpeed;
			sampler2D _WobbTex;
			float _WobbScale;
			float _WobbPower;
			sampler2D _WobbTex0;
			float _WobbScale0;
			float _WobbPower0;
			sampler2D _CleanMainTex;

			float _EdgePower;

			static const fixed wobbOffset = 0.01;

			v2f_wobb vert_wobb(appdata v) {
				float aspect = _ScreenParams.x / _ScreenParams.y;

				v2f_wobb o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.uv_Main = v.uv;
				o.uv_Wobb = (v.uv + step(sin(_Time * _WobbSpeed), 0) * wobbOffset) * float2(aspect, 1) * _WobbScale;
				o.uv_Wobb0 = (v.uv + step(sin(_Time * _WobbSpeed), 0) * wobbOffset) * float2(aspect, 1) * _WobbScale0;
				return o;
			}
			
			fixed4 frag(v2f_wobb i) : SV_Target {

				fixed2 wobb0 = tex2D(_WobbTex0, i.uv_Wobb0).wy * 2 - 1;
				fixed4 grad = tex2D(_MainTex, i.uv_Main + wobb0 * _WobbPower0);
				float intens = saturate(0.333 * (grad.x + grad.y + grad.z));
				float d = _EdgePower * intens + 1;

				fixed2 wobb = tex2D(_WobbTex, i.uv_Wobb).wy * 2 - 1;
				fixed4 src = tex2D(_CleanMainTex, i.uv_Main + wobb * _WobbPower);
				//return src;
				return ColorMod(src, d);
			}
			ENDCG
		}

		//// Edge Darkening
		//Pass {
		//	CGPROGRAM
		//	#pragma vertex vert
		//	#pragma fragment frag

		//	float _EdgeSize;
		//	float _EdgePower;
		//	sampler2D _CleanMainTex;

		//	fixed4 frag(v2f i) : SV_Target {
		//		float2 uv_offset = _MainTex_TexelSize.xy * _EdgeSize;
		//		fixed4 src_l = tex2D(_CleanMainTex, i.uv_Main + float2(-uv_offset.x, 0));
		//		fixed4 src_r = tex2D(_CleanMainTex, i.uv_Main + float2(+uv_offset.x, 0));
		//		fixed4 src_b = tex2D(_CleanMainTex, i.uv_Main + float2(           0, -uv_offset.y));
		//		fixed4 src_t = tex2D(_CleanMainTex, i.uv_Main + float2(           0, +uv_offset.y));
		//		fixed4 src = tex2D(_MainTex, i.uv_Main);

		//		fixed4 grad = abs(src_r - src_l) + abs(src_b - src_t);
		//		float intens = saturate(0.333 * (grad.x + grad.y + grad.z));
		//		float d = _EdgePower * intens + 1;
		//		return ColorMod(src, d);
		//	}
		//	ENDCG
		//}

		// Paper Layer
		Pass {
			CGPROGRAM
			#pragma vertex vert_paper
			#pragma fragment frag

			struct v2f_paper {
				float2 uv_Main : TEXCOORD0;
				float2 uv_Paper : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _PaperTex;
			float _PaperScale;
			float _PaperPower;

			v2f_paper vert_paper(appdata v) {
				float aspect = _ScreenParams.x / _ScreenParams.y;

				v2f_paper o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_Main = v.uv;
				o.uv_Paper = v.uv * float2(aspect, 1) * _PaperScale;
				return o;
			}
			
			fixed4 frag(v2f_paper i) : SV_Target {
				fixed4 src = tex2D(_MainTex, i.uv_Main);
				fixed paper = tex2D(_PaperTex, i.uv_Paper).x;

				float d = _PaperPower * (paper - 0.5) + 1;
				return ColorMod(src, d);
			}

			ENDCG
		}
	}
}
