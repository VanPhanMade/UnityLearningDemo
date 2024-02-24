using UnityEngine;

public class QuaternionLookAt : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, Target.transform.position, Color.red, .1f);
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);
    }
}
