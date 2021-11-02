using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyRoomElement : SelectableElement
{
    public bool isLooping = false;
    public float wallWidth = 0.4f;
    public GameObject wallPrefab;
    public GameObject knobPrefab;

    private Vector3[] worldPoints;
    private List<SelectableElement> roomParts;

    public void CreateRoom(Vector3[] points)
    {
        // TODO : delete the old roomParts. This will be done when the object option sytem will come into place.
        roomParts = new List<SelectableElement>();
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
                wall.GetComponent<SelectableElement>().parentElement = this;
                roomParts.Add(wall.GetComponent<SelectableElement>());
            }

            for (int i = 1; i < points.Length - 1; i++) // place the knobs
            {
                GameObject knob = GameObject.Instantiate(knobPrefab);
                knob.transform.position = points[i];
                knob.transform.localScale = Vector3.one * wallWidth;
                knob.transform.parent = this.transform;
                knob.GetComponent<SelectableElement>().parentElement = this;
                roomParts.Add(knob.GetComponent<SelectableElement>());
            }
        }
    }

    #region Selectable element override

    public override void DisplaySelectionFeedback()
    {
        for (int i = 0; i < roomParts.Count; i++)
        {
            roomParts[i].DisplaySelectionFeedback();
        }
    }

    public override void HideSelectionFeedback()
    {
        for (int i = 0; i < roomParts.Count; i++)
        {
            roomParts[i].HideSelectionFeedback();
        }
    }

    #endregion
}
