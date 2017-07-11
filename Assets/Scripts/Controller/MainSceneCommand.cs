using strange.extensions.command.impl;
using System;

public class MainSceneCommand : EventCommand
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    public override void Execute()
    {
        modelInit();
        dispatcher.Dispatch(GameEvents.CommandEvent.ToTrack, 1);
    }
    private void modelInit()
    {
        for (int i = 0; i < gameDataModel.RegionPostion.GetLength(0); i++)
        {
            for (int j = 0; j < gameDataModel.RegionPostion.GetLength(1); j++)
            {
                for (int k = 0; k < gameDataModel.RegionPostion.GetLength(2); k++)
                {
                    gameDataModel.RegionPostion[i, j, k] = false;
                }
            }
        }
    }
}

