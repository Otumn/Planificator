using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPart : Entity
{
    public MeshRenderer plane;
    public float distBeforeUpdate = 5f;

    private Vector3 startScale;
    private float xSign = 0f;
    private float zSign = 0f;

    protected override void Start()
    {
        base.Start();
        plane.transform.parent = null;
        startScale = plane.transform.localScale;
        if(transform.localPosition.x != 0) xSign = Mathf.Sign(transform.position.x);
        if (transform.localPosition.y != 0) zSign = Mathf.Sign(transform.position.y);
    }

    protected override void Update()
    {
        base.Update();
        CheckForUpdate();
    }

    public void CheckForUpdate()
    {
        if(Vector3.Distance(transform.position, plane.transform.position) > distBeforeUpdate)
        {
            Vector3 snapped = GameManager.sceneParameters.GetSnappedPosition(transform.position, 1f);
            plane.transform.position = new Vector3(snapped.x, -4.99f, snapped.z);
        }
    }

    public void ScalePlane(float ratio)
    {
        plane.transform.localScale = startScale * ratio;
        transform.localPosition = GameManager.sceneParameters.GetSnappedPosition(new Vector3(plane.transform.localScale.x * xSign, plane.transform.localScale.z * zSign, 14f), 1f);
        plane.transform.position = transform.position;
    }

    public Material PlaneMaterial { get => plane.material; }
    public MeshRenderer Plane { get => plane; set => plane = value; }
}
