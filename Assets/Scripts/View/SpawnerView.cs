using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : EventView
{
    public Action<Vector3> SetRobotCenterPos;
    public Action<Vector3> SetPoints;
    public Func<Vector3, bool> IsContainPos;
    private Vector3 firstPos;
    private Vector3 previousPos;
    private Vector3 currentPos;
    private float cubeLength = 1.0f;
    private float distance = 0;
    private bool isRecord = false;
    private GameObject prefab;
    private List<Vector3> positons=new List<Vector3>();
    void Update()
    {
        if (isRecord)
        {
            distance = Vector3.Distance(previousPos, currentPos);
            if (distance >= cubeLength)
            {
                addPoint(distance, Vector3.Normalize(currentPos - previousPos));
                previousPos = currentPos;
            }
        }
    }
    void addPoint(float dis, Vector3 dirNomarl)
    {
        int count = Mathf.CeilToInt(Mathf.Round(dis));
        for (int i = 0; i <= count; i++)
        {
            positons.Add(dirNomarl * i + previousPos);
        }
    }

    public IEnumerator AddPointObj()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (isRecord && positons.Count > 0)
            {
                addPoint(positons[0]);
                positons.RemoveAt(0);
                //for (int i = 0; i < positons.Count; i++)
                //{
                //     addPoint(positons[i]);
                //}
                //positons.Clear();
            }
        }
    }
   
    void addPoint(Vector3 current)
    {
        Vector3 direction = new Vector3((int)(Mathf.Round(current.x)), (int)(Mathf.Round(current.y)), (int)(Mathf.Round(current.z)));
        if (!IsContainPos(direction))
        {
            SetPoints(direction);
            prefab = PoolManager.Instance.GetObject("Perfabs/Cube");
            prefab.transform.SetParent(transform);
            prefab.transform.localScale = Vector3.one;
            prefab.transform.localPosition = direction;
            prefab.transform.localRotation = Quaternion.identity;
            prefab.name = direction.x + "_" + direction.y + "_" + direction.z;
        }
    }
    public void SetRobotArmPos(Vector3 pos)
    {
        if (!isRecord)
        {
            firstPos = pos;
            currentPos = Vector3.zero;
            previousPos = Vector3.zero;
            isRecord = true;
            SetRobotCenterPos(pos);
        }
        currentPos = pos - firstPos;
        currentPos = new Vector3(Mathf.Clamp(currentPos.x, -120, 119), Mathf.Clamp(currentPos.y, -90, 89), Mathf.Clamp(currentPos.z, -90, 89));
    }
}
