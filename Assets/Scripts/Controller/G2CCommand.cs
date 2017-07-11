using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using System.Collections.Generic;
using UnityOSC;
using System.IO;
public class G2CCommand : EventCommand
{
    [Inject]
    public IG2CService g2cService { get; set; }
    private G2CArgs args;
    private string metaData;
    private List<string> lst;
    public override void Execute()
    {
        args = (G2CArgs)(evt.data);
        metaData = Newtonsoft.Json.JsonConvert.SerializeObject(args.Args); //序列化
        lst = new List<string>();
        lst.Add(((int)args.MyInfoType).ToString());
        lst.Add(metaData);
        g2cService.Send(lst);
    }
}

