using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class RobotArmMediator:EventMediator
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    [Inject]
    public RobotArmView robotArmView { get; set; }
    private bool isGetPosition=true;
    public override void OnRegister()
    {
        dispatcher.AddListener(GameEvents.ViewEvent.ToRobotArmStopGetPos,SetIsGetPosition);
        robotArmView.GetRobotPositon += GetRobotPositon;
        robotArmView.GetpostionAction += GetPostionAction;
    }

    private void SetIsGetPosition()
    {
        isGetPosition = false;
    }
 
    private void GetRobotPositon()
    {
        if (isGetPosition)
        dispatcher.Dispatch(GameEvents.CommandEvent.ToG2SHandPosition, "Model/Cartesian/pos X;Model/Cartesian/pos Y;Model/Cartesian/pos Z;");
    }
    private void GetPostionAction(Vector3 obj)
    {
        if (isGetPosition)
        {
            dispatcher.Dispatch(GameEvents.ViewEvent.ToSpawnerPosition, obj);
            dispatcher.Dispatch(GameEvents.ViewEvent.ToUIRightData, obj);
            testsendSurface(obj);
        }
    }

    private void testsendSurface(Vector3 robotPosition)
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
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToRobotArmStopGetPos, SetIsGetPosition);
        robotArmView.GetRobotPositon -= GetRobotPositon;
        robotArmView.GetpostionAction -= GetPostionAction;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

