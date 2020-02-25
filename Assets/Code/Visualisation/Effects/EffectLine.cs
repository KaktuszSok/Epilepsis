using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EffectLine : VisualisationEffect {

    LineRenderer Rend;
    public float quality = 0.25f; //how dense are the points?
    public int endSmoothing = 0;
    public int cornerSmoothing = 0;
    public int drawOrder = 0;

    //all coords in spherical
    public Vector3 startPos = new Vector3(0, 0, 10);
    public Vector3 endPos = new Vector3(0, 90, 10);
    public float startWidth = 0.25f;
    public float endWidth = 0.25f;
    public bool useWidthCurve = false;
    public AnimationCurve widthCurve;

    public Gradient colourGradient = new Gradient();

    void Awake()
    {
        Rend = GetComponentInChildren<LineRenderer>();
    }

    public override void Visualise()
    {
        //positions
        UpdateLineShape();
        //quality
        Rend.numCapVertices = endSmoothing;
        Rend.numCornerVertices = cornerSmoothing;
        //other visuals
        Rend.startWidth = startWidth;
        if (!useWidthCurve)
        {
            Rend.endWidth = endWidth;
            Rend.colorGradient = colourGradient;
        }
        else
        {
            Rend.widthCurve = widthCurve;
            Rend.widthMultiplier = startWidth;
        }
        Rend.sortingOrder = drawOrder;
    }

    public void UpdateLineShape()
    {
        Vector3[] positions = GenerateCartesianCoords();
        Rend.positionCount = positions.Length;
        Rend.SetPositions(positions);
    }

    public Vector3[] GenerateCartesianCoords()
    {
        List<Vector3> positions = new List<Vector3>();
        Vector3 currPos = startPos;
        int tries = 0;
        while (currPos != endPos && tries < 10000)
        {
            if (tries == 9999) { positions.Add(SphericalSpace.SphericalToCartesian(endPos)); break; } //Make line go straight to the endPos on the last try if it hasn't reached it yet
            positions.Add(SphericalSpace.SphericalToCartesian(currPos)); //add cartesian coord to list
            currPos = SphericalSpace.CurveTowards(currPos, endPos, 1 / quality); //adjust position
            tries++;
        }
        positions.Add(SphericalSpace.SphericalToCartesian(currPos)); //add last coord to list

        return positions.ToArray();
    }

    public override void Abort()
    {
        Rend.SetPositions(new Vector3[0] { }); //clear positions
    }
}
