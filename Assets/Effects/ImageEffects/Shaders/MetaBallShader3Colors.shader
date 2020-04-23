// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit alpha-cutout shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Custom/Transparent Cutout" {
Properties {
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}


	_StrokeColor("Stroke color", Color) = (1,1,1,1)
	_Stroke("Stroke alpha", Range(0,1)) = 0.1

	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5



	_1Color("First color", Color) = (1,1,1,1) // always white 
	_2Color("Second color", Color) = (1,1,1,1)      //1
	_3Color("Third color", Color) = (1,1,1,1)       //2
	_4Color("Fourth color", Color) = (1,1,1,1)      //3
	_5Color("Fifth color", Color) = (1,1,1,1)       //4
	_6Color("Sixth color", Color) = (1,1,1,1)       //5
		// Extra
	//_ThirdColor("Third color", Color) = (1,1,1,1)
	//_ForthColor("Forth color", Color) = (1,1,1,1)
}
SubShader {
	Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
	LOD 100

	Lighting Off

	Pass {  
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _Cutoff;

			half4 _1Color;
			half4 _2Color;
			half4 _3Color;
			half4 _4Color;
			half4 _5Color;
			half4 _6Color;

			fixed _Stroke;
			half4 _StrokeColor;

			v2f vert (appdata_t v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {
				fixed4 col = tex2D(_MainTex, i.texcoord);
		    	clip(col.a - _Cutoff);
				
				if (col.g > 0.5 && col.b > 0.5 && col.r > 0.5)//White
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _1Color;
					}
				}
			    else if (col.r > 0.5) // Red
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _2Color;
					}
				}
				else if (col.b > 0.5) // Blue
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _3Color;
					}
				}
				else if (col.g > 0.5) // Green
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _4Color;
					}
				}
				else if (col.g == 0.5f && col.b == 0.5f && col.r == 0.5f) // gray
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _5Color;
					}
				}
				else if (col.g < 0.5f && col.b < 0.5f && col.r < 0.5f) // Black
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = _6Color;
					}
				}
				else 
				{
					if (col.a < _Stroke) {
						col = _StrokeColor;
					}
					else
					{
						col = col;
					}
				}
				return col;
			}
		ENDCG
	}
}

}
