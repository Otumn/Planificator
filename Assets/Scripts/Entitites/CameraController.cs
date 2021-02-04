using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Entity
{
    public Camera cam;
    public float panSpeed = 0.01f;
    public float zoomRate = 1;
    public float maxZoom = 50f;

    protected override void Update()
    {
        base.Update();
        MovementManagement();
        CurrentToolControl();
    }

    private void CurrentToolControl()
    {
        if(CurrentTool != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                CurrentTool.ToolLeftClickDownAction();
            }
            if(Input.GetMouseButton(0))
            {
                CurrentTool.ToolLeftClickHeldAction();
            }
            if(Input.GetMouseButtonUp(0))
            {
                CurrentTool.ToolLeftClickUpAction();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentTool.ToolSpaceBarAction();
            }
        }
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

    public RaycastHit ClicRaycast()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    private SelectableElement SelectedEntity { get => GameManager.gameInstance.SelectedEntity; set => GameManager.gameInstance.SelectedEntity = value; }
    private Tool CurrentTool { get => GameManager.toolsManager.CurrentTool; set => GameManager.toolsManager.CurrentTool = value; }

}
