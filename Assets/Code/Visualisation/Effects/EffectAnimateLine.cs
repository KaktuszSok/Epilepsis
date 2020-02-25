using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RepeatType
{
    NONE,
    DISAPPEAR,
    LOOP,
    PINGPONG
}

public class EffectAnimateLine : AnimatedEffect {

    private EffectLine Line;

    public Vector3 finalStartPos;
    public Vector3 finalEndPos;
    private Vector3 initialStartPos;
    private Vector3 initialEndPos;

    public float animationHz = 60f;
    float nextFrameTimer = 0f;
    float startTime = 0f;
    float elapsedTime = 0f;

    private void Awake()
    {
        Line = GetComponent<EffectLine>();
        initialStartPos = Line.startPos;
        initialEndPos = Line.endPos;
    }

    public override void Visualise()
    {
        doAnimate = true;
        nextFrameTimer = 1 / animationHz;
        startTime = BeatTimeSystem.time;
        elapsedTime = 0f;
    }

    public override void Abort()
    {
        doAnimate = false;
    }

    private void Update()
    {
        if (doAnimate)
        {
            if (nextFrameTimer > 0)
            {
                nextFrameTimer -= Mathf.Max(BeatTimeSystem.Music.deltaTime, 0); //frames are updated per normal time, not BPM time. If time moved backwards, do not add time until next frame.
            }
            else
            {
                while (nextFrameTimer <= 0)
                {
                    UpdateFrame();
                    nextFrameTimer += 1 / animationHz;
                }
            }
        }
    }

    void UpdateFrame()
    {
        if (animationLength == 0) return;

        elapsedTime = BeatTimeSystem.time - startTime;
        float animTime = GetAdjustedTime(elapsedTime, true);

        Line.startPos = Vector3.Lerp(initialStartPos, finalStartPos, animTime / (animationLength - restTime));
        Line.endPos = Vector3.Lerp(initialEndPos, finalEndPos, animTime / (animationLength - restTime));
        Line.UpdateLineShape();
    }
}
