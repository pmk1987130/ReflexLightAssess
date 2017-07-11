using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;
using strange.extensions.context.api;
using UnityOSC;
using System.Net;
using UnityEngine;
public class G2CService : IG2CService
{
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }
    public void G2CServerStart()
    {
        OSCServer.Instance = new OSCServer(8039);
    }
    public void G2CClientStart()
    {
        OSCClient.Instance = new OSCClient(IPAddress.Parse("127.0.0.1"), 8036);
    }
    public void Send(List<string> values)
    {
        if (OSCClient.Instance != null)
        {
            OSCMessage message = new OSCMessage("");
            foreach (string msgvalue in values)
            {
                message.Append(msgvalue);
            }
            OSCClient.Instance.Send(message);
        }
    }
}

