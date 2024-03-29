using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptimizationTest
{
    GetComponent
}
public class ScriptOptimization : MonoBehaviour
{
    [SerializeField] int NumberOfTests = 100;
    [SerializeField] OptimizationTest typeOfTest;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch (typeOfTest)
            {
                case OptimizationTest.GetComponent:
                    GetComponent1();
                    GetComponent2();
                    GetComponent3();
                    break;
                default:
                    break;
            }
        }
    }

    #region GetComponent
    void GetComponent1()
    {
        for (int i = 0; i < NumberOfTests; i++)
        {
            Transform test = (Transform)GetComponent("Transform");
        }
    }
    void GetComponent2()
    {
        for (int i = 0; i < NumberOfTests; i++)
        {
            Transform test = (Transform)GetComponent("Transform").transform;
        }
    }
    void GetComponent3()
    {
        for (int i = 0; i < NumberOfTests; i++)
        {
            Transform test = (Transform)GetComponent(typeof(Transform));
        }
    }
    #endregion


}
