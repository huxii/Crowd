#include "AutoLight.cginc"
#include "UnityCG.cginc"

struct appdata_color
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

inline half4 GetOverlayColor(half4 base, half4 color, float factor)
{
	float4 effect = lerp(1 - (2 * (1 - base)) * (1 - color), (2 * base) * color, step(base, 0.5f));
	fixed4 c = lerp(base, effect, factor);
	return c;
}

inline half4 GetSoftLightColor(half4 base, half4 color, float factor)
{
	float4 effect = lerp(2 * base * color, 2 * base * (1 - color) + sqrt(base) * (2 * color - 1), step(color, 0.5f));
	fixed4 c = lerp(base, effect, factor);
	return c;
}