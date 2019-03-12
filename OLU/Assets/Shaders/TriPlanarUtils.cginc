struct Input
{
	float3 worldPos;
	float3 worldNormal;
};

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