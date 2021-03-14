// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float dist;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		uniform  fixed4 _PlayerPos;
		uniform  fixed4 _RainbowColor;
		uniform  float _MinDistance;
		uniform  float _Width;

		void vert(inout appdata_full v, out Input o) 
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.worldPos = mul(unity_ObjectToWorld, v.vertex);
			o.dist = distance(o.worldPos, _PlayerPos);

			if (o.dist > _MinDistance - _Width/2 && o.dist < _MinDistance + _Width/2 && o.dist !=0)
			{
				v.vertex.xyz +=  (v.normal * (1-_RainbowColor.a));
			}
		}

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			if (IN.dist > _MinDistance - _Width / 2 && IN.dist < _MinDistance + _Width / 2)
			{
				o.Albedo = lerp(_RainbowColor.rgb, c.rgb, _RainbowColor.a);
			}
			else
			{
				o.Albedo = c.rgb;
			}

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
