using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VectorDemonstrationType
{
    VectorDefinition,
    VectorArithmetic,
    VectorLength, 
    Standard6VectorDirections, 
    DotProduct,
    DistanceAndDirection
}
public class VectorDemo : MonoBehaviour
{
    [SerializeField] GameObject StartingObj;
    [SerializeField] GameObject EndingObj;
    [SerializeField] VectorDemonstrationType VectorDemonstrationType;


    void Start()
    {
        switch (VectorDemonstrationType)
        {
            case VectorDemonstrationType.VectorDefinition:
                
                break;
            case VectorDemonstrationType.VectorArithmetic:
                // Vector Addition

                // Scalar multiplication

                break;
            case VectorDemonstrationType.VectorLength:
                // Cover calculating it out by hand

                // Then look at Unity function

                break;
            case VectorDemonstrationType.Standard6VectorDirections:
                // Vector3.Properties


                // Transform.Properties
                Vector3 vec = transform.right;

                break;
            case VectorDemonstrationType.DotProduct:
                // Covering calculating it by hand

                // What does the value represent (definition)
                break;
            case VectorDemonstrationType.DistanceAndDirection:
                // Exercise: Get the direction for AB

                // Exercise: Get the distance between AB

                // Parrallelogram Rule
                break;
            default:
                break;
        }
    }

    void Update()
    {

        switch (VectorDemonstrationType)
        {
            case VectorDemonstrationType.VectorDefinition:
                Debug.DrawLine(StartingObj.transform.position, EndingObj.transform.position);
                //Debug.DrawLine(new Vector3(0, 0, 0), transform.position);
             
                break;
            case VectorDemonstrationType.VectorArithmetic:
                Debug.DrawLine(StartingObj.transform.position, EndingObj.transform.position);

                Vector3 Offset = new Vector3(0, 0, 0);
                Debug.DrawLine(StartingObj.transform.position, EndingObj.transform.position + Offset);

                // Exercise, calculate the vector that represents the direction from start to end
                break;
            case VectorDemonstrationType.VectorLength:

                break;
            case VectorDemonstrationType.Standard6VectorDirections:

                break;
            case VectorDemonstrationType.DotProduct:

                break;
            case VectorDemonstrationType.DistanceAndDirection:

                break;
            default:
                break;
        }

        
    }

}
