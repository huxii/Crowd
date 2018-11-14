Shader "Custom/Water" 
{

	// TODO : ramp of wave   REFLECTION RIPPLE SPLASH SHADOW   
	Properties
	{
		[Header(Water Base)]
		_Color("Base Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex("Main Texture", 2D) = "white" {}
		_NormalTex("Normal Texture", 2D) = "white" {}
		_LightIntensity("Light Intensity", Range(0, 1)) = 0
		_SpecColor("Specular Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Shininess("Shininess", Float) = 10

		[Header(Wave)]
		_WaveColor("Wave Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_WaveSpeed("Wave Speed", float) = 1.0
		_WaveAmp("Wave Amplify", float) = 1.0
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_WaveRampTex("Wave Ramp Texture", 2D) = "white" {}

		[Header(Flow)]
		_FlowSpeed("Flow Speed", float) = 1.0
		_FlowDegree("Flow Degree", Range(0, 90)) = 0.0
		_FlowColor("Flow Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_FlowTex("Flow Texture", 2D) = "white" {}

		[Header(Depth)]
		_DepthFactor("Depth Factor", float) = 1.0
		_DepthTransparency("Depth Transparency", Range(0, 1)) = 1.0
		_DepthColor("Depth Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_DepthRampTex("Depth Ramp Texture", 2D) = "white" {}

		[Header(Foam)]
		_FoamFactor("Foam Factor", float) = 1.0
		_FoamDegree("Foam Degree", Range(0, 180)) = 0.0
		_FoamColor("Foam Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_FoamTex("Foam Texture", 2D) = "white" {}

		[Header(Distortion)]
		_DistortStrength("Distort Strength", float) = 1.0
		_BumpTex("Bump Texture", 2D) = "white" {}
	}

	SubShader
	{			
		//// for distortion
		//GrabPass
		//{
		//	"_BackgroundTexture"
		//}		
		//// distortion
		//Pass
		//{
		//	CGPROGRAM
		//	#include "AutoLight.cginc"
		//	#include "UnityCG.cginc"
		//	
		//	#pragma vertex vert
		//	#pragma fragment frag
		//	#pragma exclude_renderers flash
		//	#pragma multi_compile_fwdbase

		//	sampler2D _BackgroundTexture;

		//	uniform float _WaveSpeed;
		//	uniform float _WaveAmp;
		//	uniform sampler2D _BumpTex;
		//	uniform float _DistortStrength;
		//	uniform sampler2D _NoiseTex;

		//	struct vertexInput
		//	{
		//		float4 vertex : POSITION;
		//		float3 normal : NORMAL;
		//		float4 texcoord : TEXCOORD1;
		//	};

		//	struct vertexOutput
		//	{
		//		float4 pos : SV_POSITION;
		//		float4 posWorld : TEXCOORD0;
		//		float4 grabPos : TEXCOORD1;
		//	};

		//	vertexOutput vert(vertexInput v)
		//	{
		//		vertexOutput o;

		//		o.pos = UnityObjectToClipPos(v.vertex);
		//		o.posWorld = mul(unity_ObjectToWorld, v.vertex);

		//		// wave (to match up with mesh & avoid cutting off mesh)
		//		float noiseSample = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0));
		//		o.pos.y += sin(_Time * _WaveSpeed * noiseSample) * _WaveAmp;
		//		o.pos.x += cos(_Time * _WaveSpeed * noiseSample) * _WaveAmp;
		//		o.grabPos = ComputeGrabScreenPos(o.pos);

		//		// distortion
		//		float bumpSample = tex2Dlod(_BumpTex, float4(v.texcoord.xy, 0, 0));
		//		o.grabPos.y += sin(_Time * _WaveSpeed * bumpSample) * _WaveAmp * _DistortStrength;
		//		o.grabPos.x += cos(_Time * _WaveSpeed * bumpSample) * _WaveAmp * _DistortStrength;

		//		return o;	
		//	}

		//	float4 frag(vertexOutput i) : COLOR
		//	{
		//		return tex2Dproj(_BackgroundTexture, i.grabPos);
		//	}

		//	ENDCG
		//}		

		// wave & texture
		Pass
		{
			LOD 200

			Blend SrcAlpha OneMinusSrcAlpha
			Lighting On
			ZTest On
			Tags 
			{ 
				"Queue" = "AlphaTest"   // Transparent cant receive shadow
				"RenderType" = "Transparent" 
				"IgnoreProjector"="True"
				"LightMode" = "ForwardBase" 
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers flash
			#pragma multi_compile_fwdbase

			#include "AutoLight.cginc"
			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;
			sampler2D _GrabTexture;

			uniform float4 _Color;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform sampler2D _NormalTex;
			uniform float4 _NormalTex_ST;
			uniform float _LightIntensity;
			uniform float4 _LightColor0;
			uniform float4 _SpecColor;
			uniform float _Shininess;

			uniform float _WaveSpeed;
			uniform float _WaveAmp;
			uniform float4 _WaveColor;
			uniform sampler2D _NoiseTex;
			uniform sampler2D _WaveRampTex;

			uniform float _FlowSpeed;
			uniform float _FlowDegree;
			uniform float4 _FlowColor;
			uniform sampler2D _FlowTex;
			uniform float4 _FlowTex_ST;

			uniform float _DepthFactor;
			uniform float _DepthTransparency;
			uniform float4 _DepthColor;
			uniform sampler2D _DepthRampTex;
			uniform float _FoamFactor;
			uniform float _FoamDegree;
			uniform float4 _FoamColor;
			uniform sampler2D _FoamTex;
			uniform float4 _FoamTex_ST;
			
			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD1;
				float4 tangent : TANGENT;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posWorld : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
				float4 tex : TEXCOORD2;
				float3 normalDir : TEXCOORD3;
				float3 tangentDir : TEXCOORD4;
				float3 bitangentDir : TEXCOORD5;
				float4 waveOffset : COLOR;
				LIGHTING_COORDS(6, 7)
			};

			float2 Rotate(float2 f, float deg)
			{
				float angle = deg / 180 * 3.1415926;
				float cosAngle = cos(angle);
				float sinAngle = sin(angle);
				float2x2 rot = float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);

				return mul(rot, f);
			}

			float Angle(float2 a, float2 b)
			{
				float cosAngle = dot(a, b) / length(a) / length(b);
				return acos(cosAngle);
			}

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.tex = v.texcoord;
				o.normalDir = normalize( mul(float4(v.normal, 0.0f), unity_WorldToObject).xyz );	
				o.tangentDir = normalize( mul(unity_ObjectToWorld, float4(v.tangent.xyz, 0)).xyz );
				o.bitangentDir = normalize( cross(o.normalDir, o.tangentDir) * v.tangent.w);

				// Wave
				float noiseSample = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0));
				float waveOffsetY = sin(_Time * _WaveSpeed * noiseSample);
				float waveOffsetX = cos(_Time * _WaveSpeed * noiseSample);
				o.pos.y += waveOffsetY * _WaveAmp;
				//o.pos.x += waveOffsetX * _WaveAmp;
				o.waveOffset = float4(waveOffsetX / 2 + 0.5, waveOffsetY / 2 + 0.5, 0, 0);

				// Flow
				o.tex += _Time * _FlowSpeed / 5;

				o.screenPos = ComputeScreenPos(o.pos);
				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;	
			}

			float4 frag(vertexOutput i) : COLOR
			{
				// lighting
				float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
				float3 normalDirection = i.normalDir;
				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				float atten = LIGHT_ATTENUATION(i);
				//if (_WorldSpaceLightPos0.w == 0.0)
				//{
				//	atten = 1.0;
				//	lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				//}
				//else
				//{
				//	float3 fragmentToLightSource = _WorldSpaceLightPos0.xyz - i.posWorld.xyz;
				//	float dis = length(fragmentToLightSource);
				//	atten = 1.0f / dis;
				//	lightDirection = normalize(fragmentToLightSource);
				//}
				/*
				// normal surface
				float3x3 tangentTransform = float3x3(i.tangentDir, i.bitangentDir, i.normalDir);
				float3 noTex = UnpackNormal(tex2D(_NormalTex, TRANSFORM_TEX(i.tex.xy, _NormalTex)));
				normalDirection = normalize(mul(normalDirection.rgb, tangentTransform));
				float3 viewReflectDir = reflect( -viewDirection, normalDirection );
				float2 screenUVs = (i.screenPos.xy / i.screenPos.w) + (normalDirection.gb * 0.01);
				float4 grabColor = tex2D(_GrabTexture, screenUVs);
				*/
				float3 diffuseReflection = atten * _LightColor0.xyz * saturate(dot(normalDirection, lightDirection));
				float3 specularReflection = _SpecColor.rgb * saturate(dot(normalDirection, lightDirection)) *
				pow( saturate(dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);

				float4 finalLight = float4(diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT.xyz, 1.0);

				// sample camera depth texture
				float4 depthSample = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, i.screenPos);
				float depth = LinearEyeDepth(depthSample).r;

				float depthLine = 1 - saturate(_DepthFactor * (depth - i.screenPos.w));
				float depthTransparency = 1 - saturate((1 - _DepthTransparency) * (depth - i.screenPos.w));
				float4 depthRamp = float4(tex2D(_DepthRampTex, float2(depthLine * depthTransparency, 0.5)).rgb, 1.0);
				float4 depestColor = float4(tex2D(_DepthRampTex, float2(0.1, 0)).rgb, 1.0);

				float foamLine = 1 - saturate(_FoamFactor * (depth - i.screenPos.w));
				float2 foamCoord = float2(foamLine, Rotate(i.posWorld.xz - i.tex.xz * 10, _FoamDegree).x);
				float4 foamRamp = tex2D(_FoamTex, foamCoord * _FoamTex_ST.xy + _FoamTex_ST.zw);

				float4 tex = tex2D(_MainTex, TRANSFORM_TEX(i.tex, _MainTex));
				float2 flowCoord = Rotate(i.tex.xy, _FlowDegree);
				float4 flowTex = tex2D(_FlowTex, flowCoord * _FlowTex_ST.xy + _FlowTex_ST.zw);

				float4 waveRamp = float4(tex2D(_WaveRampTex, float2(saturate(i.waveOffset.y), 0.5)).rgb, 1.0);

				float4 col = lerp(tex, _Color * tex, _Color.a);
				// lerp on wave
				col = lerp(col, waveRamp * _WaveColor * col, _WaveColor.a);

				if (foamLine == 0)
				{					
					// lerp on depth
					col = lerp(col * depthRamp, depestColor * _DepthColor, depthTransparency);
					// cast flow texture on depth & base
					col = lerp(col, flowTex * _FlowColor, flowTex.a * _FlowColor.a);
				}
				// foam line
				else
				{
					col = lerp(col * depthRamp, foamRamp * _FoamColor, foamRamp.a * _FoamColor.a);
				}

				col = lerp(col, col * finalLight, _LightIntensity);
				return col;
				
			}
			ENDCG
		}

		/*
		// Pass to render object as a shadow caster
        Pass 
		{
            Name "ShadowCaster"

			ZWrite On
			Tags 
			{ 
				"Queue" = "Transparent"
				"LightMode" = "ShadowCaster" 
			}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"
 
            struct v2f {
                V2F_SHADOW_CASTER;
            };

            v2f vert( appdata_base v )
            {
                v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o);
                return o;Shader "Custom/SurfaceDepthTextureColorized" {
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _BlendColor("Blend Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _InvFade("Soft Factor", Range(0.01,3.0)) = 1.0
        _FadeLimit("Fade Limit", Range(0.00,1.0)) = 0.3
    }
        SubShader{
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard vertex:vert alpha:fade nolightmap

        // Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

        sampler2D _MainTex;

    struct Input {
        float2 uv_MainTex;
        float4 screenPos;
        float eyeDepth;
    };

    half _Glossiness;
    half _Metallic;
    fixed4 _Color;
    fixed4 _BlendColor;
    sampler2D_float _CameraDepthTexture;
    float4 _CameraDepthTexture_TexelSize;

    float _FadeLimit;
    float _InvFade;

    void vert(inout appdata_full v, out Input o)
    {
        UNITY_INITIALIZE_OUTPUT(Input, o);
        COMPUTE_EYEDEPTH(o.eyeDepth);
    }

    void surf(Input IN, inout SurfaceOutputStandard o) {
        // Albedo comes from a texture tinted by color
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb;
        // Metallic and smoothness come from slider variables
        o.Metallic = _Metallic;
        o.Smoothness = _Glossiness;

        float rawZ = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos));
        float sceneZ = LinearEyeDepth(rawZ);
        float partZ = IN.eyeDepth;

        float fade = 1.0;
        if (rawZ > 0.0) // Make sure the depth texture exists
            fade = saturate(_InvFade * (sceneZ - partZ));
        //o.Alpha = c.a * fade; //(original line)
        //the rest are lines I've input
        o.Alpha = 1;
        if(fade<_FadeLimit)
        o.Albedo = c.rgb * fade + _BlendColor * (1 - fade);
    }
    ENDCG
    }
}
            }
 
            float4 frag( v2f i ) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i);
            }
            ENDCG
        }
		*/
	}
	FallBack Off
	//FallBack "Legacy Shaders/Transparent/Cutout/VertexLit"
}
