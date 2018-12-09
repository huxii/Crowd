// This is a premultiply-alpha adaptation of the built-in Unity shader "UI/Default" to allow Unity UI stencil masking.

Shader "Custom/SpineSprite_outline"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}

		[Header(Overlay)]
		_OverlayFactor("Overlay Factor", Range(0, 1.0)) = 0.5
		_OverlayTex("Overlay Texture", 2D) = "white" {}
		_OverlaySpeed("Overlay Speed", float) = 1

		[Header(Outline)]
		_OutlineFactor("Outline Transparency", Range(0, 1.0)) = 0.5
		_OutlineColor("Outline Color", Color) = (1, 1, 1, 1)
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
			Name "Base"
			Tags 
			{
				"LIGHTMODE" = "Vertex"
			}

			stencil
			{
				Ref 2
				Comp Always
				Pass Replace
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#include "UnityCG.cginc"
			#include "Utils.cginc"

			// ES2.0/WebGL/3DS can not do loops with non-constant-expression iteration counts :(
			#if defined(SHADER_API_GLES)
			#define LIGHT_LOOP_LIMIT 8
			#elif defined(SHADER_API_N3DS)
			#define LIGHT_LOOP_LIMIT 4
			#else
			#define LIGHT_LOOP_LIMIT unity_VertexLightParams.x
			#endif

			#pragma multi_compile __ POINT SPOT

			half3 computeLighting(int idx, half3 dirToLight, half3 eyeNormal, half3 viewDir, half4 diffuseColor, half atten) {
				half NdotL = max(dot(eyeNormal, dirToLight), 0.0);
				// diffuse
				half3 color = NdotL * diffuseColor.rgb * unity_LightColor[idx].rgb;
				return color * atten;
			}

			half3 computeOneLight(int idx, float3 eyePosition, half3 eyeNormal, half3 viewDir, half4 diffuseColor) {
				float3 dirToLight = unity_LightPosition[idx].xyz;
				half att = 1.0;

				#if defined(POINT) || defined(SPOT)
				dirToLight -= eyePosition * unity_LightPosition[idx].w;

				// distance attenuation
				float distSqr = dot(dirToLight, dirToLight);
				att /= (1.0 + unity_LightAtten[idx].z * distSqr);
				if (unity_LightPosition[idx].w != 0 && distSqr > unity_LightAtten[idx].w) att = 0.0; // set to 0 if outside of range
				distSqr = max(distSqr, 0.000001); // don't produce NaNs if some vertex position overlaps with the light
				dirToLight *= rsqrt(distSqr);
				#if defined(SPOT)

				// spot angle attenuation
				half rho = max(dot(dirToLight, unity_SpotDirection[idx].xyz), 0.0);
				half spotAtt = (rho - unity_LightAtten[idx].x) * unity_LightAtten[idx].y;
				att *= saturate(spotAtt);
				#endif
				#endif

				att *= 0.5; // passed in light colors are 2x brighter than what used to be in FFP
				return min(computeLighting(idx, dirToLight, eyeNormal, viewDir, diffuseColor, att), 1.0);
			}

			int4 unity_VertexLightParams; // x: light count, y: zero, z: one (y/z needed by d3d9 vs loop instruction)		

			struct appdata {
				float3 pos : POSITION;
				float3 normal : NORMAL;
				half4 color : COLOR;
				float3 uv0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput {
				fixed4 color : COLOR0;
				float2 uv0 : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
				float4 pos : SV_POSITION;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			sampler2D _MainTex;
			uniform float _OverlayFactor;
			uniform sampler2D _OverlayTex;
			uniform float4 _OverlayTex_ST;
			uniform float _OverlaySpeed;

			VertexOutput vert(appdata v) 
			{
				VertexOutput o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				half4 color = v.color;
				float3 eyePos = UnityObjectToViewPos(float4(v.pos, 1)).xyz; //mul(UNITY_MATRIX_MV, float4(v.pos,1)).xyz;
				half3 fixedNormal = half3(0,0,-1);
				half3 eyeNormal = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, fixedNormal));
				//half3 eyeNormal = half3(0,0,1);
				half3 viewDir = 0.0;

				// Lights
				half3 lcolor = half4(0,0,0,1).rgb + color.rgb * glstate_lightmodel_ambient.rgb;
				for (int il = 0; il < LIGHT_LOOP_LIMIT; ++il) {
					lcolor += computeOneLight(il, eyePos, eyeNormal, viewDir, color);
				}

				color.rgb = lcolor.rgb;
				o.color = saturate(color);
				o.uv0 = v.uv0;
				o.pos = UnityObjectToClipPos(v.pos);
				o.screenPos = ComputeScreenPos(o.pos);
				return o;
			}

			fixed4 frag(VertexOutput i) : SV_Target 
			{
				fixed4 tex = tex2D(_MainTex, i.uv0);

				fixed4 col;
				col.rgb = tex * i.color;
				col *= 2;
				col.a = tex.a * i.color.a;

				clip(col.a - 0.9f);

				// overlay
				float2 screenUVs = (i.screenPos.xy / i.screenPos.w);
				screenUVs += _OverlaySpeed * _Time;
				half4 overlayTex = tex2D(_OverlayTex, TRANSFORM_TEX(screenUVs.xy, _OverlayTex));
				col = GetOverlayColor(col, float4(1, 1, 1, 1), overlayTex.a * _OverlayFactor);

				return col;
			}
			ENDCG

		}

		Pass
		{
			Name "Outline"

			stencil
			{
				Ref 2
				Comp NotEqual
				Pass Replace
			}

		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile __ UNITY_UI_ALPHACLIP

			struct VertexInput {
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput {
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD3;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform float _OutlineFactor;
			uniform fixed4 _OutlineColor;

			VertexOutput vert (VertexInput IN) 
			{
				VertexOutput OUT;

				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

				OUT.worldPosition = IN.vertex;
				OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
				OUT.texcoord = IN.texcoord;

				OUT.color = IN.color * float4(_OutlineColor.rgb * _OutlineFactor, _OutlineFactor); // Combine a PMA version of _Color with vertexColor.
				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag (VertexOutput IN) : SV_Target
			{
				return IN.color;
			}
		ENDCG
		}
	}
}
