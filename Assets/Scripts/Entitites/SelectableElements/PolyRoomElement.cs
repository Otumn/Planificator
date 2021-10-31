using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyRoomElement : MonoBehaviour
{
    public bool isLooping = false;
    public float wallWidth = 0.4f;
    public GameObject wallPrefab;
    public GameObject knobPrefab;

    private Vector3[] worldPoints;
    private List<GameObject> roomParts;

    public void CreateRoom(Vector3[] points)
    {
        roomParts = new List<GameObject>();
        if(isLooping)
        {
            //TODO
        }
        else
        {
            for (int i = 0; i < points.Length - 1; i++) // place the walls
            {
                GameObject wall = GameObject.Instantiate(wallPrefab);
                wall.transform.position = points[i];
                wall.transform.rotation = Quaternion.LookRotation(points[i + 1] - points[i], Vector3.up);
                wall.transform.localScale = new Vector3(wallWidth, 1f, Vector3.Distance(points[i], points[i + 1]));
                wall.transform.parent = this.transform;
                roomParts.Add(wall);
            }

            for (int i = 1; i < points.Length - 1; i++) // place the knobs
            {
                GameObject knob = GameObject.Instantiate(knobPrefab);
                knob.transform.position = points[i];
                knob.transform.localScale = Vector3.one * wallWidth;
                knob.transform.parent = this.transform;
                roomParts.Add(knob);
            }
        }
    }
}
