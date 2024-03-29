﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager
{
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolManager();
            }
            return instance;
        }
    }
    private Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();
    private PoolManager() { }
    /// <summary>
    /// poolname resoult 
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public GameObject GetObject(string poolName)
    {
        if (!poolDict.ContainsKey(poolName))
        {
            poolDict.Add(poolName, new ObjectPool());
        }
        ObjectPool pool = poolDict[poolName];
        return pool.GetObject(poolName);
    }

    public void HideObjet(GameObject go)
    {
        foreach (ObjectPool p in poolDict.Values)
        {
            if (p.Contains(go))
            {
                p.HideObject(go);
                return;
            }
        }
    }

    public void HideAllObject(string poolName)
    {
        if (!poolDict.ContainsKey(poolName))
        {
            return;
        }
        ObjectPool pool = poolDict[poolName];
        pool.HideAllObject();
    }
}
