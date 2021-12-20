using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LayerManager : Entity
{
    public float uIHeightPerLayer = 27f;
    public RectTransform contentLayerBox;
    public GameObject layerUIPrefab;
    public Text currentLayerName;
    public float heightPerObject = 0.001f;

    private Layer currentLayer;
    private List<Layer> layers = new List<Layer>();

    public void AddLayer()
    {
        Transform bufferedAddButton = contentLayerBox.GetChild(contentLayerBox.childCount - 1);
        bufferedAddButton.SetParent(transform, false);
        contentLayerBox.sizeDelta = new Vector2(contentLayerBox.rect.width, contentLayerBox.rect.height + uIHeightPerLayer);

        GameObject newLayerGO = GameObject.Instantiate(layerUIPrefab);
        newLayerGO.transform.SetParent(contentLayerBox, false);
        bufferedAddButton.SetParent(contentLayerBox, false);
        LayerUI newUI = newLayerGO.GetComponent<LayerUI>();

        Layer newLayer = new Layer();
        newLayer.name = "Layer " + layers.Count.ToString();
        newLayer.sortingIndex = layers.Count;
        newLayer.iDIndex = layers.Count;
        newLayer.linkedUI = newUI;
        newUI.UpdateLayerUIInfos(newLayer);
        layers.Add(newLayer);

        if(layers.Count == 1)
        {
            SelectLayer(newUI);
        }
        else
        {
            newUI.SetLayerActive(false);
        }
    }

    public void ReArrangeLayers(LayerUI askingUI)
    {
        // Get the layer from the askingLayer LayerUI

        Layer askingLayer = GetLayerFromID(askingUI.LayerID);

        // clamp asking index

        askingLayer.sortingIndex = int.Parse(askingUI.indexInput.text);
        askingLayer.sortingIndex = Mathf.Clamp(askingLayer.sortingIndex, 0, layers.Count);

        // check if another layer has the same sorting index, if yes take that layer sorting index and + 1

        Layer testedLayer = askingLayer;

        for (int i = 0; i < layers.Count; i++)
        {
            if (layers[i].iDIndex == testedLayer.iDIndex) continue;

            if (layers[i].sortingIndex == testedLayer.sortingIndex)
            {
                layers[i].sortingIndex += 1;
                layers[i].linkedUI.UpdateLayerUIInfos(layers[i]);
                testedLayer = layers[i];
            }
        }

        // rearrange the layers' sorting IDs
        int[] ids = new int[layers.Count];

        for (int i = 0; i < ids.Length; i++)
        {
            ids[i] = layers[i].sortingIndex;
        }

        Layer[] tempLayers = layers.ToArray();

        Array.Sort(ids, tempLayers);

        // empty the layers content

        LayerUI[] children = new LayerUI[contentLayerBox.childCount - 1];
        for (int i = 0; i < children.Length; i++)
        {
            tempLayers[i].linkedUI = contentLayerBox.GetChild(i).GetComponent<LayerUI>();
            tempLayers[i].linkedUI.SetLayerActive(false);
            tempLayers[i].sortingIndex = i;
            tempLayers[i].linkedUI.UpdateLayerUIInfos(tempLayers[i]);
        }
        currentLayer.linkedUI.SetLayerActive(true);
    }

    public void ReArrangeLayers()
    {
        // rearrange the layers' sorting IDs
        int[] ids = new int[layers.Count];

        for (int i = 0; i < ids.Length; i++)
        {
            ids[i] = layers[i].sortingIndex;
        }

        Layer[] tempLayers = layers.ToArray();

        Array.Sort(ids, tempLayers);

        // empty the layers content

        LayerUI[] children = new LayerUI[contentLayerBox.childCount - 1];
        for (int i = 0; i < children.Length; i++)
        {
            tempLayers[i].linkedUI = contentLayerBox.GetChild(i).GetComponent<LayerUI>();
            tempLayers[i].sortingIndex = i;
            tempLayers[i].linkedUI.UpdateLayerUIInfos(tempLayers[i]);
        }
    }

    public void DeleteLayer(LayerUI askingUI)
    {
        int tempIndex = askingUI.LayerID;
        askingUI.transform.SetParent(null, false);
        if(currentLayer.iDIndex == askingUI.LayerID)
        {
            currentLayer = layers[0];
            currentLayer.linkedUI.SetLayerActive(true);
        }
        GameObject.Destroy(askingUI.gameObject);
        for (int i = 0; i < layers.Count; i++)
        {
            if(layers[i].iDIndex == tempIndex)
            {
                layers.Remove(layers[i]);
                break;
            }
        }
        ReArrangeLayers();
    }

    public void SelectLayer(LayerUI askingUI)
    {
        if(currentLayer != null)
        {
            currentLayer.linkedUI.SetLayerActive(false);
        }
        currentLayer = GetLayerFromID(askingUI.LayerID);
        currentLayerName.text = currentLayer.name;
        askingUI.SetLayerActive(true);
    }

    public void PlaceObjectInCurrentLayer(SelectableElement element)
    {
        element.transform.position = new Vector3(element.transform.position.x, GetCurrentLayerYValue(), element.transform.position.z);
        currentLayer.elements.Add(element);
        currentLayer.currentYValue += heightPerObject;
    }

    public void ToggleLayerVisibility(LayerUI askingUI, bool visible)
    {
        Layer l = GetLayerFromID(askingUI.LayerID);
        for (int i = 0; i < l.elements.Count; i++)
        {
            l.elements[i].gameObject.SetActive(visible);
        }
    }

    public void HideAllLayers()
    {

    }

    #region Utility

    public Layer GetLayerFromID(int id)
    {
        for (int i = 0; i < layers.Count; i++)
        {
            if (layers[i].iDIndex == id) return layers[i];
        }
        return null;
    }

    public float GetCurrentLayerYValue()
    {
        return currentLayer.currentYValue + currentLayer.sortingIndex;
    }

    public bool HasCurrentLayer()
    {
        return !(currentLayer == null);
    }

    #endregion

    #region Entity calls

    public override void OnManagersInitialized()
    {
        base.OnManagersInitialized();
    }

    #endregion

}

public class Layer
{
    public string name = "Layer";
    public int sortingIndex = -1;
    public int iDIndex = -1;
    public LayerUI linkedUI; // this may an easier solution actually. When loading a save file, I'll juste have to count the number layer loaded, then give them each a UI, then update them, and boom.
    public float currentYValue = 0f;
    public List<SelectableElement> elements = new List<SelectableElement>();
}