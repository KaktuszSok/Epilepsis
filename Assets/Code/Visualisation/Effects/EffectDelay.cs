using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDelay : VisualisationEffect {

    public VisualisationEffect[] effectsToEnable = new VisualisationEffect[0];
    public float delay = 0f;
    public bool disableInstead = false;

    public override void Visualise()
    {
        StartCoroutine(WaitThenEnableEffects());
    }

    public override void Abort()
    {
        StopAllCoroutines();
    }

    IEnumerator WaitThenEnableEffects()
    {
        yield return new WaitForSeconds(BeatTimeSystem.RealToBeatTime(delay));
        foreach(VisualisationEffect effect in effectsToEnable)
        {
            effect.enabled = !disableInstead;
        }
    }
}
