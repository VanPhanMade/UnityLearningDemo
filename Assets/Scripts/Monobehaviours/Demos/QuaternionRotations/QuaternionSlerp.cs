using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionSlerp : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float SLInterpLength = 1;

    private Quaternion TargetRotation;
    private Quaternion CurrentRotation;
    private float deltaTime;


    void FixedUpdate()
    {
        
        if((deltaTime/ SLInterpLength) <= 1)
        {
            deltaTime += Time.deltaTime;
            TargetRotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);
            CurrentRotation = transform.rotation;
            transform.rotation = Quaternion.Slerp(CurrentRotation, TargetRotation, deltaTime / SLInterpLength);
        }
        else
        {
            deltaTime = 0;
        }

    }
}
