using UnityEngine;

enum InterpolationType
{
    Linear,
    Slerp,
    Graphical
}
public class LinearInterpolation : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 TargetDestination;
    [SerializeField] float InterpolationTime = 5f;
    [SerializeField] float Distance = 10f;
    [SerializeField] InterpolationType InterpolationType;
    [SerializeField] AnimationCurve CurveData;
    private float deltaTime;

    void Start()
    {
        StartPos = transform.position;
        TargetDestination = StartPos + (transform.right * Distance);
    }

    void FixedUpdate()
    {
        Debug.DrawLine(StartPos, transform.position, Color.green, .1f);
        deltaTime += Time.deltaTime;
        if (InterpolationType == InterpolationType.Linear)
        {
            transform.position = Vector3.Lerp(StartPos, TargetDestination, deltaTime / InterpolationTime);
        }
        if(InterpolationType == InterpolationType.Slerp)
        {
            transform.position = Vector3.Slerp(StartPos, TargetDestination, deltaTime / InterpolationTime);
        }
        if(InterpolationType == InterpolationType.Graphical)
        {
            transform.position = Vector3.Lerp(StartPos, TargetDestination, CurveData.Evaluate(deltaTime / InterpolationTime));
        }
        
    }
}
