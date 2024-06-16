Shader "Custom/GlitchShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _GlitchAmount ("Glitch Amount", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float _GlitchAmount;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            // Apply glitch effect
            c.r += sin(_GlitchAmount * 100 * IN.uv_MainTex.y);
            c.g += cos(_GlitchAmount * 100 * IN.uv_MainTex.x);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}