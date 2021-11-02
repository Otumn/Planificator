using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerUI : Entity
{
    public GameObject layerPrefab;
    public float contentheightPerRow = 27f;

    public void AddLayer()
    {

    }

    private LayerManager layerManager { get => GameManager.layerManager; }
}
