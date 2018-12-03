// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/Sprites_cutout"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
		_MinX("Min X", Range(-20, 20)) = -20
		_MaxX("Max X", Range(-20, 20)) = 20
		_MinY("Min Y", Range(0, 20)) = 0
		_MaxY("Max Y", Range(0, 20)) = 20

        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex SpriteVert_CutOut
            #pragma fragment SpriteFrag_CutOut
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

			uniform float _MinX;
			uniform float _MinY;
			uniform float _MaxX;
			uniform float _MaxY;

			struct v2f_c
			{
				float4 vertex : SV_POSITION;				
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float4 posWorld : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			v2f_c SpriteVert_CutOut(appdata_t IN)
			{
				v2f_c OUT;

				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

				OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
				OUT.vertex = UnityObjectToClipPos(OUT.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color * _RendererColor;
				OUT.posWorld = mul(unity_ObjectToWorld, IN.vertex);

#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif

				return OUT;
			}

			fixed4 SpriteFrag_CutOut(v2f_c IN) : SV_Target
			{
				clip(IN.posWorld.x - _MinX);
				clip(_MaxX - IN.posWorld.x);
				clip(IN.posWorld.y - _MinY);
				clip(_MaxY - IN.posWorld.y);

				fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
				c.rgb *= c.a;
				return c;
			}
        ENDCG
        }
    }
}
