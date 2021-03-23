using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoDrawing : Entity
{
    public GameObject linePrefab;
    public GameObject pointPrefab;

    private List<GameObject> currentDrawings = new List<GameObject>();

    public void DrawLine(Vector3 start, Vector3 end, Color color, float width)
    {
        GameObject line = GameObject.Instantiate(linePrefab, 
            Vector3.Lerp(start, end, 0.5f), 
            Quaternion.LookRotation((end - start), Vector3.up));
        line.transform.localScale = new Vector3(width, 0.2f, Vector3.Distance(start, end));
        line.GetComponent<Renderer>().material.SetColor("MainColor", color);
        currentDrawings.Add(line);
    }

    public void DrawPoint(Vector3 pos, Color color, float diameter)
    {
        GameObject point = GameObject.Instantiate(pointPrefab, pos, Quaternion.identity);
        point.transform.localScale *= diameter;
        point.GetComponent<Renderer>().material.SetColor("MainColor", color);
        currentDrawings.Add(point);
    }

    public void CleanAllDrawings()
    {
        for (int i = 0; i < currentDrawings.Count; i++)
        {
            GameObject.Destroy(currentDrawings[i]);
        }
        currentDrawings.Clear();
    }
}
