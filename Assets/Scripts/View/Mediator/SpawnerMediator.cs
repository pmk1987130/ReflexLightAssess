using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using UnityEngine;

public class SpawnerMediator : EventMediator
{
    [Inject]
    public SpawnerView mainRoleView { get; set; }
    [Inject]
    public GameDataModel gameDataModel { get; set; }
    private Vector3 direction;
    public override void OnRegister()
    {
        dispatcher.AddListener(GameEvents.ViewEvent.ToSpawnerPosition, SetPostion);
        mainRoleView.SetRobotCenterPos += setRobotCenterPos;
        mainRoleView.IsContainPos += isContainpos;
        mainRoleView.SetPoints += SetPoints;
        mainRoleView.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(mainRoleView.AddPointObj());
    }
    private void SetPoints(Vector3 obj)
    {
        for (int i = 0; i < gameDataModel.RegionPostion.GetLength(0); i++)
        {
            for (int j = 0; j < gameDataModel.RegionPostion.GetLength(1); j++)
            {
                for (int k = 0; k < gameDataModel.RegionPostion.GetLength(2); k++)
                {
                    Vector3 dir = obj - gameDataModel.LeftDownBackPostion;
                    if (i == Mathf.CeilToInt(dir.x) && j == Mathf.CeilToInt(dir.y) && k == Mathf.CeilToInt(dir.z))
                        gameDataModel.RegionPostion[i, j, k] = true;
                }
            }
        }
    }
    private void setRobotCenterPos(Vector3 obj)
    {
        gameDataModel.RobotFirstrPos = obj;
    }
    private bool isContainpos(Vector3 arg)
    {
        direction = arg - gameDataModel.LeftDownBackPostion;
        direction = new Vector3(Mathf.Clamp(direction.x, 0, 119), Mathf.Clamp(direction.y, 0, 89), Mathf.Clamp(direction.z, 0, 89));
        return gameDataModel.RegionPostion[(int)(direction.x), (int)(direction.y), (int)(direction.z)];
    }
    private void SetPostion(IEvent payload)
    {
        mainRoleView.SetRobotArmPos((Vector3)(payload.data));
    }
    public new void OnRemove()
    {
        dispatcher.RemoveListener(GameEvents.ViewEvent.ToSpawnerPosition, SetPostion);
        mainRoleView.SetRobotCenterPos -= setRobotCenterPos;
        mainRoleView.IsContainPos -= isContainpos;
        mainRoleView.SetPoints -= SetPoints;
    }
    void OnDestroy()
    {
        OnRemove();
    }
}

