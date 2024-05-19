using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RobotAnimationSFXEvents : MonoBehaviour
{
    [SerializeField] private EventReference FootstepSFX;
    [SerializeField] private EventReference AirWhooshSFX;

    public void PlayFootstepBase()
    {
        FmodEvents.PlayOneShot(FootstepSFX, transform.position);
    }

    public void AirWhoosh()
    {
        FmodEvents.PlayOneShot(AirWhooshSFX, transform.position);
    }
}
