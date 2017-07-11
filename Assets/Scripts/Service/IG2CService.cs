using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;
public interface IG2CService
{
    IEventDispatcher dispatcher { get; set; }
    void G2CServerStart();
    void G2CClientStart();
    void Send(List<string> values);
}