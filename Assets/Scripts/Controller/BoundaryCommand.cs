using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
public class BoundaryCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }

    float max_x = 0;
    float min_x = 0;

    float max_y = 0;
    float min_y = 0;

    float max_z = 0;
    float min_z = 0;

    OperatingLimits operatingLimits;

    public override void Execute()
    {
        gameDataModel.BoundaryCenterPos = BoundHelper.GetCenterPostion();
        int count = BoundHelper.GetPositionCount(gameDataModel.RegionPostion);
        if (count <= 8)
        {
            Debug.Log("count not less than 8");
            return;
        }

        float rangleX = BoundHelper.GetAxisMin(gameDataModel.RegionPostion, gameDataModel.LeftDownBackPostion, gameDataModel.BoundaryCenterPos, AxisType.Axis_X);
        max_x = gameDataModel.BoundaryCenterPos.x + rangleX * 0.5f;
        min_x = gameDataModel.BoundaryCenterPos.x - rangleX * 0.5f;

        float RangleY = BoundHelper.GetAxisMin(gameDataModel.RegionPostion, gameDataModel.LeftDownBackPostion, gameDataModel.BoundaryCenterPos, AxisType.Axis_Y);
        max_y = gameDataModel.BoundaryCenterPos.y + RangleY * 0.5f;
        min_y = gameDataModel.BoundaryCenterPos.y - RangleY * 0.5f;

        float RangleZ = BoundHelper.GetAxisMin(gameDataModel.RegionPostion, gameDataModel.LeftDownBackPostion, gameDataModel.BoundaryCenterPos, AxisType.Axis_Z);
        max_z = gameDataModel.BoundaryCenterPos.z + RangleZ * 0.5f;
        min_z = gameDataModel.BoundaryCenterPos.z - RangleZ * 0.5f;


        max_x = (max_x + gameDataModel.RobotFirstrPos.x) * 0.01f;
        min_x = (min_x + gameDataModel.RobotFirstrPos.x) * 0.01f;
        max_y = (max_y + gameDataModel.RobotFirstrPos.y) * 0.01f;
        min_y = (min_y + gameDataModel.RobotFirstrPos.y) * 0.01f;
        max_z = (max_z + gameDataModel.RobotFirstrPos.z) * 0.01f;
        min_z = (min_z + gameDataModel.RobotFirstrPos.z) * 0.01f;

        operatingLimits = new OperatingLimits();

        operatingLimits.MaxX = -min_x;
        operatingLimits.MinX = -max_x;
        operatingLimits.MaxY = max_z;
        operatingLimits.MinY = min_z;
        operatingLimits.MaxZ = max_y;
        operatingLimits.MinZ = min_y;

        Vector3 center = (gameDataModel.BoundaryCenterPos + gameDataModel.RobotFirstrPos) * 0.01f;
        operatingLimits.Center = new Coordinate()
        {
            X = -center.x,
            Y = -center.z,
            Z = center.y
        };
        G2CArgs args = new G2CArgs()
        {
            MyInfoType = InfoType.OperatingLimits,
            Args = operatingLimits
        };

        dispatcher.Dispatch(GameEvents.CommandEvent.ToG2C, args);
    }
 
}