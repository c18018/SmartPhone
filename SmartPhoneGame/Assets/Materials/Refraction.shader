Shader "Unlit/Refraction"
{
	Properties{

	}

	SubShader{
		Tags{
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
	}

		GrabPass{}

		CGPROGRAM
#pragma target 3.0
#pragma surface surf Standard fullforwardshadows

		sampler2D _GrabTexture;

	struct Input {
		float2 uv_NomalTex;
		float4 screenPos;
	};

	void surf(Input IN, inout SurfaceOutputStandard o) {
		float2 grabUV = (IN.screenPos.xy / IN.screenPos.w);

		grabUV.y = grabUV.y * -1 + 1;

		fixed3 grab = tex2D(_GrabTexture, grabUV).rgb;

		o.Emission = grab;
		o.Albedo = fixed3(0, 0, 0);
	}
	ENDCG
	}

		FallBack "Transparent/Diffuse"
}