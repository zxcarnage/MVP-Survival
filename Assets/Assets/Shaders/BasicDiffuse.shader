Shader "Custom/BasicDiffuse"
{
    Properties
    {
        _EmissiveColor("Emission Color", Color) = (1,1,1,1)
        _AmbientColor("Ambient Color", Color) = (1,1,1,1)
        _DiffusePower("Diffuse Power", Range(0,10)) = 2.5
        _RampTexture("Ramp texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BasicDiffuse
        
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
        
        fixed4 _EmissiveColor;
        fixed4 _AmbientColor;
        float _DiffusePower;
        sampler2D _RampTexture;

        
        inline float4 LightingBasicDiffuse(SurfaceOutput s, fixed3 lightDir,
            half3 viewDir, fixed atten)
        {
            const float difLight = dot(s.Normal, lightDir);
            const float rimLight = dot(s.Normal, viewDir);
            const float halfLambert = difLight * 0.5 + 0.5;
            const float3 ramp = tex2D(_RampTexture, float2(halfLambert, rimLight)).rgb;
            
            float4 col;
            col.rgb = s.Albedo * _LightColor0.rgb * ramp;
            col.a = s.Alpha;
            return col;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            float4 c;
            c = pow(_EmissiveColor + _AmbientColor, _DiffusePower);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
