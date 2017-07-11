using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInitView : EventView
{
    private Transform parent;
    private GameObject prefab;
    public void Init()
    {
        parent = GameObject.Find("SpawnerView").transform;
        CreateHideSpawners();
    }

    private void CreateHideSpawners()
    {
        for (int i = 0; i < 500; i++)
        {
            prefab = PoolManager.Instance.GetObject("Perfabs/Cube");
            prefab.transform.SetParent(parent);
            prefab.transform.localScale = Vector3.one;
            prefab.transform.localPosition = Vector3.zero;
            prefab.transform.localRotation = Quaternion.identity;
            prefab.name = "_" + i;
        }
        PoolManager.Instance.HideAllObject("Perfabs/Cube");
    }
}
