using strange.extensions.mediation.impl;
using System;
using System.Collections;
using UnityEngine;
public class SurfaceView : EventView
{
    protected Texture2D wallTexture;
    protected int wallTextureWidth;
    protected int wallTextureHight;
    protected Vector2 wallPixel;
    protected Transform bottle;
    protected GameObject wallBox;
    protected Material wallMaterial;
    protected bool isMove = false;
    protected Vector3 bottlePositon;
    protected Vector3 bottlePreviousPos = Vector3.zero;
    public Func<Vector3, float> FuncDistance;
    private EffectAndAudio effandAudio;
    protected WallFlashAnimation wallFlashAnimation;
    public virtual void Init()
    {
        wallBox = GameObject.Find("WallBox");
        bottle = transform.GetChild(0);
        effandAudio = bottle.gameObject.AddComponent<EffectAndAudio>();
        wallFlashAnimation = new WallFlashAnimation();
        wallFlashAnimation.FinishAction = FinishAction;
        wallFlashAnimation.CallBackAction = CallBackAction;
    }
    private void CallBackAction(float obj)
    {
        wallMaterial.SetColor("_FlashColor", Color.Lerp(Color.white, new Color(200.0f / 255, 200.0f / 255, 200.0f / 255, 1), obj));
    }

    private void FinishAction()
    {
        isMove = true;
        bottle.gameObject.SetActive(true);
    }
    public void wallTextureInit()
    {
        for (int i = 0; i < wallTextureWidth; i++)
        {
            for (int j = 0; j < wallTextureHight; j++)
            {
                wallTexture.SetPixel(i, j, Color.white);
            }
        }
        wallTexture.Apply();
        wallMaterial.SetTexture("_SecondTex", wallTexture);
    }
    public void SetIsStart(bool bol)
    {
        wallFlashAnimation.IsFlash = bol;
        if (!bol)
        {
            bottle.gameObject.SetActive(false);
            isMove = false;
            bottlePreviousPos = Vector3.zero;
        }
    }
    public void SetEffectColor(Color color)
    {
        effandAudio.SeteffectColor(color);
    }
    public Color GetDrawColor(Vector3 pos)
    {
        float distance = Vector3.Distance(Vector3.zero, pos);
        return Color.Lerp(new Color(1,44.0f/255,0,1), new Color(1,1,0,1), distance / 50.0f);
    }
    public virtual void DrawTexture(Vector3 point, Color color) { }
    public virtual void SetBottlePositon(Vector3 pos) { }
}

