// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Lightbeam_soft" 
{
	Properties 
	{
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Width("Width", Float) = 8.71
		_Tweak("Tweak", Float) = 0.65
		_Intensity("Intensity", Float) = 1
		_HaloIntensity("Halo Intensity", Float) = 1
		_Overlay("Overlay", Range(0, 1)) = 0.5
		_SoftEdge("Soft Edge", Float) = 0.8
		_DistanceFallOff("Distance Fall Off", Float) = 0.5
		[HideInInspector]_MaxDistance("Max Distance", Float) = 1
		[HideInInspector]_SourcePos("Source Position", Vector) = (0, 0, 0, 0)
	}

	SubShader 
	{
		Tags 
		{ 
			"Queue" = "Transparent" 
			"IgnoreProjector" = "True"
		}

		GrabPass{}

		Pass 
		{
			Cull Front
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Lighting Off
			
			stencil
			{
				Ref 1
				Comp Always
				Pass Replace
			}

			CGPROGRAM
			#include "LightBeamUtils.cginc"		

			#pragma vertex vert
			#pragma fragment frag_soft			
			ENDCG
		}

		Pass 
		{
			Name "Halo"

			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Lighting Off

			stencil
			{
				Ref 1
				Comp NotEqual
				Pass Replace
			}

			CGPROGRAM
			#include "LightBeamUtils.cginc"		

			#pragma vertex vert
			#pragma fragment frag_soft_halo		
			ENDCG
		}
	} 
	Fallback "Lightbeam/Lightbeam"
}
