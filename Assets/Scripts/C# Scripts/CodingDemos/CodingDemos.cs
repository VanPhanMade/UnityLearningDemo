using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodingDemo
{
    #region C# SYNTAX
    public class CSHARP_SYNTAX
    {
        public event Action OnHit;

        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags

        /// <summary>
        /// This is our constructor
        /// <para> This is an introductory paragraph. </para>
        ///<para> This paragraph contains more details. </para>
        /// </summary>
        public CSHARP_SYNTAX()
        {
            // Binary operator
            int Number = 6 + 5;

            //Ternary operator
            // First argument is the condition
            // Second is if true
            // Third after semicolon is false
            bool playerWon = true;
            int Score = playerWon ? 500 : 100;

            OnHit += () => { Debug.Log("Syntax demo"); };
            OnHit?.Invoke();
            Sum(1, 1);
            Sum(1, 1, Number);
            CSHARP_SYNTAX ConstructorInsideItself = new(10);
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="a">Example parameter</param>
        public CSHARP_SYNTAX(int a)
        {
            Debug.Log($"Constructor overloaded w/ param {a}");
            FibonacciSeries(2, 3, 1, 12);
        }

        /// <summary>
        /// Returns the sum of a + b
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>The sum of a + b</returns>
        int Sum(int a, int b)
        {
            return a + b;
        }

        // Function overloading
        int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        public void FibonacciSeries(int firstNumber, int secondNumber, int counter, int number)
        {
            Debug.Log(firstNumber + " ");
            if (counter < number)
            {
                FibonacciSeries(secondNumber, firstNumber + secondNumber, counter + 1, number);
            }
        }
    }
        #endregion

        #region STACK HEAP STATIC VALUES DEMO
        public class Stack_Heap_Static_ValuesDemo
        {
        // Fields
        float NumberOnHeap = 0;
        StackClass stackClass = new();

        // Constructor
        public Stack_Heap_Static_ValuesDemo()
        {
            NumberOnHeap = 6;
            //float NumberOnStack = 7;
            Init();
            StaticValueOutsider SomeClass = new();
        }

        public void Init()
        {
            //NumberOnStack = 8;
            for (int i = 0; i < 2; i++)
            {
                //float NumberInLoop = 6;
                NumberOnHeap += 1;
            }
            //NumberOnHeap += NumberInLoop
            //Debug.Log($"Current heap number value: {NumberOnHeap}");
            //stackClass.ChangeNumber(NumberOnHeap);
            //Debug.Log($"Current heap number value after change 1 : {NumberOnHeap}");

            //stackClass.ChangeNumber(ref NumberOnHeap);
            //Debug.Log($"Current heap number value after change 2 : {NumberOnHeap}");

            //StackClass.StaticNum = 7;
            //Debug.Log($"Current static number value after change 1 : {StackClass.StaticNum}");

            //StackClass.ChangeStaticNum(8);
            //Debug.Log($"Current static number value after change 2 : {StackClass.StaticNum}");
        }
    }

    public class StackClass
    {
        public static float StaticNum;
        public StackClass()
        {
            StaticNum = 0;
        }
        public float AddNumbers(float a, float b)
        {
            return a + b;
        }

        public float ChangeNumber(float a)
        {
            a = 381231f;
            return a;
        }

        public float ChangeNumber(ref float a)
        {
            a = UnityEngine.Random.Range(0f, 2000f);
            return a;
        }

        public static void ChangeStaticNum(float a)
        {
            StaticNum = a;
        }
    }

    public class StaticValueOutsider
    {
        public StaticValueOutsider()
        {
            Debug.Log($"Static class value: {StackClass.StaticNum}");
        }
    }
    #endregion

    #region EVENT DEMO
    public class EventDemo
    {
        // https://www.youtube.com/watch?v=J01z1F-du-E&t=229s
        public delegate bool OnCheckNumber(int a); // Type signature
        public OnCheckNumber CheckNumberEvent;     // The event
        public static OnCheckNumber GlobalCheckNumberEvent;
        public static event OnCheckNumber GlobalCheckNumberEvent_Keyworded;

        public EventDemo()
        {
            // Left hand address -> Right hand data application
            CheckNumberEvent += ExampleCheckNumberFunction;
            CheckNumberEvent = null;
            CheckNumberEvent = ExampleCheckNumberFunction;

            CheckNumberEvent?.Invoke(10);
            GlobalCheckNumberEvent_Keyworded?.Invoke(10);

            //ObserverClass observerClass = new();
        }

        private bool ExampleCheckNumberFunction(int a)
        {
            Debug.Log("Event demo check");
            return false;
        }
    }

    // Used to observe scope
    public class ObserverClass
    {
        public event Action<int, bool> OnActionFired;

        public event Func<bool, float> OnFuncFired;
        public ObserverClass()
        {
            EventDemo.GlobalCheckNumberEvent += 
            (int a) => 
            { 
                Debug.Log("Different class"); 
                return true; 
            };

            EventDemo.GlobalCheckNumberEvent = null;
            //EventDemo.GlobalCheckNumberEvent_Keyworded = null;
            //EventDemo.GlobalCheckNumberEvent_Keyworded +=
            //(int a) =>
            //{
            //    Debug.Log("Different class");
            //    return true;
            //};
            //EventDemo.GlobalCheckNumberEvent_Keyworded?.Invoke(10);

            OnActionFired += (int a, bool b) => 
            {
                string StringResult = "";
                if(a < 10)
                {
                    StringResult += $"A less than 10";
                }
                if(b)
                {
                    StringResult += $"B is true";
                }
                Debug.Log(StringResult);
            };

            OnActionFired?.Invoke(7, false);

            OnFuncFired +=
            (bool conditional) =>
            {
                if(conditional == true)
                {
                    return 100f;
                }
                return 50f;
            };

            Debug.Log($"Func Result: {OnFuncFired?.Invoke(false)}");
            


        }
    }
    #endregion

    #region INTERFACE DEMO
    /// <summary>
    /// Display interface logic
    /// </summary>
    public class InterfaceDemo
    {
        public InterfaceDemo()
        {
            GenericAnimal genericAnimal = new();
            GenericBird genericBird = new();
            GenericFish genericFish = new();
            List<IAnimal> animals = new();
            animals.Add(genericAnimal);
            animals.Add(genericBird);
            animals.Add(genericFish);
            foreach (IAnimal animal in animals)
            {
                animal.Move();
                if (animal is IMammal)
                {
                    IMammal mammal = animal as IMammal;
                    mammal.GiveBirth();
                }
            }
        }

        public void TellAnimalsToMove(IAnimal animal)
        {
            animal.Move();
        }
    }
    #region INTERFACES
    public class Squirrel : IMammal
    {
        public void GiveBirth()
        {
            Debug.Log("Squirrel giving birth.");
        }

        public void Move()
        {
            Debug.Log("Squirrel climbing up tree.");
        }
    }
    public class GenericAnimal : IAnimal
    {
        public void Move()
        {
            Debug.Log("Demo Movement");
        }
    }
    public class GenericFish : IAnimal
    {
        public void Move()
        {
            Debug.Log("Swimming");
        }
    }
    /// <summary>
    /// Double Interface example
    /// </summary>
    public class GenericBird : IAnimal, IBreathAir
    {
        float IBreathAir.MaxLungCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        event Action IBreathAir.OnBreathOut
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Move()
        {
            Debug.Log("Flying");
        }

        void IBreathAir.BreathAir()
        {
            throw new NotImplementedException();
        }
    }
    public interface IAnimal
    {
        void Move();
    }
    public interface IBreathAir
    {
        event Action OnBreathOut;
        float MaxLungCapacity { get; set; }
        void BreathAir();
    }
    public interface IMammal : IAnimal
    {
        public void GiveBirth();
    }
    #endregion
    #endregion

    

    


}

