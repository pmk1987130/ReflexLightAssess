using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityOSC;
using System.IO;
using System.Text;
public class ViewCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    protected bool[,] frontRegion1 = new bool[120, 90];
    protected bool[,] frontRegion2 = new bool[90, 120];

    protected bool[,] sideRegion1 = new bool[90, 90];
    protected bool[,] sideRegion2 = new bool[90, 90];

    protected bool[,] verticalRegion1 = new bool[120, 90];
    protected bool[,] verticalRegion2 = new bool[120, 90];

    public override void Execute()
    {
        base.Execute();
    }
    protected void CallG2C(bool[,] array, DirectionType type)
    {
        OperatingRange operating = new OperatingRange();
        operating.Type = type;
        List<Coordinate> lst = ViewPostionHelper.ConvertToCoordinate(ViewPostionHelper.GetSidePostions(array));
        operating.Points = lst;
        G2CArgs args = new G2CArgs();
        args.MyInfoType = InfoType.OperatingRange;
        args.Args = operating;
        // dispatcher.Dispatch(GameEvents.CommandEvent.TO_G2C_COMMAND, args);
        #region write
        StreamWriter sw = new StreamWriter("E:\\viewFront1.txt", true);
        Coordinate coordinate;
        string str = "";
        for (int i = 0; i < 90; i++)
        {
            str = "";
            for (int j = 0; j < 120; j++)
            {
                coordinate = lst.Find((x) =>
                {
                    return x.X == i && x.Y == j;
                });
                if (coordinate != null)
                {
                    str += "_0";
                }
                else
                {
                    str += "_1";
                }
            }
            sw.WriteLine(str);
        }
        sw.Close();//写入
        #endregion
    }
}