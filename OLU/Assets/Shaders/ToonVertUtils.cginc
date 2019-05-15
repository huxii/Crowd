struct Input
{
	float2 uv_MainTex;
	float4 posWorld;
};

void vert(inout appdata_full v, out Input o)
{
	UNITY_INITIALIZE_OUTPUT(Input, o);
	o.posWorld = mul(unity_ObjectToWorld, v.vertex);
}

float2 rotate(float theta, float2 p)
{
	float sinTheta = sin(theta);
	float cosTheta = cos(theta);
	float2x2 rotationMatrix = float2x2(cosTheta, -sinTheta, sinTheta, cosTheta);
	return mul(p, rotationMatrix);
}