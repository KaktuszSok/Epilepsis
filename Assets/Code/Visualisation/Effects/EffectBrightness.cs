using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBrightness : VisualisationEffect {

    Renderer Rend;
    Material Mat;

    public Color albedoColour = Color.white;
    public float albedoIntensity = 1f;
    public Color emissionColour = Color.white;
    public float emissionIntensity = 0f;

    private void Awake()
    {
        Rend = GetComponentInChildren<Renderer>();
        Mat = Rend.material;
    }

    public override void Visualise()
    {
        Mat.SetColor("_Color", albedoColour * albedoIntensity);
        if (emissionIntensity > 0) Mat.EnableKeyword("_EMISSION");
        else Mat.DisableKeyword("_EMISSION");
        Mat.SetColor("_EmissionColor", emissionColour * emissionIntensity);
    }
}
