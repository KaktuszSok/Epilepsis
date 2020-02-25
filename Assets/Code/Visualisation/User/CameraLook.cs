using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public static CameraLook instance;

    public float sensitivity = 10f;
    [SerializeField]
    Vector3 camRot = Vector3.zero;
    public bool canLook { get; private set; }
    public bool showMouse { get; private set; }

    public bool canFly = false;
    public float flySpeed = 10;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        ToggleMouse(showMouse);
        canLook = true;
	}
	
	void Update () {
		if(canLook && !showMouse)
        {
            Vector3 camRotDelta = new Vector3(-Input.GetAxisRaw("Mouse Y")*sensitivity, Input.GetAxisRaw("Mouse X")*sensitivity, 0);
            if (camRotDelta.x != 0 || camRotDelta.y != 0)
            {
                camRot = new Vector3(
                    Mathf.Clamp(camRot.x + camRotDelta.x, -90, 90), //Keep up/down between straight down and straight up
                    Mathf.Repeat(camRot.y + camRotDelta.y + 180, 360) - 180, //Loop axis between -180 and 180
                    Mathf.Repeat(camRot.z + camRotDelta.z + 180, 360) - 180); //same^
                UpdateTransformRot();
            }

            if(canFly)
            {
                Vector3 flyVel = Vector3.zero;
                flyVel.x = Input.GetAxisRaw("Horizontal")*flySpeed;
                flyVel.z = Input.GetAxisRaw("Vertical")*flySpeed;
                if (Input.GetKey(KeyCode.E)) flyVel.y += flySpeed;
                else if (Input.GetKey(KeyCode.Q)) flyVel.y -= flySpeed;
                if (Input.GetKey(KeyCode.LeftShift)) flyVel *= 4f;
                transform.Translate(flyVel*Time.deltaTime, Space.Self);
            }

            if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = Vector3.zero;
                transform.eulerAngles = Vector3.zero;
            }
            if(Input.GetKeyDown(KeyCode.C) & Input.GetKey(KeyCode.LeftShift))
            {
                canFly = !canFly;
            }
        }
	}

    public void SetLookRot(Vector3 rot)
    {
        camRot = rot;
        UpdateTransformRot();
    }

    void UpdateTransformRot() //Updates the Camera's GameObject rotation to be camRot
    {
        transform.localEulerAngles = camRot;
    }

    public void SetCanLook(bool can) //Can user look around?
    {
        canLook = can;
    }

    public void ToggleMouse(bool show) //Is the cursor visible?
    {
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = show;
        showMouse = show;
    }
}
