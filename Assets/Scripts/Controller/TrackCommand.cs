using strange.extensions.command.impl;
using System;
using UnityEngine;

public class TrackCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    int value;
    int track;
    public override void Execute()
    {
        value = (int)(evt.data);//1:add -1:cut
        track = (int)(gameDataModel.CurrentTrackType) + value;
        if (track <= 0) track = 0;
        if (track > 6) track = 6;
        gameDataModel.CurrentTrackType = (TrackType)(track);
        callSurfaceView();
        callUIRightView();
    }

    private void callUIRightView()
    {
        dispatcher.Dispatch(GameEvents.ViewEvent.ToUIRightUpdateTrack, gameDataModel.CurrentTrackType);
    }

    private void callSurfaceView()
    {
        switch (gameDataModel.CurrentTrackType)
        {
            case TrackType.ToForward:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurface,true);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface,false);
                break;
            case TrackType.ToLeft:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurface,true);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface,false);
                break;
            case TrackType.ToRight:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurface,true);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface,false);
                break;
            case TrackType.ToUp:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurface,true);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface,false);
                break;
            case TrackType.ToDown:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToForwardSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToLeftSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRightSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToUpSurface,false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface,true);
                break;
            case TrackType.ToEnd:
                dispatcher.Dispatch(GameEvents.ViewEvent.ToDownSurface, false);
                dispatcher.Dispatch(GameEvents.ViewEvent.ToRobotArmStopGetPos);
                dispatcher.Dispatch(GameEvents.ViewEvent.TOUIOver);
                //dispatcher.Dispatch(GameEvents.CommandEvent.ToFrontView);
                //dispatcher.Dispatch(GameEvents.CommandEvent.ToSideView);
               // dispatcher.Dispatch(GameEvents.CommandEvent.ToVerticalView);
                //dispatcher.Dispatch(GameEvents.CommandEvent.ToBoundary);
                break;
            default:
                break;
        }
    }
}

