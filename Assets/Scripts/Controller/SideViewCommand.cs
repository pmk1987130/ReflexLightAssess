using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityOSC;
using System.IO;

public class SideViewCommand : ViewCommand
{
    public override void Execute()
    {
        for (int i = 0; i < sideRegion1.GetLength(0); i++)
        {
            for (int j = 0; j < sideRegion1.GetLength(1); j++)
            {
                sideRegion1[i, j] = false;
            }
        }

        for (int i = 0; i < gameDataModel.RegionPostion.GetLength(2); i++)//z
        {
            for (int j = 0; j < gameDataModel.RegionPostion.GetLength(1); j++)//y
            {
                for (int m = 0; m < gameDataModel.RegionPostion.GetLength(0); m++)
                {
                    if (gameDataModel.RegionPostion[m, j, i])
                    {
                        sideRegion1[j, i] = true;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < sideRegion2.GetLength(0); i++)
        {
            for (int j = 0; j < sideRegion2.GetLength(1); j++)
            {
                sideRegion2[i, j] = sideRegion1[89 - i, j];
            }
        }
        CallG2C(sideRegion2, DirectionType.Right);
     
    }
}
