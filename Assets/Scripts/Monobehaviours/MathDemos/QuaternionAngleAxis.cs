using UnityEngine;

public class QuaternionAngleAxis : MonoBehaviour
{
    [SerializeField] private float IncrementationSpeed;
    float elapsedTime;
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(elapsedTime * IncrementationSpeed, Vector3.forward);
        Debug.DrawLine(transform.position, transform.position + (transform.up * 5f), Color.green, .1f);
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 5f), Color.blue, .1f);
    }
}
