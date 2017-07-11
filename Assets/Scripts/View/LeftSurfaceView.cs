using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftSurfaceView : SurfaceView
{
    public override void Init()
    {
        base.Init();
        bottlePositon = new Vector3(-60, 0, 0);
        wallMaterial = wallBox.transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().material;
        wallTextureWidth = 900;
        wallTextureHight = 900;
        wallTexture = new Texture2D(wallTextureWidth, wallTextureHight, TextureFormat.ARGB32, false);
        wallTextureInit();
    }
    void Update()
    {
        wallFlashAnimation.Update(Time.deltaTime);
    }
    public override void SetBottlePositon(Vector3 pos)
    {
        bottlePositon = new Vector3(-60, pos.y, pos.z);
        if (isMove)
        {
            bottle.position = Vector3.Lerp(bottle.position, bottlePositon, 0.8f);
            if (Vector3.Distance(bottlePreviousPos, pos) >= 1.0f)
            {
                if (Vector3.Distance(bottlePreviousPos, Vector3.zero) > 0.1f)
                {
                    SetEffectColor(GetDrawColor(pos));
                    DrawTexture(bottle.position * 10, GetDrawColor(pos));
                }
                bottlePreviousPos = pos;
            }
        }
    }
    public override void DrawTexture(Vector3 point,Color color)
    {
        wallPixel = new Vector2(wallTextureWidth * 0.5f + point.z, wallTextureHight * 0.5f + point.y);
        for (int i = 0; i < wallTextureWidth; i++)
        {
            for (int j = 0; j < wallTextureHight; j++)
            {
                if (Vector2.Distance(wallPixel, new Vector2(i, j)) < 30)
                {
                    wallTexture.SetPixel(wallTextureWidth - i, wallTextureHight - j, color);
                }
            }
        }
        wallTexture.Apply();
        wallMaterial.SetTexture("_SecondTex", wallTexture);
    }
  
}


