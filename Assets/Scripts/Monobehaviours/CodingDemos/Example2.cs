using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodingDemo
{
    public class Example2 : MonoBehaviour
    {
        //Heap data
        #region Fields
        float Number = 6;
        int Number2 = 7;
        #endregion


        // Stack data
        public void Start()
        {
            // Stack data
            if (Number > Number2)
            {

                float Number3 = 6;
            }


            // 1st chunk intializer 2nd chunk conditional 3rd iterator repeating
            for (Function(); CheckCondition(); RandomFunction())
            {
                
            }

            // break vs return
            for (int i = 0; i < 7; i++)
            {
                break;
            }

            if (Number == 2) Debug.Log("2");
            if (Number == 3) Debug.Log("3");

            if (Number == 4)
            {
                Debug.Log("3");
            }

            switch (Number)
            {
                case 6f:
                    Debug.Log("Number is 6");
                    break;
                case 10f:
                    Debug.Log("Number is 6"); Debug.Log("Number is 6"); Debug.Log("Number is 6"); Debug.Log("Number is 6"); Debug.Log("Number is 6");
                    break;

                default:
                    break;
            }


            float Number4 = 10;

            ExampleClass ExampleAddress = new ExampleClass();
            ExampleAddress.Init();

        }

        void Function()
        {
            Debug.Log("For loop started");
        }

        bool CheckCondition()
        {
            // vvvvvv
            if(Number < Number2)
            {
                return false;
            }

            if(Number == Number2)
            {
                return false;
            }
            return true;
        }

        void RandomFunction()
        {
            Debug.Log($"{Random.Range(1, 20)}");
        }

    }

    public class ExampleClass
    {
        
        public void Init()
        {
            Debug.Log("Example 2 init");
        }
    }
}

