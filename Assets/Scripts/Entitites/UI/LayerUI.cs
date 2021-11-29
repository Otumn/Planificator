using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LayerUI : Entity
{
    public TMP_InputField indexInput;
    public TMP_InputField nameInput;

    private int layerID = -1;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    public void UpdateLayerUIInfos(Layer layer)
    {
        indexInput.text = layer.sortingIndex.ToString();
        nameInput.text = layer.name;
        layerID = layer.iDIndex;
    }

    public void SetLayerName(Layer layer)
    {
        layer.name = nameInput.text;
    }

    public void SetLayerIndex()
    {

        GameManager.layerManager.ReArrangeLayers(this);
    }

    public void DeleteLayer()
    {
        GameManager.layerManager.DeleteLayer(this);
    }

    public int LayerID { get => layerID;}
}
