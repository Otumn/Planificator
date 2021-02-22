using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParameters : Entity
{
    public float moveSnap = 0.25f;
    public float rotateSnap = 15f;
    public float scaleSnap = 0.5f;
    public bool snapping = true;

    protected override void Start()
    {
        base.Start();
    }

    public Vector3 GetSnappedPosition(Vector3 worldPosition)
    {
        Vector3 snappedVector = new Vector3();
        snappedVector.x = Mathf.Round(worldPosition.x / moveSnap) * moveSnap;
        snappedVector.y = Mathf.Round(worldPosition.y / moveSnap) * moveSnap;
        snappedVector.z = Mathf.Round(worldPosition.z / moveSnap) * moveSnap;
        return snappedVector;
    }

    public Vector3 GetSnappedPosition(Vector3 worldPosition, float snapValue)
    {
        Vector3 snappedVector = new Vector3();
        snappedVector.x = Mathf.Round(worldPosition.x / snapValue) * snapValue;
        snappedVector.y = Mathf.Round(worldPosition.y / snapValue) * snapValue;
        snappedVector.z = Mathf.Round(worldPosition.z / snapValue) * snapValue;
        return snappedVector;
    }
}
