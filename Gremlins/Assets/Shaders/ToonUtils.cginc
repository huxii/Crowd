#include "Utils.cginc"

uniform sampler2D _LightRamp;
uniform float4 _LightRamp_ST;

uniform float4 _XPositiveColor;
uniform float4 _XNegativeColor;
uniform float4 _YPositiveColor;
uniform float4 _YNegativeColor;

uniform float4 _RimColor;
uniform float _RimPower;

struct SurfaceCustomOutput
{
	fixed3 Albedo;  // diffuse color
	fixed3 Normal;  // tangent space normal, if written
	//half Metallic;
	half Specular;  // specular power in 0..1 range
	fixed Gloss;    // specular intensity
	fixed Alpha;    // alpha for transparencies
	fixed Emission;
	fixed3 Ao;
};

inline half4 CaculateShadow(half3 albedo, half3 normal, half3 lightDir, half atten)
{
	half NdotL = dot(normal, lightDir);
	half lighting = min(0.95, max(0.05, atten * NdotL));
	half3 lightRamp = tex2D(_LightRamp, float2(lighting, 0)).rgb;
	half4 shadowColor = lerp(GetSoftLightColor(half4(albedo, 1.0), half4(1, 1, 1, 1), 1.0), half4(1, 1, 1, 1), lightRamp.r);
	return shadowColor;
}

inline half CaculateSpec(half specular, half gloss, half3 normal, half3 lightDir, half3 viewDir)
{
	fixed3 h = normalize(lightDir + viewDir);
	float nh = max(0, dot(normal, h));
	float spec = max(0.0, min(1.0, pow(nh, gloss * 128) * specular));
	return spec;
}

inline half4 CaculateRim(half3 normal, half3 lightDir, half3 viewDir, half atten)
{
	half rim = 1.0f - saturate(dot(normal, viewDir));
	half4 rimLight = atten * _LightColor0 * _RimColor *
		saturate(dot(normal, lightDir)) *
		pow(rim, _RimPower);
	return rimLight;
}

inline half4 LightingToonCutout(SurfaceCustomOutput s, half3 lightDir, half3 viewDir, half atten)
{
	half4 shadowColor = CaculateShadow(s.Albedo, s.Normal, lightDir, atten);

	// final
	half4 c;
	c.rgb = s.Albedo * shadowColor.rgb + UNITY_LIGHTMODEL_AMBIENT.rgb;
	c.a = s.Alpha;

	return c;
}

inline half4 LightingToon(SurfaceCustomOutput s, half3 lightDir, half3 viewDir, half atten)
{
	half4 shadowColor = CaculateShadow(s.Albedo, s.Normal, lightDir, atten);
	half spec = CaculateSpec(s.Specular, s.Gloss, s.Normal, lightDir, viewDir);
	half4 rimLight = CaculateRim(s.Normal, lightDir, viewDir, atten);

	// final
	half4 c;
	c.rgb = (s.Albedo * s.Ao * shadowColor.rgb * _LightColor0.rgb + _LightColor0 * spec + rimLight.rgb);
	c.a = s.Alpha;

	return c;
}