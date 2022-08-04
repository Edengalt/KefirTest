Shader "Unlit/BGSpace"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Zoom("Zoom", Range(0.1,10)) = 1
        _Direction("Direction", Range(-1, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
            float _Direction;
            float _Zoom;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float3 coloring(float dist)
            {
                return float3(dist * 0.0004,dist * 0.0005 , dist * 0.003);
            }
            float mod(float x, float y)
            {
                return x - y * floor(x / y);
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                
                float3 pos = float3(i.uv * _Zoom, 1);
                float3 color = 0;
                float time = mod(_Time.y * 0.005, 7200);
                float dir = float3(time * _Direction,0, 0);
                float a=0, prevA = 0;
                for (int i = 0; i < 25; i++)
                {
                    pos += dir;
                    pos = (abs(pos)/dot(pos,pos) - 0.8) ;
                    a += abs(length(pos) - prevA);
                    prevA = length(pos);
                }
                a = pow(a,1.2);
                color =  coloring(a) + a * 0.001;
               // UNITY_APPLY_FOG(i.fogCoord, col);
                return float4(color,1);
            }
            ENDCG
        }
    }
}
