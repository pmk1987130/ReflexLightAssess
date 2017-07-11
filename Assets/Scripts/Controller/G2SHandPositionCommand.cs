
using strange.extensions.command.impl;
public class G2SHandPositionCommand : EventCommand
{
    [Inject]
    public IG2SService g2sService { get; set; }

    public override void Execute()
    {
        dispatcher.Dispatch(GameEvents.CommandEvent.ToS2GHandPosition, g2sService.Returning((string)(evt.data)));
    }
}

