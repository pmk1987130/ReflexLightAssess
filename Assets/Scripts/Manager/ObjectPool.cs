using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class ObjectPool
{
   // private string prefabname;
    private GameObject Prefab;
    private int MaxCount = 1000000;
    private List<GameObject> PrefabList = new List<GameObject>();
    public ObjectPool() { }
    public bool Contains(GameObject go)
    {
        return PrefabList.Contains(go);
    }
    public GameObject GetObject(string name)
    {
       // prefabname = name;
        GameObject go = null;
        for (int i = 0; i < PrefabList.Count; i++)
        {
            if (!PrefabList[i].activeSelf)
            {
                go = PrefabList[i];
                go.SetActive(true);
                break;
            }
        }

        if (go == null)
        {
            if (PrefabList.Count >= MaxCount)
            {
                GameObject.Destroy(PrefabList[0]);
                PrefabList.RemoveAt(0);
            }
            Prefab = ResManager.Instance.LoadPrefab(name) as GameObject;
            go = GameObject.Instantiate<GameObject>(Prefab);
            PrefabList.Add(go);
        }
        go.SendMessage("BeforeGetObject", SendMessageOptions.DontRequireReceiver);
        return go;
    }
    public void HideObject(GameObject go)
    {
        if (PrefabList.Contains(go))
        {
            go.SetActive(false);
            go.SendMessage("BeforeHideObject", SendMessageOptions.DontRequireReceiver);
        }
    }
    public void HideAllObject()
    {
        for (int i = 0; i < PrefabList.Count; i++)
        {
            if (PrefabList[i].activeSelf)
                HideObject(PrefabList[i]);
        }
    }
}
