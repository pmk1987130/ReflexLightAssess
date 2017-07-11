using strange.extensions.context.api;
using strange.extensions.context.impl;
using System;
using UnityEngine;
public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view, bool autoMapping)
        : base(view, autoMapping)
    {
    }
    protected override void mapBindings()
    {
        //injection
        injectionBinder.Bind<GameDataModel>().To<GameDataModel>().ToSingleton();
        injectionBinder.Bind<IG2CService>().To<G2CService>().ToSingleton();
        injectionBinder.Bind<IG2SService>().To<G2SService>().ToSingleton();

        //command
        commandBinder.Bind(GameEvents.CommandEvent.ToCreateService).To<CreateServiceCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToG2C).To<G2CCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToG2S).To<G2SCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToMainScene).To<MainSceneCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToTrack).To<TrackCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToG2SHandPosition).To<G2SHandPositionCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToS2GHandPosition).To<S2GHandPositionCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToFrontView).To<FrontViewCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToSideView).To<SideViewCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToVerticalView).To<VerticalViewCommand>();
        commandBinder.Bind(GameEvents.CommandEvent.ToBoundary).To<BoundaryCommand>();

        //mediator
        mediationBinder.Bind<SpawnerView>().To<SpawnerMediator>();
        mediationBinder.Bind<C2GView>().To<C2GMediator>();
        mediationBinder.Bind<RobotArmView>().To<RobotArmMediator>();
        mediationBinder.Bind<MainInitView>().To<MainInitMediator>();
        mediationBinder.Bind<ForwardSurfaceView>().To<ForwardSurfaceMediator>();
        mediationBinder.Bind<LeftSurfaceView>().To<LeftSurfaceMediator>();
        mediationBinder.Bind<RightSurfaceView>().To<RightSurfaceMediator>();
        mediationBinder.Bind<DownSurfaceView>().To<DownSurfaceMediator>();
        mediationBinder.Bind<UpSurfaceView>().To<UpSurfaceMediator>();
        mediationBinder.Bind<UIRightView>().To<UIRightMediator>();
        mediationBinder.Bind<UIOverView>().To<UIOverMediator>();

        commandBinder.Bind(ContextEvent.START).To<FirstCommand>().Once();
    }
}

