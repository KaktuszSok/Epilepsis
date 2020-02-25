using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource audioSource;

    public float volume = 1f;
    public float pitch = 1f;

    public float time = 0f;
    public float deltaTime = 0f;
    public float skipToTime = 0f;
    public bool executeSkipToTime = false;

    public void ApplySettings()
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;
    }

	void Update () {
        if(executeSkipToTime)
        {
            audioSource.time = Mathf.Clamp(skipToTime, 0, audioSource.clip.length - 0.01f);
            executeSkipToTime = false;
        }
        float oldTime = time;
        time = audioSource.time;
        deltaTime = time - oldTime;
	}
}
