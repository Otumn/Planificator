using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoController : Entity
{
    public GizmoType currentType;
    public GameObject panGO;
    public GameObject rotateGO;
    public GameObject scaleGO;



}

public enum GizmoType
{
    Panning,
    Rotating,
    Scaling
};
