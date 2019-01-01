#include "AutoLight.cginc"
#include "UnityCG.cginc"
#include "Utils.cginc"	

sampler2D _GrabTexture;
sampler2D _CameraDepthTexture;

sampler2D _MainTex;
fixed _Width;
fixed _Tweak;
fixed _SoftEdge;

float4 _SourcePos;
float _DistanceFallOff;
float _MaxDistance;

fixed4 _Color;
fixed _OverlayFactor;
float _Intensity;
float _HaloIntensity;

fixed4 _SoftLightColor;
fixed _SoftLightFactor;
float _SoftLightIntensity;


struct v2f
{
	float4 pos : SV_POSITION;
	float4 uv : TEXCOORD0;
	float4 falloffUVs : TEXCOORD1;
	float4 screenPos : TEXCOORD2;
	float4 worldPos : TEXCOORD3;
	float4 color : COLOR;
};

v2f vert(appdata_full v)
{
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.worldPos = mul(unity_ObjectToWorld, v.vertex);
	o.color = v.color;

	// Generate the falloff texture UVs
	TANGENT_SPACE_ROTATION;
	float3 refVector = mul(rotation, normalize(ObjSpaceViewDir(v.vertex)));

	fixed z = sqrt((refVector.z + _Tweak) * _Width);
	fixed x = (refVector.x / z) + 0.5;
	fixed y = (refVector.y / z) + 0.5;

	fixed2 uv1 = float2(x, v.texcoord.y);
	fixed2 uv2 = float2(x, y);
	o.falloffUVs = fixed4(uv1, uv2);

	o.screenPos = ComputeScreenPos(o.pos);
	COMPUTE_EYEDEPTH(o.screenPos.z);

	return o;
}

fixed4 frag_overlay(v2f In) : COLOR
{
	half4 base = tex2Dproj(_GrabTexture, In.screenPos);
	float4 c = GetOverlayColor(base, _Color, _Color.a * In.color.a * _OverlayFactor) * _Intensity;
	c.a *= In.color.a;

	// Fade when near the camera
	c.a *= saturate(In.screenPos.z * 0.2);

	fixed falloff1 = tex2D(_MainTex, In.falloffUVs.xy).r;
	fixed falloff2 = tex2D(_MainTex, In.falloffUVs.zw).g;
	c.a *= min(1.0, max(0, falloff1 * falloff2));

	// Soft Edges
	float4 depth = tex2Dproj(_CameraDepthTexture, In.screenPos);
	fixed destDepth = LinearEyeDepth(depth);
	fixed diff = min(1.0f, max(0, saturate((destDepth - In.screenPos.z) * _SoftEdge)));
	c.a *= diff;

	float distRatio = min(1.0f, max(0, length(In.worldPos.xyz - _SourcePos.xyz) / _MaxDistance));
	float distPower = min(1.0f, max(0, 1 - pow(distRatio, _DistanceFallOff)));
	c.a *= distPower;

	return c;
}

fixed4 frag_overlay_halo(v2f In) : COLOR
{
	half4 base = tex2Dproj(_GrabTexture, In.screenPos);

	fixed4 c = _Color * _HaloIntensity;
	c.a *= In.color.a;

	float4 effect = lerp(1 - (2 * (1 - base)) * (1 - c), (2 * base) *c, step(base, 0.5f));
	c = lerp(base, effect, _OverlayFactor * c.a);

	// Fade when near the camera
	c.a *= saturate(In.screenPos.z * 0.2);

	fixed falloff1 = tex2D(_MainTex, In.falloffUVs.xy).r;
	fixed falloff2 = tex2D(_MainTex, In.falloffUVs.zw).g;
	c.a *= min(1.0, max(0, falloff1 * falloff2));

	// Soft Edges
	float4 depth = tex2Dproj(_CameraDepthTexture, In.screenPos);
	fixed destDepth = LinearEyeDepth(depth);
	fixed diff = min(1.0f, max(0, saturate((destDepth - In.screenPos.z) * _SoftEdge)));
	c.a *= diff;

	return c;
}

fixed4 frag_soft(v2f In) : COLOR
{
	half4 base = tex2Dproj(_GrabTexture, In.screenPos);
	float4 c = GetSoftLightColor(base, _SoftLightColor, _SoftLightColor.a * In.color.a * _SoftLightFactor) * _SoftLightIntensity;
	c.a *= In.color.a;

	// Fade when near the camera
	c.a *= saturate(In.screenPos.z * 0.2);

	fixed falloff1 = tex2D(_MainTex, In.falloffUVs.xy).r;
	fixed falloff2 = tex2D(_MainTex, In.falloffUVs.zw).g;
	c.a *= min(1.0, max(0, falloff1 * falloff2));

	// Soft Edges
	float4 depth = tex2Dproj(_CameraDepthTexture, In.screenPos);
	fixed destDepth = LinearEyeDepth(depth);
	fixed diff = min(1.0f, max(0, saturate((destDepth - In.screenPos.z) * _SoftEdge)));
	c.a *= diff;

	float distRatio = min(1.0f, max(0, length(In.worldPos.xyz - _SourcePos.xyz) / _MaxDistance));
	float distPower = min(1.0f, max(0, 1 - pow(distRatio, _DistanceFallOff)));
	c.a *= distPower;

	return c;
}
