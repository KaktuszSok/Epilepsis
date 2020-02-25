using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScaling : AnimatedEffect {

    public AnimationCurve scaleMultiplier = new AnimationCurve();

    void Update()
    {
        if (doAnimate)
        {
            float t = GetAdjustedTime(BeatTimeSystem.time, true);
            transform.localScale = Vector3.one*scaleMultiplier.Evaluate(Mathf.Clamp01(t/(animationLength - restTime)));
        }
    }
}
