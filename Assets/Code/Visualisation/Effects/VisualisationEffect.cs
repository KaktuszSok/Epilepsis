using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisualisationEffect : MonoBehaviour {

	public virtual void Visualise()
    {
        return;
    }

    public virtual void Abort()
    {
        return;
    }

    protected void OnEnable()
    {
        Visualise();
    }
    protected void OnDisable()
    {
        Abort();
    }
}
