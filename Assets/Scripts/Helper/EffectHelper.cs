using System;
using UnityEngine;
public class EffectHelper
{
    public static void SinglePartical(GameObject _effect, bool _bol)
    {
        ParticleSystem[] sys = _effect.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < sys.Length; i++)
        {
            if (_bol)
                sys[i].Play();
            else
                sys[i].Stop();
        }
    }
    public static ParticleSystem GetSinglePartical(GameObject _parent)
    {
        return _parent.GetComponentsInChildren<ParticleSystem>()[0];
    }
    public static void UpdateParticalColor(ParticleSystem _effectSys, Color color)
    {
        ParticleSystem.MainModule pm = _effectSys.main;
        pm.startColor = color;
    }
}

