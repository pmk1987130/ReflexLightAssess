using System;
namespace UnityOSC
{
    public enum InfoType
    {
        HandShark = 0,    //GTC:Game To Client
        InitPara = 1,     //CTG:Client To Game
        OperatingLimits = 2,    //Two way
        OperatingRange = 3,   //GTC
        Record = 4,       //GTC
    }
}
