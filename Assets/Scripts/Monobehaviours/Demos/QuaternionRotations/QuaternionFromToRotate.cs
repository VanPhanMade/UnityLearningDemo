using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionFromToRotate : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit HitData, 20f))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, HitData.normal);
            Debug.DrawLine(transform.position, HitData.point, Color.blue, .1f);
        }
        else
        {
            Debug.Log("Missed hit?");
        }
    }
}
