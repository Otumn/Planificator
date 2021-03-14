using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : Entity
{
    public MeshRenderer bGPlane;
    public GameObject lineParent;
    public GameObject linesPrefab;
    public Material linesMaterial;

    private List<GameObject> horizontalLines;
    private List<GameObject> verticalLines;
    private Vector3 originalBGPlaneScale;

    protected override void Start()
    {
        base.Start();
        originalBGPlaneScale = bGPlane.transform.localScale;
        lineParent.transform.parent = null;
        linesMaterial = linesPrefab.GetComponentInChildren<Renderer>().sharedMaterial;
        horizontalLines = new List<GameObject>();
        verticalLines = new List<GameObject>();
    }

    public override void OnManagersInitialized()
    {
        base.OnManagersInitialized();
        DrawLines(GameManager.sceneParameters.moveSnap);
    }

    private void DrawLines(float spacing)
    {
        float height = GameManager.camController.Height*2;
        float width = GameManager.camController.Width*2;
        //Debug.Log("Width : " + width + " Height : " + height);

        //horizontal lines
        int nbHori = Mathf.RoundToInt(height / spacing) + 3;
        Vector3 startingPos = new Vector3(lineParent.transform.position.x - (width * 0.5f) - (spacing * 3f), lineParent.transform.position.y + 0.5f, lineParent.transform.position.z - (height * 0.5f) - spacing); 
        // TODO : optimize this? v
        for (int i = 0; i < horizontalLines.Count; i++)
        {
            GameObject.Destroy(horizontalLines[i]);
        }
        horizontalLines.Clear();
        for (int i = 0; i < nbHori; i++)
        {
            GameObject line = GameObject.Instantiate(linesPrefab, GameManager.sceneParameters.GetSnappedPosition(startingPos + new Vector3(0, 0, spacing * i)), Quaternion.identity);
            line.transform.localScale = new Vector3(width + (spacing * 6), 1, 0.1f); // TODO : Replace the 0.1f with a dynamic value depending on camera ratio
            line.transform.parent = lineParent.transform;
            horizontalLines.Add(line);
        }


        //vertical lines
        int nbVerti = Mathf.RoundToInt(width / spacing) + 3;
        startingPos = new Vector3(lineParent.transform.position.x - (width * 0.5f) - spacing, lineParent.transform.position.y + 0.5f, lineParent.transform.position.z - (height * 0.5f) - (spacing * 3f));
        // TODO : optimize this? v
        for (int i = 0; i < verticalLines.Count; i++)
        {
            GameObject.Destroy(verticalLines[i]);
        }
        verticalLines.Clear();
        for (int i = 0; i < nbVerti; i++)
        {
            GameObject line = GameObject.Instantiate(linesPrefab, GameManager.sceneParameters.GetSnappedPosition(startingPos + new Vector3(spacing * i, 0, 0)), Quaternion.Euler(0, -90, 0));
            line.transform.localScale = new Vector3(height + (spacing * 6), 1, 0.1f); // TODO : Replace the 0.1f with a dynamic value depending on camera ratio
            line.transform.parent = lineParent.transform;
            horizontalLines.Add(line);
        }

    }

    public void ScaleBackground(float ratio)
    {
        bGPlane.transform.localScale = originalBGPlaneScale * ratio;
        DrawLines(GameManager.sceneParameters.moveSnap);
    }

    public void MoveBackground()
    {
        lineParent.transform.position = GameManager.sceneParameters.GetSnappedPosition(new Vector3(transform.position.x, -4, transform.position.z));
    }

}
