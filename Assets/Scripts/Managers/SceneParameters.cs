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

    public Vector3 GetSnappedPosition(Vector3 worldPosition, SnapType type)
    {
        Vector3 snappedVector = new Vector3();
        switch (type)
        {
            case SnapType.Rounded:
                snappedVector.x = Mathf.Round(worldPosition.x / moveSnap) * moveSnap;
                snappedVector.y = Mathf.Round(worldPosition.y / moveSnap) * moveSnap;
                snappedVector.z = Mathf.Round(worldPosition.z / moveSnap) * moveSnap;
                break;

            case SnapType.Floored:
                snappedVector.x = Mathf.Floor(worldPosition.x / moveSnap) * moveSnap;
                snappedVector.y = Mathf.Floor(worldPosition.y / moveSnap) * moveSnap;
                snappedVector.z = Mathf.Floor(worldPosition.z / moveSnap) * moveSnap;
                break;

            case SnapType.Ceilled:
                snappedVector.x = Mathf.Ceil(worldPosition.x / moveSnap) * moveSnap;
                snappedVector.y = Mathf.Ceil(worldPosition.y / moveSnap) * moveSnap;
                snappedVector.z = Mathf.Ceil(worldPosition.z / moveSnap) * moveSnap;
                break;
        }
        return snappedVector;
    }

    public Vector3 GetSnappedPosition(Vector3 worldPosition, SnapType type, float snapValue)
    {
        Vector3 snappedVector = new Vector3();
        switch(type)
        {
            case SnapType.Rounded:
                snappedVector.x = Mathf.Round(worldPosition.x / snapValue) * snapValue;
                snappedVector.y = Mathf.Round(worldPosition.y / snapValue) * snapValue;
                snappedVector.z = Mathf.Round(worldPosition.z / snapValue) * snapValue;
                break;

            case SnapType.Floored:
                snappedVector.x = Mathf.Floor(worldPosition.x / snapValue) * snapValue;
                snappedVector.y = Mathf.Floor(worldPosition.y / snapValue) * snapValue;
                snappedVector.z = Mathf.Floor(worldPosition.z / snapValue) * snapValue;
                break;

            case SnapType.Ceilled:
                snappedVector.x = Mathf.Ceil(worldPosition.x / snapValue) * snapValue;
                snappedVector.y = Mathf.Ceil(worldPosition.y / snapValue) * snapValue;
                snappedVector.z = Mathf.Ceil(worldPosition.z / snapValue) * snapValue;
                break;
        }
        return snappedVector;
    }
}

public enum SnapType
{
    Rounded,
    Floored,
    Ceilled
};
