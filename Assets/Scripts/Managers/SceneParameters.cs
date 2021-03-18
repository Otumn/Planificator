using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParameters : Entity
{
    private float moveSnap = 0.5f;
    private float rotateSnap = 15f;
    private float scaleSnap = 0.5f;
    private bool snapping = true;

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
                snappedVector.x = Mathf.Round(worldPosition.x / MoveSnap) * MoveSnap;
                snappedVector.y = Mathf.Round(worldPosition.y / MoveSnap) * MoveSnap;
                snappedVector.z = Mathf.Round(worldPosition.z / MoveSnap) * MoveSnap;
                break;

            case SnapType.Floored:
                snappedVector.x = Mathf.Floor(worldPosition.x / MoveSnap) * MoveSnap;
                snappedVector.y = Mathf.Floor(worldPosition.y / MoveSnap) * MoveSnap;
                snappedVector.z = Mathf.Floor(worldPosition.z / MoveSnap) * MoveSnap;
                break;

            case SnapType.Ceilled:
                snappedVector.x = Mathf.Ceil(worldPosition.x / MoveSnap) * MoveSnap;
                snappedVector.y = Mathf.Ceil(worldPosition.y / MoveSnap) * MoveSnap;
                snappedVector.z = Mathf.Ceil(worldPosition.z / MoveSnap) * MoveSnap;
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

    public float GetSnappedRotation(float yRotation)
    {
        float snappedFloat = 0f;
        snappedFloat = Mathf.Round(yRotation / rotateSnap) * rotateSnap;
        return snappedFloat;
    }

    public void SetMoveSnap(float snap)
    {
        moveSnap = snap;
        GameManager.gameInstance.CallOnMoveSnapSet(snap);
    }

    public void SetRotSnap(float snap)
    {
        rotateSnap = snap;
        GameManager.gameInstance.CallOnRotSnapSet(snap);
    }

    public void SetSnapping(bool snap)
    {
        snapping = snap;
        GameManager.gameInstance.CallOnSnapSet(snap);
    }

    public float MoveSnap { get => moveSnap; }
    public float RotateSnap { get => rotateSnap; }
    public float ScaleSnap { get => scaleSnap; }
    public bool Snapping { get => snapping; }
}

public enum SnapType
{
    Rounded,
    Floored,
    Ceilled
};
