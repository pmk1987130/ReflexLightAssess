using UnityEngine;
using UnityOSC;
using System.Collections;
using strange.extensions.mediation.impl;
using System.Collections.Generic;
using System;
public class C2GMediator : EventMediator
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    [Inject]
    public C2GView c2gView { get; set; }
    [Inject]
    public IG2CService g2cService { set; get; }
    public override void OnRegister()
    {
       ToShakehandAction();
    }
    private void ToShakehandAction()
    {
        G2CArgs args = new G2CArgs();
        args.MyInfoType = InfoType.HandShark;
        args.Args = String.Empty;
        dispatcher.Dispatch(GameEvents.CommandEvent.ToG2C, args);
    }

    public new void OnRemove()
    {

    }

    void OnDestroy()
    {
        OnRemove();
    }
}

