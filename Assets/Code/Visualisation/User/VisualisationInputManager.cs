using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisationInputManager : MonoBehaviour {

    public bool canScroll = true;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.L))
        {
            CameraLook.instance.ToggleMouse(!CameraLook.instance.showMouse);
        }
        if(canScroll)
        {
            if(Input.mouseScrollDelta.y != 0)
            {
                BeatTimeSystem.Music.skipToTime = BeatTimeSystem.Music.time + BeatTimeSystem.BeatToRealTime(Input.mouseScrollDelta.y * (Input.GetKey(KeyCode.LeftShift) ? 4f : 1f));
                BeatTimeSystem.Music.executeSkipToTime = true;
            }
        }
	}
}
