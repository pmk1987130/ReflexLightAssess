Shader "Custom/WallShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_FlashColor("FlashColoe",color)=(1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondTex("Second (RGB)",2D)="white"{}
		_NormalTex("Noraml (RGB)",2D)="white"{}
		_Border("Border",Range(1.5,3))=3
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SecondTex;
		sampler2D _NormalTex;
		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _FlashColor;
		float _Border;
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color*_FlashColor;
			// Metallic and smoothness come from slider variables
			o.Normal = UnpackNormal(tex2D (_NormalTex, IN.uv_MainTex));
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			fixed3 d=tex2D (_SecondTex, IN.uv_MainTex).xyz * _Color*_FlashColor;
			float  v=step(_Border,d.x+d.y+d.z);
     		o.Albedo=(c.xyz)*v+(1-v)*d;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
