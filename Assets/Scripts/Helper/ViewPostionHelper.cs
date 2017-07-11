using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityOSC;
using System.IO;
public class ViewPostionHelper
{
    public static List<Vector2> GetSidePostions(bool[,] bools)
    {
        List<Vector2> lst = GetSideXPositions(bools);
        lst.AddRange(GetSideYPositons(bools));
        return lst;
    }
    public static List<Coordinate> ConvertToCoordinate(List<Vector2> lst)
    {
        List<Coordinate> lstCoroutine = new List<Coordinate>();
        for (int i = 0; i < lst.Count; i++)
        {
            lstCoroutine.Add(new Coordinate()
            {
                X = lst[i].x,
                Y = lst[i].y,
                Z = 0
            });
        }
        return lstCoroutine;
    }
    static List<Vector2> GetSideXPositions(bool[,] ps)
    {
        List<Vector2> lst = new List<Vector2>();
        Vector2 val1=Vector2.zero;
        Vector2 val2=Vector2.zero;
        int indexY = -1;
        for (int x = 0; x < ps.GetLength(0); x++)
        {
            indexY = -1;
            for (int y = 0; y < ps.GetLength(1); y++)
            {
                if (ps[x, y])
                {
                    val1 = new Vector2(x, y);
                   // lst.Add(val1);//
                    indexY = y;
                    break;
                }
            }
            if (indexY >= 0 && indexY < ps.GetLength(1))
            {
                for (int y = ps.GetLength(1) - 1; y > indexY; y--)
                {
                    if (ps[x, y])
                    {
                        val2 = new Vector2(x, y);
                        lst.Add(val1);
                        lst.Add(val2);
                        break;
                    }
                }
            }
        }
        return lst;
    }
    static List<Vector2> GetSideYPositons(bool[,] ps)
    {
        List<Vector2> lst = new List<Vector2>();
        Vector2 val1=Vector2.zero;
        Vector2 val2 = Vector2.zero;
        int indexX = -1;
        for (int y = 0; y < ps.GetLength(1); y++)
        {
            indexX = -1;
            for (int x = 0; x < ps.GetLength(0); x++)
            {
                if (ps[x, y])
                {
                    val1 = new Vector2(x, y);
                    //lst.Add(val1);//
                    indexX = x;
                    break;
                }
            }
            if (indexX >= 0 && indexX < ps.GetLength(0))
            {
                for (int x = ps.GetLength(0) - 1; x > indexX; x--)
                {
                    if (ps[x, y])
                    {
                        val2 = new Vector2(x, y);
                        lst.Add(val1);
                        lst.Add(val2);
                        break;
                    }
                }
            }
        }
        return lst;
    }
 
}