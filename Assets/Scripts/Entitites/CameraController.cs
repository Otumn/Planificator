using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Entity
{
    public Camera cam;
    public MeshRenderer planeRenderer;
    public float panSpeed = 0.01f;
    public float zoomRate = 1;
    public float maxZoom = 50f;

    private Vector3 planeOriginScale;
    private float camOriginOrthoSize;

    protected override void Start()
    {
        base.Start();
        planeOriginScale = planeRenderer.transform.localScale;
        camOriginOrthoSize = cam.orthographicSize;
    }

    protected override void Update()
    {
        base.Update();
        MovementManagement();
        planeRenderer.material.SetVector("UVOffset", new Vector2(transform.position.x, transform.position.z));
        planeRenderer.transform.localScale = planeOriginScale * CamOrthoRatio;
    }

    private void MovementManagement()
    {
        if(Input.mouseScrollDelta.y != 0f)
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (-Input.mouseScrollDelta.y * zoomRate), 0.5f, maxZoom);
            planeRenderer.transform.localScale = planeOriginScale * CamOrthoRatio;
            //planeRenderer.material.SetFloat("UVLineTiling", /*moveSnape here==> */ 1 * (1 / CamOrthoRatio));

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
    private float CamOrthoRatio { get => (cam.orthographicSize / camOriginOrthoSize); }

}
