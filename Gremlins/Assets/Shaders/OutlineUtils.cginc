#include "AutoLight.cginc"
#include "UnityCG.cginc"

uniform float4 _LightColor0;

struct vertexInput
{
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD0;
	float4 color : COLOR;
};

inline float4 GetClipPosition(float4 pos, float3 n, float width)
{
	//float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
	//float ramp = clamp(dot(normalDirection, lightDirection), 0, 1.0) * 0.8;

	float4 clipPosition = UnityObjectToClipPos(pos);
	float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, n));

	clipPosition.xy += normalize(clipNormal.xy) * width * clipPosition.w / 40 /*/ _ScreenParams.xy * 40**/ /** (1 - ramp)*/;

	return clipPosition;
}