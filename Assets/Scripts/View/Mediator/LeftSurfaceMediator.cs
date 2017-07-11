using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LeftSurfaceMediator : SurfaceMediator
{
    [Inject]
    public LeftSurfaceView leftSurfaceView { get; set; }
    public override void OnRegister()
    {
        leftSurfaceView.Init();
        leftSurfaceView.FuncDistance += funcDistance;
        dispatcher.AddListener(GameEvents.ViewEvent.ToLeftSurface, fun);
        dispatcher.AddListener(GameEvents.ViewEvent.ToLeftSurfaceTrack, trackFun);
    }

    private void trackFun(IEvent payload)
    {
        leftSurfaceView.SetBottlePositon((Vector3)(payload.data) - gameDataModel.RobotFirstrPos);
    }
    private void fun(IEvent payload)
    {
        leftSurfaceView.SetIsStart((bool)(payload.data));
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToLeftSurface, fun);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToLeftSurfaceTrack, trackFun);
        leftSurfaceView.FuncDistance = null;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

