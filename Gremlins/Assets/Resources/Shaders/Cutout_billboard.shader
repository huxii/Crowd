Shader "Custom/Cutout_billboard"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Base Color", Color) = (1, 1, 1, 1)
		_ReplaceColor("Replace Color", Color) = (1, 1, 1, 1)
		_ReplaceFactor("Replace Factor", Range(0, 1)) = 0
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_ScaleX("Scale X", Float) = 1.0
		_ScaleY("Scale Y", Float) = 1.0

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
			"DisableBatching" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#include "ToonUtils.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON

			uniform sampler2D _MainTex;
			uniform fixed4 _Color;
			uniform fixed4 _ReplaceColor;
			uniform float _ReplaceFactor;
			uniform float _Cutoff;
			uniform float _ScaleX;
			uniform float _ScaleY;

			uniform float _MinX;
			uniform float _MinY;
			uniform float _MaxX;
			uniform float _MaxY;

			appdata_color vert(appdata_color IN)
			{
				appdata_color OUT;

				#if defined(PIXELSNAP_ON) && !defined(SHADER_API_FLASH)
				OUT.vertex = UnityPixelSnap(IN.vertex);
				#endif
				OUT.normal = float3(0, 0, -1);

				float4 model = mul(UNITY_MATRIX_M, float4(0, IN.vertex.y * _ScaleY, 0.0, 1.0));
				float4 view = mul(UNITY_MATRIX_V, model);
				float4 proj = mul(UNITY_MATRIX_P, view
					+ float4(IN.vertex.x, 0.0, 0.0, 0.0)
					* float4(_ScaleX, 1.0, 1.0, 1.0));
				OUT.vertex = proj;
				OUT.color = _Color;
				OUT.posWorld = mul(unity_ObjectToWorld, IN.vertex);
				OUT.texcoord = IN.texcoord;

				return OUT;
			}

			fixed4 frag(appdata_color IN) : COLOR
			{			
				clip(IN.posWorld.x - _MinX);
				clip(_MaxX - IN.posWorld.x);
				clip(IN.posWorld.y - _MinY);
				clip(_MaxY - IN.posWorld.y);
				clip(IN.color.a - _Cutoff);

				fixed4 albedo = tex2D(_MainTex, IN.texcoord) * IN.color * lerp(_Color, _ReplaceColor, _ReplaceFactor);
				//return albedo;

				float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - IN.posWorld.xyz);
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				float atten = LIGHT_ATTENUATION(IN);

				half4 shadowColor = CaculateShadow(albedo, IN.normal, lightDir, atten);

				// final
				half4 c;
				c.rgb = albedo.rgb * shadowColor.rgb + UNITY_LIGHTMODEL_AMBIENT.rgb;
				c.a = albedo.a;
				return c;
			}

			ENDCG
		}
	}

	Fallback "Transparent/Cutout/VertexLit"
}