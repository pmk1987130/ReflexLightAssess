using System.Collections;
using strange.extensions.command.impl;
using UnityEngine;
using UnityOSC;
using System.IO;

public class VerticalViewCommand : ViewCommand
{
    public override void Execute()
    {

        for (int i = 0; i < verticalRegion1.GetLength(0); i++)
        {
            for (int j = 0; j < verticalRegion1.GetLength(1); j++)
            {
                verticalRegion1[i, j] = false;
            }
        }

        for (int i = 0; i < gameDataModel.RegionPostion.GetLength(0); i++)//x
        {
            for (int j = 0; j < gameDataModel.RegionPostion.GetLength(2); j++)//z
            {
                for (int m = 0; m < gameDataModel.RegionPostion.GetLength(1); m++)
                {
                    if (gameDataModel.RegionPostion[i, m, j])
                    {
                        verticalRegion1[i, j] = true;
                        break;
                    }
                }
            }
        }
        //for (int i = 0; i < verticalRegion2.GetLength(0); i++)
        //{
        //    for (int j = 0; j < verticalRegion2.GetLength(1); j++)
        //    {
        //        verticalRegion2[i, j] = verticalRegion1[i, j];
        //    }
        //}
        CallG2C(verticalRegion1, DirectionType.Top);

   
    }
}
