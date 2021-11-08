using System.Collections;
using System.Collections.Generic;
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
    private UnityAction callLayerUIUpdate;

    public void AddLayer()
    {
        Transform bufferedAddButton = contentLayerBox.GetChild(contentLayerBox.childCount - 1);
        bufferedAddButton.SetParent(transform, false);
        contentLayerBox.sizeDelta = new Vector2(contentLayerBox.rect.width, contentLayerBox.rect.height + uIHeightPerLayer);

        GameObject newLayerGO = GameObject.Instantiate(layerUIPrefab);
        newLayerGO.transform.SetParent(contentLayerBox, false);
        bufferedAddButton.SetParent(contentLayerBox, false);

        Layer newLayer = new Layer();
        newLayer.name = "Layer " + layers.Count.ToString();
        newLayer.sortingIndex = layers.Count;
        newLayer.iDIndex = layers.Count;
        layers.Add(newLayer);

        newLayerGO.GetComponent<LayerUI>().linkedLayer = newLayer;
        newLayerGO.GetComponent<LayerUI>().UpdateLayerUIInfos();
    }

    public void ReArrangeLayers(LayerUI askingLayer)
    {
        // clamp asking index

        askingLayer.linkedLayer.sortingIndex = Mathf.Clamp(askingLayer.linkedLayer.sortingIndex, 0, layers.Count - 1);

        // check if another layer has the same index, if yes take that layer index and + 1

        bool shouldInc = false;

        for (int i = 0; i < layers.Count; i++)
        {
            if (i == askingLayer.linkedLayer.iDIndex) continue;

            if(layers[i].sortingIndex == askingLayer.linkedLayer.sortingIndex)
            {
                shouldInc = true;
            }
            if(shouldInc) layers[i].sortingIndex += 1;
        }
        callLayerUIUpdate.Invoke();

        // empty the layers content

        Transform[] children = new Transform[contentLayerBox.childCount - 1];
        Transform addButton = contentLayerBox.GetChild(contentLayerBox.childCount - 1);

        for (int i = 0; i < contentLayerBox.childCount - 2; i++)
        {
            children[i] = contentLayerBox.GetChild(i);
        }

        contentLayerBox.DetachChildren();

        // re add the layers in order

        contentLayerBox.sizeDelta = new Vector2(contentLayerBox.rect.width, uIHeightPerLayer);

        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetParent(contentLayerBox, false);
            contentLayerBox.sizeDelta = new Vector2(contentLayerBox.rect.width, contentLayerBox.rect.height + uIHeightPerLayer);
        }

        addButton.SetParent(contentLayerBox, false);
    }

    public void DeleteLayer(int index)
    {

    }

    public void HideAllLayers()
    {

    }

    public float GetCurrentLayerYValue()
    {
        return 0;
    }

    #region Entity calls

    public override void OnManagersInitialized()
    {
        base.OnManagersInitialized();
    }

    #endregion

    public UnityAction CallLayerUIUpdate { get => callLayerUIUpdate; set => callLayerUIUpdate = value; }

}

public class Layer
{
    public string name = "Layer";
    public int sortingIndex = -1;
    public int iDIndex = -1;
}