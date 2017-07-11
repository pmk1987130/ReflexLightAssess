using strange.extensions.command.impl;
using System;
using UnityEngine;
public class S2GHandPositionCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    Vector3 robotPosition;
    string[] strSplit;
    public override void Execute()
    {
        robotPosition = getRobotPosition((string)(evt.data));
        dispatcher.Dispatch(GameEvents.ViewEvent.ToSpawnerPosition, robotPosition);
        dispatcher.Dispatch(GameEvents.ViewEvent.ToUIRightData, robotPosition);
        sendSurface();
    }
    private Vector3 getRobotPosition(string str)//1;2;3;
    {
        Vector3 result;
        strSplit = str.Split(';');
        float x = -float.Parse(strSplit[0]) * 100;//x
        float z = -float.Parse(strSplit[1]) * 100;//y
        float y = float.Parse(strSplit[2]) * 100;//z
        result = new Vector3(x, y, z);
        return result;
    }
    private void sendSurface()
    {
        switch (gameDataModel.CurrentTrackType)
        {
            case TrackType.ToForward:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurfaceTrack, robotPosition);
                break;
            case TrackType.ToLeft:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurfaceTrack, robotPosition);
                break;
            case TrackType.ToRight:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurfaceTrack, robotPosition);
                break;
            case TrackType.ToUp:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurfaceTrack, robotPosition);
                break;
            case TrackType.ToDown:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurfaceTrack, robotPosition);
                break;
            default:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurfaceTrack, robotPosition);
                break;
        }
    }
}

