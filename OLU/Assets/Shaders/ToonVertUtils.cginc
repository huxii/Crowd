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