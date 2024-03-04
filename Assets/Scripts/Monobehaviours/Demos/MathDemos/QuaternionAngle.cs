using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuaternionAngle : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private TMP_Text _Quaternion;
    [SerializeField] private TMP_Text _Vector;
    [SerializeField] private TMP_Text _Dot; // https://www.youtube.com/shorts/xlnkTEyAx7Q

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.right * -2f, Color.red, .1f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 2f, Color.green, .1f);
        Debug.DrawLine(transform.position, Target.transform.position, Color.red, .1f);

        _Quaternion.text = $"Quat: {(int)Quaternion.Angle(transform.rotation, Target.transform.rotation)}";
        _Vector.text = $"Vector: {(int)Vector3.Angle(transform.position, transform.position - Target.transform.position)}";
        _Dot.text = $"Dot: {(int)Vector3.Dot(transform.up, transform.position - Target.transform.position)}";
    }
}
