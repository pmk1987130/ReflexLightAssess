using strange.extensions.command.impl;
using System;

public class CreateServiceCommand : EventCommand
{
    [Inject]
    public IG2CService g2cService { get; set; }
    [Inject]
    public IG2SService g2sService { get; set; }

    public override void Execute()
    {
        //g2cService.G2CServerCreate();
        //g2cService.G2CClientCreate();
        g2sService.G2SStart();
        g2sService.Send("Renderer/Remove all/clear=true;");
        g2sService.Send("State/force=trigger;");
    }
}

