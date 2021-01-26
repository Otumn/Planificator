using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Entity
{
    public Camera cam;
    public float panSpeed = 0.01f;
    public float zoomRate = 1;
    public float maxZoom = 50f;

    private bool isMovingGizmo = false;
    private SelectableGizmo gizmo;

    protected override void Update()
    {
        base.Update();
        MovementManagement();
        ElementSelectionManagement();
        GizmoSelectionManagement();
    }

    private void MovementManagement()
    {
        if(Input.mouseScrollDelta.y != 0f)
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (-Input.mouseScrollDelta.y * zoomRate), 0.5f, maxZoom);
        }

        if(Input.GetMouseButton(2))
        {
            transform.position += new Vector3(-Input.GetAxis("Mouse X") * panSpeed * cam.orthographicSize, 0f, -Input.GetAxis("Mouse Y") * panSpeed * cam.orthographicSize);
        }
    }

    private void ElementSelectionManagement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<SelectableElement>() != null && hit.collider.gameObject.GetComponent<SelectableElement>() != SelectedEntity)
                {
                    SelectableElement clickedEnt = hit.collider.gameObject.GetComponent<SelectableElement>();
                    if(SelectedEntity != null && clickedEnt != SelectedEntity)
                    {
                        SelectedEntity.UnSelect();
                    }
                    clickedEnt.Select();
                }
            }
            else
            {
                if(SelectedEntity != null)
                {
                    SelectedEntity.UnSelect();
                }
            }
        }
    }

    private void GizmoSelectionManagement()
    {
        if (Input.GetMouseButtonDown(0) && !isMovingGizmo)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<SelectableGizmo>() != null)
                {
                    gizmo = hit.collider.gameObject.GetComponent<SelectableGizmo>();
                    gizmo.OnGizmoDown();
                    isMovingGizmo = true;
                }
            }
        }
        
        if(isMovingGizmo)
        {
            gizmo.OnGizmoMoved();
        }
        
        if(Input.GetMouseButtonUp(0) && isMovingGizmo)
        {
            gizmo.OnGizmoUp();
            gizmo = null;
            isMovingGizmo = false;
        }
    }

    private SelectableElement SelectedEntity { get => GameManager.gameInstance.SelectedEntity; set => GameManager.gameInstance.SelectedEntity = value; }

}
