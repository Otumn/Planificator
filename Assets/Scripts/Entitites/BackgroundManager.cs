using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : Entity
{
    public MeshRenderer bGPlane;

    private Vector3 originalBGPlaneScale;

    protected override void Start()
    {
        base.Start();
        originalBGPlaneScale = bGPlane.transform.localScale;
    }

    public void ScaleBackground(float ratio)
    {
        bGPlane.transform.localScale = originalBGPlaneScale * ratio;
    }
}
