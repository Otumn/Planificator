using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        GameObject newLayerUI = GameObject.Instantiate(layerUIPrefab);
        newLayerUI.transform.SetParent(contentLayerBox, false);
        bufferedAddButton.SetParent(contentLayerBox, false);
    }

    public void DeleteLayer(int index)
    {

    }

    public void HideAllLayers()
    {

    }

    public void HideLayer(Layer layer)
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

}

public class Layer
{
    public string name = "Layer";
    public int index = -1;
}