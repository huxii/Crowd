#include "AutoLight.cginc"
#include "UnityCG.cginc"

uniform sampler2D _LightRamp;
uniform float4 _LightRamp_ST;

uniform float4 _XPositiveColor;
uniform float4 _XNegativeColor;
uniform float4 _YPositiveColor;
uniform float4 _YNegativeColor;

uniform float4 _RimColor;
uniform float _RimPower;

uniform sampler2D _EmissionMap;
uniform float4 _EmissionColor;

struct SurfaceCustomOutput
{
	fixed3 Albedo;  // diffuse color
	fixed3 Normal;  // tangent space normal, if written
	half Metallic;
	//half Specular;  // specular power in 0..1 range
	//fixed Gloss;    // specular intensity
	fixed Alpha;    // alpha for transparencies
	fixed Emission;
	fixed3 Ao;
};

inline half4 LightingToonCutout(SurfaceCustomOutput s, half3 lightDir, half3 viewDir, half atten)
{
	// light ramp
	half NdotL = dot(s.Normal, lightDir);
	half lighting = min(0.95, max(0.05, atten * NdotL));
	half3 lightRamp = tex2D(_LightRamp, float2(lighting, 0)).rgb;

	// rim
	half rim = 1.0f - saturate(dot(s.Normal, viewDir));
	half4 rimLight = atten * _LightColor0 * _RimColor *
		saturate(dot(s.Normal, lightDir)) *
		pow(rim, _RimPower);

	// final
	half4 c;
	c.rgb = s.Albedo * lightRamp + UNITY_LIGHTMODEL_AMBIENT.rgb + rimLight.rgb;
	c.a = s.Alpha;

	return c;
}

inline half4 LightingToon(SurfaceCustomOutput s, half3 lightDir, half3 viewDir, half atten)
{
	// light ramp
	half NdotL = dot(s.Normal, lightDir);
	half lighting = min(0.95, max(0.05, atten * NdotL));
	half3 lightRamp = tex2D(_LightRamp, float2(lighting, 0)).rgb;

	// rim
	half rim = 1.0f - saturate(dot(s.Normal, viewDir));
	half4 rimLight = atten * _LightColor0 * _RimColor *
		saturate(dot(s.Normal, lightDir)) *
		pow(rim, _RimPower);

	// final
	half4 c;
	c.rgb = s.Albedo * s.Ao * lightRamp + s.Emission + UNITY_LIGHTMODEL_AMBIENT.rgb + rimLight.rgb;
	c.a = s.Alpha;

	return c;
}