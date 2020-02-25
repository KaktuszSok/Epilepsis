using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EffectCartesianLine : VisualisationEffect {

    LineRenderer Rend;
    public int endSmoothing = 0;
    public int cornerSmoothing = 0;
    public int drawOrder = 0;

    //all coords in cartesian
    public Vector3[] positions = new Vector3[2];
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
        Rend.positionCount = positions.Length;
        Rend.SetPositions(positions);
    }

    public override void Abort()
    {
        Rend.SetPositions(new Vector3[0] { }); //clear positions
    }
}
