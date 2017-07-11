using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ResManager {
    private static ResManager instance;
    public static ResManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResManager();
            }
            return instance;
        }
    }
    private Dictionary<string, UnityEngine.Object> loadedPrefabDict = new Dictionary<string, UnityEngine.Object>();

    public UnityEngine.Object LoadPrefab(string prefabName)
    {
        if (String.IsNullOrEmpty(prefabName))
            return null;
        else if (loadedPrefabDict.ContainsKey(prefabName))
        {
            return loadedPrefabDict[prefabName];
        }
        else
        {
            UnityEngine.Object Prefab = Resources.Load(prefabName);
            loadedPrefabDict.Add(prefabName, Prefab);
            return loadedPrefabDict[prefabName];
        }
    }

   
    public void UnLoadPrefab(string prefabName)
    {
        if (loadedPrefabDict.ContainsKey(prefabName))
            return;
        else
        {
            Resources.UnloadAsset(loadedPrefabDict[prefabName]);
            loadedPrefabDict[prefabName] = null;
            loadedPrefabDict.Remove(prefabName);
        }
    }

     
    public void UnLoadAll()
    {
        foreach (KeyValuePair<string, UnityEngine.Object> kv in loadedPrefabDict)
        {
            loadedPrefabDict[kv.Key] = null;
        }
        loadedPrefabDict.Clear();
        Resources.UnloadUnusedAssets();
    }


}
