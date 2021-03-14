using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Entity
{
    public Camera cam;
    public float panSpeed = 0.01f;
    public float zoomRate = 1;
    public float maxZoom = 50f;

    private float camOriginOrthoSize;

    private float height;
    private float width;
    private Vector3 mousePosOnWheelDown;
    private Vector3 camPosOnWheelDown;

    protected override void Start()
    {
        base.Start();
        camOriginOrthoSize = cam.orthographicSize;
    }

    protected override void Update()
    {
        base.Update();
        MovementManagement();
    }
    
    private void MovementManagement()
    {
        if(Input.mouseScrollDelta.y != 0f)
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (-Input.mouseScrollDelta.y * zoomRate), 0.5f, maxZoom);
            height = cam.orthographicSize;
            width = height * cam.aspect;
            GameManager.bgManager.ScaleBackground(CamOrthoRatio);
        }

        if(Input.GetMouseButtonDown(2))
        {
            mousePosOnWheelDown = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            camPosOnWheelDown = transform.position;
        }

        if(Input.GetMouseButton(2))
        {
            //transform.position += new Vector3(-Input.GetAxis("Mouse X") * panSpeed * cam.orthographicSize, 0f, -Input.GetAxis("Mouse Y") * panSpeed * cam.orthographicSize);
            float panDist = Vector3.Distance(mousePosOnWheelDown, new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y));
            Vector3 panDir = (new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - mousePosOnWheelDown).normalized;
            transform.position = camPosOnWheelDown + (-panDir * panDist * panSpeed * CamOrthoRatio);
            GameManager.bgManager.MoveBackground();
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
    private float CamOrthoRatio { get => (cam.orthographicSize / camOriginOrthoSize); }
    public float Height { get => height; }
    public float Width { get => width; }
}
