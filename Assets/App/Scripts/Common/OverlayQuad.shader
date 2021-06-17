Shader "Custom/OverlayQuad"
{
  Properties
  {
      _MainTex ("Texture", 2D) = "white" {}
      _Opacity ("Opacity", Range(0.0, 1.0)) = 1.0
  }
  SubShader
  {
    Tags
    {
      "Queue" = "Overlay"
      "RenderType" = "Transparent"
      "PreviewType" = "Plane"
    }
    Lighting Off Cull Off ZTest Off ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha

    Pass
    {
      CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON

        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
            UNITY_VERTEX_INPUT_INSTANCE_ID
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
            UNITY_VERTEX_OUTPUT_STEREO
        };

        sampler2D _MainTex;
        float _Opacity;

        v2f vert (appdata v)
        {
            v2f o;
            UNITY_SETUP_INSTANCE_ID(v);
            UNITY_INITIALIZE_OUTPUT(v2f, o);
            UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
            o.vertex = v.vertex * float4(2.0, -2.0, 0.0, 1.0);;
            //o.vertex = UnityObjectToClipPos(v.vertex); // Uncomment this to view as normal quad
            o.uv = v.uv;
            return o;
        }

        float4 frag (v2f i) : SV_Target
        {
            return float4(tex2D(_MainTex, i.uv).rgb, _Opacity);
        }
      ENDCG
    }
  }
}
