using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EffectAndAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private float timeLength = 0;
    private bool isRunning = false;
    private ParticleSystem effParticle;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        effParticle = EffectHelper.GetSinglePartical(gameObject);
        EffectHelper.SinglePartical(gameObject, false);
    }
    void Update()
    {
        if (isRunning)
            if (timeLength > 0)
            {
                timeLength -= Time.deltaTime;
                if (!audioSource.isPlaying)
                {
                    audioPlay();
                }
                if (timeLength <= 0)
                {
                    effectStop();
                    audioStop();
                }
            }
    }
    void OnEnable()
    {
        isRunning = true;
    }
    void OnDisable()
    {
        isRunning = false;
    }
    public void SeteffectColor(Color color)
    {
        if (timeLength <= 0)
        {
            effectPlay();
        }
        EffectHelper.UpdateParticalColor(effParticle, new Color(color.r,color.g,color.b,0.039f));
        timeLength = 1;
    }
    private void audioPlay()
    {
        audioSource.Play();
    }
    private void audioStop()
    {
        audioSource.Stop();
    }
    private void effectPlay()
    {
        EffectHelper.SinglePartical(gameObject,true);
    }
    private void effectStop()
    {
        EffectHelper.SinglePartical(gameObject,false);
    }
}
