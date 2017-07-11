using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UpSurfaceMediator : SurfaceMediator
{
    [Inject]
    public UpSurfaceView upSurfaceView { get; set; }
    public override void OnRegister()
    {
        upSurfaceView.Init();
        upSurfaceView.FuncDistance += funcDistance;
        dispatcher.AddListener(GameEvents.ViewEvent.ToUpSurface, fun);
        dispatcher.AddListener(GameEvents.ViewEvent.ToUpSurfaceTrack, trackFun);
    }
    private void fun(IEvent payload)
    {
        upSurfaceView.SetIsStart((bool)(payload.data));
    }
    private void trackFun(IEvent payload)
    {
        upSurfaceView.SetBottlePositon((Vector3)(payload.data) - gameDataModel.RobotFirstrPos);
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToUpSurface, fun);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToUpSurfaceTrack, trackFun);
        upSurfaceView.FuncDistance = null;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

