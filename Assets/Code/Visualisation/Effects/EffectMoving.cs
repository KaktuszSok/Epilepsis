using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoving : AnimatedEffect {

    Vector3 startPos;
    public Vector3 endPos;

    private void Awake()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (doAnimate)
        {
            float t = GetAdjustedTime(BeatTimeSystem.time, true);
            transform.localPosition = Vector3.Lerp(startPos, endPos, t/(animationLength - restTime));
        }
    }
}
