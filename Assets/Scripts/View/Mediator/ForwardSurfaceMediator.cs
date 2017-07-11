using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSurfaceMediator : SurfaceMediator
{
    [Inject]
    public ForwardSurfaceView forwardSurfaceView { get; set; }
    public override void OnRegister()
    {
        forwardSurfaceView.Init();
        forwardSurfaceView.FuncDistance += funcDistance;
        dispatcher.AddListener(GameEvents.ViewEvent.ToForwardSurface, fun);
        dispatcher.AddListener(GameEvents.ViewEvent.ToForwardSurfaceTrack, trackFun);
    }
    private void fun(IEvent payload)
    {
        forwardSurfaceView.SetIsStart((bool)(payload.data));
    }
    private void trackFun(IEvent payload)
    {
        forwardSurfaceView.SetBottlePositon((Vector3)(payload.data) - gameDataModel.RobotFirstrPos);
    }

    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToForwardSurface, fun);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToForwardSurfaceTrack, trackFun);
        forwardSurfaceView.FuncDistance = null;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

