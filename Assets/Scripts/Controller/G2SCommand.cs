using strange.extensions.command.impl;

public class G2SCommand : EventCommand
{
    [Inject]
    public IG2SService g2sService { get; set; }
    string str = string.Empty;
    public override void Execute()
    {
        str = (string)(evt.data);
        if (!string.IsNullOrEmpty(str))
            g2sService.Send((string)(evt.data));
    }
}

