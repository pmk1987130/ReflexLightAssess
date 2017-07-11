using System;
using UnityEngine;

public class WallFlashAnimation
{
    public Action FinishAction;
    public Action<float> CallBackAction;
    private float flashTime = 4;
    private float lerpVal = 0;
    private int symbol = 2;
    private bool isFlash = false;
    public bool IsFlash
    {
        get { return isFlash; }
        set
        {
            flashTime = 4;
            lerpVal = 0;
            symbol = 2;
            isFlash = value;
        }
    }

    public void Update(float timeDelta)
    {
        if (isFlash)
        {
            if (flashTime > 0f)
            {
                if (lerpVal > 0.99f)
                {
                    symbol = -2;
                }
                if (lerpVal < 0.01f)
                {
                    symbol = 2;
                }
                flashTime -= Time.deltaTime * Mathf.Abs(symbol);
                lerpVal += Time.deltaTime * symbol;
                CallBackAction(lerpVal);
            }
            else
            {
                CallBackAction(0);
                isFlash = false;
                FinishAction();
            }
        }
    }
}
