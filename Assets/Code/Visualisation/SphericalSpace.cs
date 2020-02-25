using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SphericalSpace {

    //Spherical Vector3:
    //X - Angle Right/Left in Degrees (Latitude)
    //Y - Angle Up/Down in Degrees (Longitude)
    //Z - Radius

	public static Vector3 CartesianToSpherical(Vector3 cartesian)
    {
        if (cartesian == Vector3.zero) return Vector3.zero;
        float mag = cartesian.magnitude;
        return new Vector3(
            Mathf.Atan2(cartesian.x, cartesian.z)*Mathf.Rad2Deg,
            -Mathf.Acos(cartesian.y/mag)*Mathf.Rad2Deg + 90f, //Invert and add 90 deg so that 0 is straight ahead instead of straight up and so up is + and down is -
            mag);
    }

    public static Vector3 SphericalToCartesian(Vector3 spherical)
    {
        if (spherical.z == 0) return Vector3.zero;
        spherical.y = -spherical.y + 90f; //reverse manipulations done above, for calculations
        float sinY = Mathf.Sin(spherical.y*Mathf.Deg2Rad);
        return new Vector3(
            spherical.z * sinY * Mathf.Sin(spherical.x * Mathf.Deg2Rad),
            spherical.z * Mathf.Cos(spherical.y * Mathf.Deg2Rad),
            spherical.z * sinY * Mathf.Cos(spherical.x * Mathf.Deg2Rad));
    }

    public static Vector3 CurveTowards(Vector3 from, Vector3 to, float maxDistanceDelta)
    {
        return Vector3.MoveTowards(from, to, maxDistanceDelta);
    }
}
