using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatedEffect : VisualisationEffect {

    public bool doAnimate = false;
    public float animationLength = 1f;
    public float restTime = 0f; //if animationLength is 1 and restTime is 0.75f, then animation will be completed by t=0.25f but then it will rest until t=1f, when it will loop.
    public float animationOffset = 0f;
    public RepeatType animationLooping = RepeatType.LOOP;

    public override void Visualise()
    {
        doAnimate = true;
    }
    public override void Abort()
    {
        doAnimate = false;
    }

    protected virtual float GetAdjustedTime(float time, bool allowChangesToGO = true)
    {
        float animTime = time + animationOffset;
        if (animTime >= animationLength || animTime < 0)
        {
            switch (animationLooping)
            {
                case RepeatType.NONE:
                    if (allowChangesToGO)
                    {
                        doAnimate = false; //stop animating
                    }
                    if (animTime < 0) animTime = 0;
                    else animTime = animationLength;
                    break;
                case RepeatType.DISAPPEAR:
                    if (animTime < 0) break; //if not started, do nothing and wait until anim starts
                    else
                    {
                        if (animTime < 0) animTime = 0;
                        else animTime = animationLength;
                    }
                    if (allowChangesToGO)
                    {
                        transform.position = Vector3.down * 69420f;
                        doAnimate = false;
                    }
                    break;
                case RepeatType.LOOP:
                    animTime = Mathf.Repeat(animTime, animationLength);
                    break;
                case RepeatType.PINGPONG:
                    animTime = Mathf.PingPong(animTime, animationLength);
                    break;
                default:
                    break;
            }
        }
        return animTime;
    }
}
