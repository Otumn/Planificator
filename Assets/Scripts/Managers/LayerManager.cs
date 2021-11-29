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
            tempLayers[i].sortingIndex = i;
            tempLayers[i].linkedUI.UpdateLayerUIInfos(tempLayers[i]);
        }
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

    }

    public void HideLayer(LayerUI askingUI)
    {

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
        return 0;
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
}