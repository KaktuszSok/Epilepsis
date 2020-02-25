using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpinning : AnimatedEffect {

    public Vector3 rotationStart;
    public Vector3 rotationEnd;

    void Update()
    {
        if(doAnimate)
        {
            float t = GetAdjustedTime(BeatTimeSystem.time, true);
            Vector3 currRot = Vector3.Lerp(rotationStart, rotationEnd, t/(animationLength - restTime));
            transform.localEulerAngles = currRot;
        }
    }
}
