// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced '_ProjectorClip' with 'unity_ProjectorClip'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Projector_multiply" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_ShadowTex("Cookie", 2D) = "" {}
	}

	Subshader
	{
		Tags 
		{ 
			"RenderMode" = "Fade" 
			"Queue" = "Transparent"
		}
		Pass 
		{
			ZWrite Off
			ColorMask RGB
			Blend One OneMinusSrcAlpha
			Offset -1, -1

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				//#pragma multi_compile_fog
				#include "UnityCG.cginc"

				struct v2f {
					float4 uvShadow : TEXCOORD0;
					//UNITY_FOG_COORDS(2)
					float4 pos : SV_POSITION;
				};

				float4x4 unity_Projector;
				float4x4 unity_ProjectorClip;

				v2f vert(float4 vertex : POSITION)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(vertex);
					o.uvShadow = mul(unity_Projector, vertex);
					//UNITY_TRANSFER_FOG(o,o.pos);
					return o;
				}

				fixed4 _Color;
				sampler2D _ShadowTex;

				fixed4 frag(v2f i) : SV_Target
				{
					float dx = i.uvShadow.x;
					float dy = i.uvShadow.y;

					if (dx > 1 || dy > 1 || dx < 0 || dy < 0)
					{
						discard;
					}

					fixed4 texS = tex2Dproj(_ShadowTex, UNITY_PROJ_COORD(half4(dx, dy, i.uvShadow.zw)));
					texS *= _Color;

					//UNITY_APPLY_FOG_COLOR(i.fogCoord, texS, fixed4(0,0,0,0));
					return texS;
				}
			ENDCG
		}
	}
}