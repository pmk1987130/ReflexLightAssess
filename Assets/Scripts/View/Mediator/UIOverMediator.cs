using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using UnityEngine;

public class UIOverMediator : EventMediator
{
    [Inject]
    public UIOverView uiOverView { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(GameEvents.ViewEvent.TOUIOver,showUIOver);
    }

    private void showUIOver()
    {
        uiOverView.Content.SetActive(true);
        uiOverView.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(quit());
    }
    IEnumerator quit()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.TOUIOver, showUIOver);
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

