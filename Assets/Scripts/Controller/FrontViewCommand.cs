using System.Collections;
using strange.extensions.command.impl;
using UnityEngine;
using UnityOSC;
using System.IO;

public class FrontViewCommand : ViewCommand
{
    public override void Execute()
    {
        for (int i = 0; i < frontRegion1.GetLength(0); i++)
        {
            for (int j = 0; j < frontRegion1.GetLength(1); j++)
            {
                frontRegion1[i, j] = false;
            }
        }

        for (int i = 0; i < gameDataModel.RegionPostion.GetLength(0); i++)//x
        {
            for (int j = 0; j < gameDataModel.RegionPostion.GetLength(1); j++)//y
            {
                for (int m = 0; m < gameDataModel.RegionPostion.GetLength(2); m++)
                {
                    if (gameDataModel.RegionPostion[i, j, m])///update
                    {
                        frontRegion1[i, j] = true;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < frontRegion2.GetLength(0); i++)
        {
            for (int j = 0; j < frontRegion2.GetLength(1); j++)
            {
                frontRegion2[i, j] = frontRegion1[j, 89 - i];
            }
        }

        //#region write
        //StreamWriter sw = new StreamWriter("E:\\view_front.txt", true);
        //string str = "";
        //for (int i = 0; i < 90; i++)
        //{
        //    str = "";
        //    for (int j = 0; j < 120; j++)
        //    {
        //        if (frontRegion2[i, j])
        //        {
        //            str += "_0";
        //        }
        //        else
        //        {
        //            str += "_1";
        //        }
        //    }
        //    sw.WriteLine(str);
        //}
        //sw.Close();//写入
        //#endregion

        CallG2C(frontRegion2, DirectionType.Front);
    }
}
