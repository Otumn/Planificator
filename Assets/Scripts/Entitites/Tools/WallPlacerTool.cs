using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacerTool : Tool
{
    public GameObject wallPrefab;

    public override void ToolLeftClickDownAction()
    {
        base.ToolLeftClickDownAction();
        GameObject wall = GameObject.Instantiate(wallPrefab, GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        wall.transform.position = new Vector3(wall.transform.position.x, 0, wall.transform.position.z);
    }

}
