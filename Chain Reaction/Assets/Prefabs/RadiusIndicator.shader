Shader "Unlit/RadiusIndicator"
{
	//Properties
	//{
	//	_MainTex ("Texture", 2D) = "white" {}
	//}
	Properties
	{
		_Color("Color (RGBA)", Color) = (0, 0, 0, 1) // add _Color property
		_Radius("Radius", Range(0.2,0.8)) = 0.8
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		ZWrite Off
		ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
		//Cull front
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _Radius;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				//o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv = v.uv;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col = _Color;
				float r = length((i.uv - 0.5) * 2);
				float compress = 15;
				float peak = 1.0 - pow(abs(compress * (r - _Radius)), 3.5);
				//float peak = saturate(pow(cos(3.14 * r * 0.5), 3.5));
				col.a = saturate(col.a * peak);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
