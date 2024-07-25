using UnityEngine;
using FMODUnity;
using FMOD.Studio;

// https://www.youtube.com/watch?v=rcBHIOjZDpk&t=0s
public class FmodEvents
{
    public static void PlayOneShot(EventReference Sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(Sound, worldPosition);
    }

    public static EventInstance CreateEventInstance(EventReference eventReference)
    {
        return RuntimeManager.CreateInstance(eventReference);
    }
}
