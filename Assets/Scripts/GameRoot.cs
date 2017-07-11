﻿using UnityEngine;
using strange.extensions.context.impl;
public class GameRoot:ContextView
{
    void Awake()
    {
        context = new GameContext(this,true);
        context.Start();
    }
}