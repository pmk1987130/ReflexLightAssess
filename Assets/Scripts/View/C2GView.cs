using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Net;
using UnityOSC;
using strange.extensions.mediation.impl;
public class C2GView : EventView
{
    private string resultInfo = String.Empty;
    void Update()
    {
        if (OSCServer.Instance != null && OSCServer.Instance.recvPacks.Count > 0)
        {
            int lastPacketIndex = 0;
            if (OSCServer.Instance.recvPacks[lastPacketIndex].Data.Count == 2)
            {
                CommandReceived(OSCServer.Instance.recvPacks[lastPacketIndex].Data[0], OSCServer.Instance.recvPacks[lastPacketIndex].Data[1]);
            }
            OSCServer.Instance.recvPacks.RemoveAt(0);
        }
    }
 
    private void CommandReceived(object cmdType, object obj)
    {
        InfoType commandType;
        try
        {
            commandType = (InfoType)Convert.ToInt32(cmdType);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
        string metaData = obj.ToString();
        if (commandType == InfoType.InitPara)
        {
            resultInfo = metaData;
            return;
        }
        if (commandType == InfoType.OperatingRange)
        {
            resultInfo = metaData;
            return;
        }
        if (commandType == InfoType.OperatingLimits)
        {
            resultInfo = metaData;
            return;
        }
    }
}

