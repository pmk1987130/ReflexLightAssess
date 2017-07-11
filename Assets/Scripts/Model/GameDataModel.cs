using System.Collections;
using UnityEngine;
public class GameDataModel
{
    public bool[, ,] RegionPostion = new bool[120, 90, 90];//区域
    public Vector3 LeftDownBackPostion = new Vector3(-60, -45, -45);
    public TrackType CurrentTrackType = TrackType.ToStart;
    public bool IsPromptGrowth = true;
    public Vector3 RobotFirstrPos = Vector3.zero;//Frist position
    public Vector3 BoundaryCenterPos = Vector3.zero;//计算后的区域中心点
    public string Language = "en";
}
