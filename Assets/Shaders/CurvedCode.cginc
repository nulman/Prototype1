﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


#include "UnityCG.cginc"

struct appdata
{
	float4 vertex : POSITION;
	float2 uv : TEXCOORD0;
	float4 color : COLOR;
};

struct v2f
{
	float2 uv : TEXCOORD0;
	UNITY_FOG_COORDS(1)
	float4 color : TEXCOORD2;
	float4 vertex : SV_POSITION;
};

sampler2D _MainTex;
float4 _MainTex_ST;
float _CurveStrength;
float _CurvePower;
float _x;
float _y;
int _Direction;


v2f vert(appdata v)
{
	v2f o;

	float _Horizon = 100.0f;
	float _FadeDist = 50.0f;

	o.vertex = UnityObjectToClipPos(v.vertex);


	float dist = UNITY_Z_0_FAR_FROM_CLIPSPACE(o.vertex.z);
	// if(_Direction == 1){
	// 	o.vertex.y -= _CurveStrength * dist * dist * _ProjectionParams.x;
	// }else if(_Direction == 0){
	// 	o.vertex.x -= _CurveStrength * dist * dist * _ProjectionParams.y;
	// }else{
	// 	o.vertex.y += _CurveStrength * dist * dist * _ProjectionParams.x;
	// }
	o.vertex.y -= _y * _CurveStrength * dist * dist * _ProjectionParams.x;
	o.vertex.x -= _x * _CurveStrength * dist * dist * _ProjectionParams.y;
	o.uv = TRANSFORM_TEX(v.uv, _MainTex);

	o.color = v.color;

	UNITY_TRANSFER_FOG(o, o.vertex);
	return o;
}

fixed4 frag(v2f i) : SV_Target
{
	// sample the texture
	fixed4 col = tex2D(_MainTex, i.uv) * i.color;
// apply fog
UNITY_APPLY_FOG(i.fogCoord, col);
return col;
}