﻿Shader "Hidden/WaterDIsplacement"{


    Properties{
        _MaxY ("MaxY", Float) = 0
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass{
            //CGPROGRAM
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            //#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
                            

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 worldSpacePos : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 worldSpacePos : TEXCOORD1;
            };

            v2f vert (appdata v){
                v2f o;
                //o.vertex = UnityObjectToClipPos(v.vertex);
                o.vertex = float4(v.vertex.xy, 0.0, 1.0);
                o.uv = v.uv;
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target{
                //i.uv = -i.uv;
                //i.uv.x = -i.uv.x;
                //i.uv.y = -i.uv.y;

                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                if (i.worldSpacePos.y < 0.5) {
                    col.rgb = lerp(col.rgb, float3(0, 0, 1), 0.5);
                    //col.a = 0;
                }



                return col;
            }
            //ENDCG
            ENDHLSL
        }
    }
}
