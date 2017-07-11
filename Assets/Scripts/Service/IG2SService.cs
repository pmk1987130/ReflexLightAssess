using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;
public interface IG2SService
{
    IEventDispatcher dispatcher { get; set; }
    void G2SStart();
    void Send(string value);
    string Returning(string value);
}