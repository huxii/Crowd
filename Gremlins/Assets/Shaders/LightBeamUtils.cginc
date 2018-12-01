#include "AutoLight.cginc"
#include "UnityCG.cginc"

sampler2D _GrabTexture;
sampler2D _CameraDepthTexture;

sampler2D _MainTex;
fixed4 _Color;
fixed _Width;
fixed _Tweak;
fixed _SoftEdge;
fixed _Overlay;
float _Glow;

struct v2f
{
	float4 pos : SV_POSITION;
	float4 uv : TEXCOORD0;
	float4 falloffUVs : TEXCOORD1;
	float4 screenPos : TEXCOORD2;
	float4 color : COLOR;
};

v2f vert(appdata_full v)
{
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
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

fixed4 frag_soft(v2f In) : COLOR
{
	half4 base = tex2Dproj(_GrabTexture, In.screenPos);
	half gray = (base.r + base.g + base.b) / 3;

	fixed4 c = _Color;

	fixed falloff1 = tex2D(_MainTex, In.falloffUVs.xy).r;
	fixed falloff2 = tex2D(_MainTex, In.falloffUVs.zw).g;
	c.a *= falloff1 * falloff2;

	// Soft Edges
	float4 depth = tex2Dproj(_CameraDepthTexture, In.screenPos);
	fixed destDepth = LinearEyeDepth(depth);
	fixed diff = saturate((destDepth - In.screenPos.z) * _SoftEdge);
	c.a *= diff;

	// Fade when near the camera
	c.a *= saturate(In.screenPos.z * 0.2);

	float4 effect = lerp(1 - (2 * (1 - base)) * (1 - c), (2 * base) *c, step(base, 0.5f));

	c = lerp(base, effect, _Overlay);
	c.a *= In.color.a;

	return c;
}

fixed4 frag_soft_halo(v2f In) : COLOR
{
	half4 base = tex2Dproj(_GrabTexture, In.screenPos);
	half gray = (base.r + base.g + base.b) / 3;

	fixed4 c = _Color * _Glow;

	fixed falloff1 = tex2D(_MainTex, In.falloffUVs.xy).r;
	fixed falloff2 = tex2D(_MainTex, In.falloffUVs.zw).g;
	c.a *= falloff1 * falloff2;

	// Soft Edges
	float4 depth = tex2Dproj(_CameraDepthTexture, In.screenPos);
	fixed destDepth = LinearEyeDepth(depth);
	fixed diff = saturate((destDepth - In.screenPos.z) * _SoftEdge);
	c.a *= diff;

	// Fade when near the camera
	c.a *= saturate(In.screenPos.z * 0.2);

	float4 effect = lerp(1 - (2 * (1 - base)) * (1 - c), (2 * base) *c, step(base, 0.5f));

	c = lerp(base, effect, _Overlay);
	c.a *= In.color.a;

	return c;
}
