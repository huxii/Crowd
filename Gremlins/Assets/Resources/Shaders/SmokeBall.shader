Shader "Custom/SmokeBall"
{
    Properties
    {
		_MainTex("Main Texture", 2D) = "white" {}
		_Color("Base Color", Color) = (1, 1, 1, 1)
		_ReplaceColor("Replace Color", Color) = (1, 1, 1, 1)
		_ReplaceFactor("Replace Factor", Range(0, 1)) = 0
		_LightRamp("Light Ramp", 2D) = "white" {}
		_DissolveTimer("Dissolve Timer", Range(0, 1)) = 0
		_DissolveNoise("Dissolve Noise", 2D) = "white" {}
		_DissolveNoiseOffset("Dissolve Noise Offset", Range(0, 1)) = 0 
		_DeformNoise("Deform Noise", 2D) = "white" {}
		_DeformSpeed("Deform Speed", Float) = 1
		_DeformStrength("Deform Strength", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
		Cull Off

        CGPROGRAM
		#include "ToonLightingUtils.cginc"
        #pragma surface surf ToonCutout vertex:vert addshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

		uniform sampler2D _MainTex;
		uniform fixed4 _Color;
		uniform fixed4 _ReplaceColor;
		uniform float _ReplaceFactor;

		uniform float _DissolveTimer;
		uniform sampler2D _DissolveNoise;
		uniform float4 _DissolveNoise_ST;
		uniform float _DissolveNoiseOffset;
		uniform sampler2D _DeformNoise;
		uniform float4 _DeformNoise_ST;
		uniform float _DeformSpeed;
		uniform float _DeformStrength;

        struct Input
        {
            float2 uv_MainTex;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		void vert(inout appdata_base v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);

			float2 uv = v.texcoord;
			uv.y += _Time.y * _DeformSpeed;
			float4 noiseSample = tex2Dlod(_DeformNoise, float4(TRANSFORM_TEX(uv, _DeformNoise), 0, 0));
			v.vertex.x += _DeformStrength * sin(noiseSample - 0.5);
			v.vertex.y += _DeformStrength * sin(noiseSample - 0.5);
		}

        void surf (Input IN, inout SurfaceCustomOutput o)
        {
            // Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * lerp(_Color, _ReplaceColor, _ReplaceFactor);
            o.Albedo = c.rgb;
            o.Alpha = c.a;

			float2 uv = IN.uv_MainTex;
			uv.x += _DissolveNoiseOffset;
			float4 noiseSample = tex2Dlod(_DissolveNoise, float4(TRANSFORM_TEX(uv, _DissolveNoise), 0, 0));
			clip(noiseSample - _DissolveTimer * (2 - IN.uv_MainTex.y * IN.uv_MainTex.y));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
