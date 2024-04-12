using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ExampleAbstractClass otherShips = other.GetComponent<ExampleAbstractClass>();
        if (otherShips)
        {
            Debug.Log(otherShips.ReturnParentShip().name);
        }
    }
}
