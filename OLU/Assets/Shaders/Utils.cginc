#include "AutoLight.cginc"
#include "UnityCG.cginc"
#include "Lighting.cginc"

struct appdata_color
{
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD0;
	float4 posWorld: TEXCOORD1;
	float4 color : COLOR;
};

inline float4 GetClipPosition(float4 pos, float3 n, float width)
{
	float4 clipPosition = UnityObjectToClipPos(pos);
	float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, n));

	clipPosition.xy += normalize(clipNormal.xy) * width * clipPosition.w / 40 /*/ _ScreenParams.xy * 40**/ /** (1 - ramp)*/;

	return clipPosition;
}

inline half4 GetOverlayColor(half4 base, half4 color, float factor)
{
	float4 effect = saturate(lerp(1 - (2 * (1 - base)) * (1 - color), (2 * base) * color, step(base, 0.5f)));
	fixed4 c = lerp(base, effect, factor);
	return c;
}

inline half4 GetSoftLightColor(half4 base, half4 color, float factor)
{
	float4 effect = saturate(lerp(2 * base * color, 2 * base * (1 - color) + sqrt(base) * (2 * color - 1), step(color, 0.5f)));
	fixed4 c = lerp(base, effect, factor);
	return c;
}

inline half4 GetTriPlanarColor(sampler2D tex, half3 worldPos, half3 worldNormal, float scale, float offset)
{
	float3 projNormal = saturate(pow(worldNormal * 1.4, 4));

	float4 yz = tex2D(tex, frac(worldPos.zy * scale + offset)) * abs(worldNormal.x);

	float4 xz = 0;
	if (worldNormal.y > 0)
	{
		xz = tex2D(tex, frac(worldPos.zx * scale + offset)) * abs(worldNormal.y);
	}
	else
	{
		xz = tex2D(tex, frac(worldPos.zx * scale + offset)) * abs(worldNormal.y);
	}

	float4 xy = tex2D(tex, frac(worldPos.xy * scale + offset)) * abs(worldNormal.z);

	float4 c = lerp(lerp(xy, yz, projNormal.x), xz, projNormal.y);
	return c;
}