using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ForwardSurfaceView : SurfaceView
{
    RaycastHit hit;
    Vector3 cameraToTarget;
    public override void Init()
    {
        base.Init();
        bottlePositon = new Vector3(0, 0, 44.91f);
        wallMaterial = wallBox.transform.GetChild(4).gameObject.GetComponent<MeshRenderer>().material;
        wallTextureWidth = 1200;
        wallTextureHight = 900;
        wallTexture = new Texture2D(wallTextureWidth, wallTextureHight,TextureFormat.ARGB32,false);
        wallTextureInit();
    }
    void Update()
    {
        wallFlashAnimation.Update(Time.deltaTime);
    }
    public override void SetBottlePositon(Vector3 pos)
    {
        bottlePositon = new Vector3(pos.x, pos.y, 44.91f);
        if (isMove)
        {
            bottle.position = Vector3.Lerp(bottle.position, bottlePositon, 0.8f);
            cameraToTarget = bottle.position - Camera.main.gameObject.transform.position;
            if (Physics.Raycast(Camera.main.gameObject.transform.position, cameraToTarget, out hit, 300.0F, 1 << LayerMask.NameToLayer("wallForward")))
            {
                if (Vector3.Distance(bottlePreviousPos, pos) >= 1.0f)
                {
                    if (Vector3.Distance(bottlePreviousPos, Vector3.zero) > 0.1f)
                    {
                        SetEffectColor(GetDrawColor(pos));
                        DrawTexture(hit.point * 10, GetDrawColor(pos));
                    }
                    bottlePreviousPos = pos;
                }
            }
        }
    }
	public override void DrawTexture (Vector3 point,Color color)
	{
        wallPixel = new Vector2(wallTextureWidth * 0.5f + point.x, wallTextureHight * 0.5f + point.y);
        for (int i = 0; i < wallTextureWidth; i++)
        {
            for (int j = 0; j < wallTextureHight; j++)
            {
                if (Vector2.Distance(wallPixel, new Vector2(i, j)) < 30)
                {
                    wallTexture.SetPixel(i, j, color);
                }
            }
        }
        wallTexture.Apply();
        wallMaterial.SetTexture("_SecondTex", wallTexture);
	}
}

