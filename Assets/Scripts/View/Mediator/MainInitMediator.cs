using strange.extensions.mediation.impl;
using System;
public class MainInitMediator : EventMediator
{
    [Inject]
    public MainInitView mainInitView { get; set; }
    public override void OnRegister()
    {
        mainInitView.Init();
        dispatcher.Dispatch(GameEvents.CommandEvent.ToMainScene);
    }
}

