using System.Collections;
using UnityEngine;

public class QuaternionIdentity : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        transform.rotation = Quaternion.identity;
    }
}
