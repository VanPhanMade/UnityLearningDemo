using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodingDemo
{
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

    #region STACK HEAP STATIC VALUES DEMO
    public class Stack_Heap_Static_ValuesDemo
    {
        float OurNumber = 0;
        StackClass stackClass = new();
        public Stack_Heap_Static_ValuesDemo()
        {
            Init();
        }

        public void Init()
        {
            Debug.Log(stackClass.AddNumbers(OurNumber, 6));
        }
    }

    public class StackClass
    {
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
    }
    #endregion
}

