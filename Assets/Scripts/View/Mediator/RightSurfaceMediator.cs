using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;


public class RightSurfaceMediator : SurfaceMediator
{
    [Inject]
    public RightSurfaceView rightSurfaceView { get; set; }
    public override void OnRegister()
    {
        rightSurfaceView.Init();
        rightSurfaceView.FuncDistance += funcDistance;
        dispatcher.AddListener(GameEvents.ViewEvent.ToRightSurface, fun);
        dispatcher.AddListener(GameEvents.ViewEvent.ToRightSurfaceTrack, trackFun);
    }

    private void trackFun(IEvent payload)
    {
        rightSurfaceView.SetBottlePositon((Vector3)(payload.data) - gameDataModel.RobotFirstrPos);
    }
    private void fun(IEvent payload)
    {
        rightSurfaceView.SetIsStart((bool)(payload.data));
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToRightSurface, fun);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToRightSurfaceTrack, trackFun);
        rightSurfaceView.FuncDistance = null;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

