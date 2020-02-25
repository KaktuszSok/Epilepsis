using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTimeSystem : MonoBehaviour {

    public static MusicPlayer Music;

    public static float time = 0f;
    public static float deltaTime = 0.1f;

    public static float BPM = 175f;
    public static float TimeScale = 1f;
    public float TimeOffset = 0f;
    public float editor_BPMControl = 175f;
    public float editor_TimeScaleControl = 1f;
    public bool editor_ClickToApplyBPM = false;

    private void Awake()
    {
        Music = GetComponent<MusicPlayer>();
    }

    private void Update()
    {
        if(editor_ClickToApplyBPM)
        {
            editor_ClickToApplyBPM = false;
            BPM = editor_BPMControl;
            TimeScale = editor_TimeScaleControl;
            Music.pitch = TimeScale;
            Music.ApplySettings();
        }
        float oldTime = time;
        time = RealToBeatTime(Music.time + TimeOffset);
        deltaTime = time - oldTime;
    }

    public static float RealToBeatTime(float realTime)
    {
        return realTime * (BPM / 60f);
    }

    public static float BeatToRealTime(float beatTime)
    {
        return beatTime / (BPM / 60f);
    }
}
