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

        #include "UnityCG.cginc"

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        sampler2D _MainTex;
        float _Opacity;

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = v.vertex;
            o.vertex.x *= 2;
            o.vertex.y *= -2;
            o.vertex.z = 1;
            //o.vertex = UnityObjectToClipPos(v.vertex);
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
