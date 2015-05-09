Shader "Custom/Green_ToonLitOutline_Shader" {
	Properties {
		_Color ("Color", Color) = (0,1,0,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline Width", Range(.002, .03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp("Toon Ramp (RGB)", 2D) = "gray" {}
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : SV_POSITION;
		UNITY_FOG_COORDS(0)
		fixed4 color : COLOR;
	};
	
	uniform float _Outline;
	uniform float4 _OutlineColor;
	
	v2f vert(appdata v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float3 norm   = normalize(mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal));
		float2 offset = TransformViewToProjection(norm.xy);

		o.pos.xy += offset * o.pos.z * _Outline;
		o.color = _OutlineColor;
		UNITY_TRANSFER_FOG(o,o.pos);
		return o;
	}

	ENDCG

	SubShader {
		Tags {"RenderType"="Opaque"}
			LOD 200
			CGPROGRAM
			#pragma surface surf ToonRamp
			sampler2D _Ramp;
			#pragma lighting ToonRamp exclude_path:prepass
			inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
			{
				#ifndef USING_DIRECTIONAL_LIGHT
				lightDir = normalize(lightDir);
				#endif

				half d = dot(s.Normal, lightDir)*0.5+0.5;
				half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;

				half4 c;
				c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten*2);
				c.a=0;

				return c;
			}

			sampler2D _MainTex;
			float4 _Color;

			struct Input {
				float2 uv_MainTex : TEXCOORD0;
			};

			void surf (Input IN, inout SurfaceOutput o) {
				half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
			ENDCG

			Pass {
				Name "OUTLINE"
				Tags {"LightMode" = "Always"}
				Cull Front
				ZWrite On
				ColorMask RGB
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fog
				fixed4 frag(v2f i) : SV_Target
				{
					UNITY_APPLY_FOG(i.fogCoord, i.color);
					return i.color;
				}
				ENDCG
			}
	}	
	Fallback "Diffuse"
}