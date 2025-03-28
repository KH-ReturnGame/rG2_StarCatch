Shader "Custom/RandomGradient"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (0, 0, 0, 1)  // 검은색
        _Color2 ("Color 2", Color) = (0, 0, 0.5, 1) // 남색
        _Width ("Width", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            float _Width;
            float4 _Color1;
            float4 _Color2;

            // 랜덤 시작점을 계산하는 함수
            float random(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // 랜덤 시작점을 계산
                float randomStart = random(i.uv);

                // 그라데이션을 계산: _Width는 그라데이션의 시작점 위치 조절
                float t = smoothstep(randomStart - _Width / 2.0, randomStart + _Width / 2.0, i.uv.x);

                // 그라데이션을 적용
                return lerp(_Color1, _Color2, t);
            }
            ENDCG
        }
    }
}
