using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using UnityEngine;
public class SurfaceMediator : EventMediator
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    protected float funcDistance(Vector3 arg)
    {
        return Vector3.Distance(arg - gameDataModel.RobotFirstrPos, Vector3.zero);
    }
}

