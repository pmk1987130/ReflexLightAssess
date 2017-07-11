using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;
public class DownSurfaceMediator : SurfaceMediator
{
    [Inject]
    public DownSurfaceView downSurfaceView { get; set; }
    public override void OnRegister()
    {
        downSurfaceView.Init();
        downSurfaceView.FuncDistance += funcDistance;
        dispatcher.AddListener(GameEvents.ViewEvent.ToDownSurface, fun);
        dispatcher.AddListener(GameEvents.ViewEvent.ToDownSurfaceTrack,trackFun);
    }

    private void trackFun(IEvent payload)
    {
        downSurfaceView.SetBottlePositon((Vector3)(payload.data) - gameDataModel.RobotFirstrPos);
    }


    private void fun(IEvent payload)
    {
        downSurfaceView.SetIsStart((bool)(payload.data));
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToDownSurface, fun);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToDownSurfaceTrack, trackFun);
        downSurfaceView.FuncDistance =null;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

