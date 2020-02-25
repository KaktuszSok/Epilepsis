using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualisationInfoDisplay : MonoBehaviour {

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "BeatTime: " + BeatTimeSystem.time +
            "\nRealTime: " + BeatTimeSystem.Music.time +
            "\nBPM: " + BeatTimeSystem.BPM +
            "\nTimeScale: " + BeatTimeSystem.TimeScale.ToString("##0.0###########") + "x";
    }
}
