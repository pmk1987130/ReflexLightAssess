using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;
using strange.extensions.context.api;
using UnityOSC;
using System.Net;
public class G2SService : IG2SService
{
    public IEventDispatcher dispatcher { get; set; }
    public void G2SStart()
    {
        NetWorkUtil.Instance = new NetWorkUtil("10.30.203.12", 7654);
    }
    public void Send(string value)
    {
        NetWorkUtil.Instance.sendCommand(value);
    }
    public string Returning(string value)
    {
        return NetWorkUtil.Instance.sendCommand(value);
    }
}

