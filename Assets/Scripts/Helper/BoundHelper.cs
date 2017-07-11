using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class BoundHelper
{
   /// <summary>
    /// Get Center Postion
   /// </summary>
   /// <returns></returns>
    public static Vector3 GetCenterPostion()
    {
        Transform currentParent = GameObject.Find("SpawnerView").transform;
        Vector3 postion = currentParent.position;
        Quaternion rotation = currentParent.rotation;
        Vector3 scale = currentParent.localScale;
        currentParent.position = Vector3.zero;
        currentParent.rotation = Quaternion.Euler(Vector3.zero);
        currentParent.localScale = Vector3.one;
        Vector3 center = Vector3.zero;
        Renderer[] renders = currentParent.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in renders)
        {
            center += child.bounds.center;
        }
        center /= currentParent.GetComponentsInChildren<Renderer>().Length;
        Bounds bounds = new Bounds(center, Vector3.zero);
        foreach (Renderer child in renders)
        {
            bounds.Encapsulate(child.bounds);
        }
        currentParent.position = postion;
        currentParent.rotation = rotation;
        currentParent.localScale = scale;
        Vector3 centerPos = bounds.center + currentParent.position;
        return centerPos;
    }
    /// <summary>
    /// Draw the points
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static int GetPositionCount(bool[, ,] array)
    {
        int result = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    if (array[i, j, k])
                    {
                        result += 1;
                    }
                }
            }
        }
        return result;
    }
    /// <summary>
    ///  axis points
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="minPos"></param>
    /// <param name="array"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static int GetContainCount(Bounds bounds,Vector3 minPos, bool[, ,] array, AxisType axis)
    {
        Vector3 dir;
        int reslut = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    if (array[i, j, k])
                    {
                        dir = new Vector3(i, j, k) + minPos;
                        if (bounds.Contains(dir))
                        {
                            if (axis == AxisType.Axis_X || axis == AxisType.Axis_Y || axis == AxisType.Axis_Z)
                            {
                                reslut += 1;
                            }
                        }
                    }
                }
            }
        }
        return reslut;
    }
    /// <summary>
    /// min axis
    /// </summary>
    /// <param name="region"></param>
    /// <param name="minPos"></param>
    /// <param name="centerPos"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static float GetAxisMin(bool[, ,] region, Vector3 minPos, Vector3 centerPos, AxisType axis)
    {
        float axisLength=-1;
        int pointsCount = 0;
        List<AxisArea> lst = new List<AxisArea>();
        Bounds bounds = new Bounds(Vector3.zero,Vector3.zero) ;
        AxisArea axisArea = null;
        for (int i = 2; i <= 20; i += 2)
        {
            if (axis == AxisType.Axis_X)
                bounds = new Bounds(centerPos, new Vector3(i, 40, 40));
            if (axis == AxisType.Axis_Y)
                bounds = new Bounds(centerPos, new Vector3(40, i, 40));
            if (axis == AxisType.Axis_Z)
                bounds = new Bounds(centerPos, new Vector3(40, 40, i));
            int count = BoundHelper.GetContainCount(bounds, minPos, region, axis);
            if (count > 0)
            {
                axisArea = new AxisArea(i, count);
                lst.Add(axisArea);
            }
        }
        lst.Sort();
        if (lst.Count > 0)
        {
            pointsCount = lst[0].CountPos;
        }
        List<float> lstAxis = new List<float>();
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i].CountPos == pointsCount)
            {
                lstAxis.Add(lst[i].Axis);
            }
        }
        lstAxis.Sort((x, y) =>
        {
            return x.CompareTo(y);
        });
        axisLength = lstAxis[0];
        return axisLength;
    }
   
}