using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMODUnity;
using FMOD.Studio;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 4f;
    [SerializeField] public EventReference fireTrailSFX;

    private EventInstance fireballTraillInstance;
    void OnEnable()
    {
        fireballTraillInstance = FmodEvents.CreateEventInstance(fireTrailSFX);
        Invoke("SelfClean", 2);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        PLAYBACK_STATE playbackState;
        fireballTraillInstance.getPlaybackState(out playbackState);
        if(playbackState == PLAYBACK_STATE.STOPPED)
        {
            fireballTraillInstance.start();
        }
    }

    void SelfClean()
    {
        fireballTraillInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Destroy(gameObject);
    }
}
