using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalDebug : MonoBehaviour {

    public bool coordDebug = false;

	void Start () {
		
	}
	
	void Update () {
		if(coordDebug)
        {
            Debug.Log(transform.name + " transform pos: " + transform.position);
            Vector3 sphericalPos = SphericalSpace.CartesianToSpherical(transform.position);
            Debug.Log(transform.name + " spherical pos: " + sphericalPos);
            Vector3 cartesianPos = SphericalSpace.SphericalToCartesian(sphericalPos);
            Debug.Log(transform.name + " cartesian pos: " + cartesianPos);
            coordDebug = false;
        }
	}
}
