using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using System;
public class RobotArmView : EventView
{
    public Transform MoveSphere;
    Vector3 robotPostion;
    [HideInInspector]
    public Action<Vector3> GetpostionAction;
    [HideInInspector]
    public Action GetRobotPositon;
    float mx, my, mz;

    void Update()
    {
        //MoveSphere.position += new Vector3(Input.GetAxis("Horizontal") * 2, 0, 0);
        //MoveSphere.position += new Vector3(0, Input.GetAxis("Vertical") * 2, 0);
        //mx = MoveSphere.position.x;
        //my = MoveSphere.position.y;
        //mz = MoveSphere.position.z;
        //mx = Mathf.Clamp(mx, -210, 119);//attention
        //my = Mathf.Clamp(my, -210, 119); //attention
        //mz = Mathf.Clamp(mz, -210, 119);//attention
        //MoveSphere.position = new Vector3(mx, my, mz);
        //robotPostion = MoveSphere.position;
        //GetpostionAction(robotPostion);
       GetRobotPositon();
    }
}

