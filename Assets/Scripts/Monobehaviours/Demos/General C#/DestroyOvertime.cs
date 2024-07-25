using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyOvertime : MonoBehaviour
{
    [SerializeField] private int delayTime = 2;
    public Action<int> OnDestroyed;
    void Start()
    {
        Invoke("DestroyThisObject", delayTime);
        //OnDestroyed += RandomFunctionTwo;
        //OnDestroyed += RandomFunctionTwo;
        //OnDestroyed += RandomFunctionTwo;
        OnDestroyed +=
        (a) =>
        {
            Debug.Log(a);
        };

        OnDestroyed += LamdaFunction;


        //OnDestroyedFunc(6);
        // OnDestroyedFunc(a);
    }

    public void OnDestroyedFunc(int a)
    {
        LamdaFunction(a);

        Debug.Log(a);
    }

    public void LamdaFunction(int a)
    {
        Debug.Log(a);
    }


    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }

    public int RandomFunction()
    {
        return 8;
    }

    public void RandomFunctionTwo(int a)
    {
        Debug.Log($"argument: {a + a}");
    }

    private void OnDestroy()
    {
        // how many ships are alive?
        OnDestroyed?.Invoke(6);
        // Function (int arg) arg = 6
        // {
        //  Debug.Log(arg);
        // }

        OnDestroyed?.Invoke(8);
    }
}
