Shader "Custom/GradientShader"
{
    Properties
    {
        _Color ("Color", Color) = (1, 0, 0, 1) // Base color with transparency
        _VerticalGradient ("Vertical Gradient", Float) = 1.0 // 1 for vertical, 0 for horizontal
        _MinRange ("Gradient Start", Range(0, 1)) = 0.0 // Where the gradient starts (0 is bottom/left)
        _MaxRange ("Gradient End", Range(0, 1)) = 1.0   // Where the gradient ends (1 is top/right)
        _GradientHeight ("Gradient Height", Float) = 1.0 // Set the height where the transparency starts
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha  // Enable alpha blending for transparency
            ZWrite Off                       // Disable depth writing for transparent objects

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Properties
            fixed4 _Color;           // Base color with alpha for transparency
            float _VerticalGradient; // Controls vertical (1) or horizontal (0) gradient
            float _MinRange;         // Start of the gradient (0 = bottom/left)
            float _MaxRange;         // End of the gradient (1 = top/right)
            float _GradientHeight;   // Custom height for transparency start

            // Vertex data
            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;  // Use UVs for gradient positioning
            };

            // Vertex Shader
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy; // Use UVs for gradient calculation
                return o;
            }

            // Fragment Shader
            fixed4 frag(v2f i) : SV_Target
            {
                float gradientPos;

                // Vertical or Horizontal gradient based on _VerticalGradient
                if (_VerticalGradient == 1.0)
                {
                    // Vertical gradient: based on the y position
                    gradientPos = saturate(i.uv.y / _GradientHeight); // Scale based on custom height
                }
                else
                {
                    // Horizontal gradient: based on the x position
                    gradientPos = saturate(i.uv.x);
                }

                // Remap the gradient based on the min and max range
                float gradientFactor = saturate((gradientPos - _MinRange) / (_MaxRange - _MinRange));

                // Set final color with smooth transparency from opaque to transparent
                fixed4 finalColor = _Color;
                finalColor.a *= gradientFactor; // Alpha blending based on gradient factor

                return finalColor;
            }
            ENDCG
        }
    }

    FallBack "Transparent/Cutout/VertexLit"
}
