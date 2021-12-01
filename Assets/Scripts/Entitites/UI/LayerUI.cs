using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LayerUI : Entity
{
    public TMP_InputField indexInput;
    public TMP_InputField nameInput;
    public Image bgImage;
    public Color activeLayerColor;
    public Color inactiveLayerColor;

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

    public void AskForActive()
    {
        GameManager.layerManager.SelectLayer(this);
    }

    public void SetLayerActive(bool active)
    {
        if(active)
        {
            bgImage.color = activeLayerColor;
        }
        else
        {
            bgImage.color = inactiveLayerColor;
        }
    }

    public int LayerID { get => layerID;}
}
