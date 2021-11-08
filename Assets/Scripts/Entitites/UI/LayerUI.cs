using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LayerUI : Entity
{
    public Layer linkedLayer;
    public TMP_InputField indexInput;
    public TMP_InputField nameInput;

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.layerManager.CallLayerUIUpdate += UpdateLayerUIInfos;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.layerManager.CallLayerUIUpdate -= UpdateLayerUIInfos;
    }

    public void UpdateLayerUIInfos()
    {
        indexInput.text = linkedLayer.sortingIndex.ToString();
        nameInput.text = linkedLayer.name;
    }

    public void SetLayerName()
    {
        linkedLayer.name = nameInput.text;
        UpdateLayerUIInfos();
    }

    public void SetLayerIndex()
    {
        linkedLayer.sortingIndex = int.Parse(indexInput.text);
        UpdateLayerUIInfos();
        GameManager.layerManager.ReArrangeLayers(this);
    }

    public void DeleteLayer()
    {

    }
}
