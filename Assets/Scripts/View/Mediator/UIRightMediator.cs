using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class UIRightMediator : EventMediator
{
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    [Inject]
    public UIRightView uiRightView { get; set; }
    public override void OnRegister()
    {
        setLanguage();
        dispatcher.AddListener(GameEvents.ViewEvent.ToUIRightUpdateTrack, updateTrack);
        dispatcher.AddListener(GameEvents.ViewEvent.ToUIRightData,setDataText);
        uiRightView.PreviousBtn.onClick.AddListener(PreviousFun);
        uiRightView.NextBtn.onClick.AddListener(NextFun);
    }

    private void setLanguage()
    {
        for (int i = 0; i < uiRightView.DataLabels.Length; i++)
        {
            uiRightView.DataLabels[i].text = WardsManager.Instance.GetNodeValue(uiRightView.DataLabels[i].gameObject.name, gameDataModel.Language);
        }
    }

    private void setDataText(IEvent payload)
    {
       Vector3 position1=(Vector3)(payload.data);
       Vector3 position2 = position1 - gameDataModel.RobotFirstrPos;
       uiRightView.DataTexts[0].text = (int)(position2.y) + "cm";
       uiRightView.DataTexts[1].text = (int)(0 - position2.y) + "cm";
       uiRightView.DataTexts[2].text = (int)(0 - position2.x) + "cm";
       uiRightView.DataTexts[3].text = (int)(position2.x) + "cm";
       uiRightView.DataTexts[4].text = (int)(position2.z) + "cm";
       uiRightView.DataTexts[5].text = (int)(0 - position2.z) + "cm";
    }
    void updateTrack(IEvent payload)
    {
        UIFun((TrackType)payload.data);
    }

    private void UIFun(TrackType trackType)
    {
        switch (trackType)
        {
            case TrackType.ToForward:
                setForward();
                break;
            case TrackType.ToLeft:
                setLeft();
                break;
            case TrackType.ToRight:
                setRight();
                break;
            case TrackType.ToUp:
                setUp();
                break;
            case TrackType.ToDown:
                setDown();
                break;
            case TrackType.ToEnd:
                return;
        }
        uiRightView.PointingTitle.text = WardsManager.Instance.GetNodeValue(uiRightView.PointingTitle.gameObject.name, gameDataModel.Language, (int)(trackType));
        uiRightView.PointingTitleName.text = WardsManager.Instance.GetNodeValue(uiRightView.PointingTitleName.gameObject.name, gameDataModel.Language, (int)(trackType));
        uiRightView.PointingDescribe.text = WardsManager.Instance.GetNodeValue(uiRightView.PointingDescribe.gameObject.name, gameDataModel.Language, (int)(trackType));
    }

    private void setDown()
    {
        uiRightView.PreviousBtn.gameObject.SetActive(true);
        uiRightView.NextBtn.gameObject.SetActive(true);
    }

    private void setUp()
    {
        uiRightView.PreviousBtn.gameObject.SetActive(true);
        uiRightView.NextBtn.gameObject.SetActive(true);
    }

    private void setRight()
    {
        uiRightView.PreviousBtn.gameObject.SetActive(true);
        uiRightView.NextBtn.gameObject.SetActive(true);
    }

    private void setLeft()
    {
        uiRightView.PreviousBtn.gameObject.SetActive(true);
        uiRightView.NextBtn.gameObject.SetActive(true);
    }

    private void setForward()
    {
        uiRightView.PreviousBtn.gameObject.SetActive(false);
        uiRightView.NextBtn.gameObject.SetActive(true);

    }
    private void NextFun()
    {
        dispatcher.Dispatch(GameEvents.CommandEvent.ToTrack, 1);
    }

    private void PreviousFun()
    {
        dispatcher.Dispatch(GameEvents.CommandEvent.ToTrack, -1);
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToUIRightUpdateTrack, updateTrack);
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToUIRightData, setDataText);
        uiRightView.PreviousBtn.onClick.RemoveAllListeners();
        uiRightView.NextBtn.onClick.RemoveAllListeners();
    }

    void OnDestroy()
    {
        OnRemove();
    }
}

