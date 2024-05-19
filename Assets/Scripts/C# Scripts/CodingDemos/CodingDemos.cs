using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

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
        /// <para> This paragraph contains more details. </para>
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

            // Adding lambdas
            OnHit += () => { Debug.Log("Syntax demo"); };
            OnHit?.Invoke();

            // Function overloading
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
            // [1][3]
            List<int> numbers = new List<int>();
            numbers.Add(1); // 0
            numbers.Add(3); // 1
            Debug.Log($"{numbers[0]}");

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

        void FireCannons()
        {

            // Fire at the mouse position
        }

        void FireCannons(GameObject otherShip)
        {

        }

        void Swap<Type>(ref Type lhs, ref Type rhs)
        {
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods
            Type temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
    #endregion

    #region ENUMS
    public class EnumDemo
    {
        public EnumDemo()
        {
            WeaponRarity weaponRarity = WeaponRarity.Common;

            switch (weaponRarity)
            {
                case WeaponRarity.Common:
                    break;
                case WeaponRarity.Uncommon:
                    break;
                case WeaponRarity.Rare:
                    break;
                case WeaponRarity.Epic:
                    break;
                case WeaponRarity.Legendary:
                    break;
                default:
                    break;
            }

            Debug.Log($"Points awarded: {AwardPoints(Achievement.QuadraKill)}");

            //if(weaponRarity == null)
            //{

            //}
        }

        public int AwardPoints(Achievement achievement)
        {
            return (int)achievement;
        }

        public enum WeaponRarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
        public enum Achievement : int
        {
            Headshot = 10,
            DoubleKill = 20,
            TripleKill = 25,
            QuadraKill = 30,
            PentaKill = 50
        }

        private WeaponRarity? Nullable;
    }
    #endregion

    #region STACK HEAP STATIC VALUES DEMO
    public class Stack_Heap_Static_ValuesDemo
    {
        // Fields
        private float NumberOnHeap = 0;
        StackClass stackClass = new();

        // Constructor
        public Stack_Heap_Static_ValuesDemo()
        {
            NumberOnHeap = 6;
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

    public static class ExtensionMethods
    {
        // This will extend from transform
        public static void ResetTransformation(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
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

            return false;
        }

    }

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
                if (a < 10)
                {
                    StringResult += $"A less than 10";
                }
                if (b)
                {
                    StringResult += $"B is true";
                }
                Debug.Log(StringResult);
            };

            OnActionFired?.Invoke(7, false);

            OnFuncFired +=
            (bool conditional) =>
            {
                if (conditional == true)
                {
                    return 100f;
                }
                return 50f;
            };

            Debug.Log($"Func Result: {OnFuncFired?.Invoke(false)}");



        }
    }
    #endregion

    #region ABSTRACT CLASSES DEMO
    public class AbstractClassDemo
    {
        public AbstractClassDemo()
        {
            // Exercise 1: Create a raft + buoyant object
            // BuoyantObject buoyantObject = new BuoyantObject();

            // Exercise 2: Create an aerial object + plane
            Biplane biplane = new Biplane();
        }
    }

    // Direct Inheritance
    class BuoyantObject
    {
        public BuoyantObject()
        {
            Debug.Log("Created BuoyantObject");
        }

        protected int size = 0;

        public void Move()
        {
            Debug.Log($"Moving {size}' sized boat!");
        }
    }

    class Raft : BuoyantObject
    {

    }

    abstract class AerialObject
    {
        protected int size = 0;

        // Must be public since variables are private by default
        public abstract void Fly();
    }

    class Biplane : AerialObject
    {
        public override void Fly()
        {
            Debug.Log("Fly");
        }
    }

    // Demonstrate virtual/overrideable functions
    class SailBoat : BuoyantObject
    {
        public virtual void HoistSails()
        {
            Debug.Log("Raising ship sails!");
        }
    }

    class PirateShip : SailBoat
    {
        public virtual void HostSails()
        {
            base.HoistSails();
            Debug.Log("Raising Flag");
        }

        //public override void HoistSails()
        //{
        //    base.HoistSails();
        //    Debug.Log("Raising Flag");
        //}
    }

    class BigPirateShip : PirateShip
    {
        //public override void HoistSails()
        //{
        //    base.HoistSails();
        //    Debug.Log("Raising Flag");
        //}
    }

    //public class SeaPlane : AerialObject, BuoyantObject
    //{

    //}
    // This starts the introduction to interfaces

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

    #region DOT_NET_DEMO
    // https://dotnet.microsoft.com/en-us/languages/csharp
    // https://learn.microsoft.com/en-us/dotnet/csharp/linq/
    // https://www.youtube.com/watch?v=D2K0J5tiRtc&t=5s
    // Using System.Linq
    
    public struct Stats
    {
        public int Damage;
        public float AttackRange;
        public int Strength;
        public int Wisdom;
    }
    public enum Faction
    {
        Human, 
        Goblin,
        Orc, 
        Elf,
        NONE
    }
    public class NPC
    {
        public int Health;
        public Stats Stats;
        public Faction Faction;

        public NPC()
        {
            Health = UnityEngine.Random.Range(0, 100);
            Stats.Damage = UnityEngine.Random.Range(0, 100);
            Stats.AttackRange = UnityEngine.Random.Range(0, 100);
            Stats.Strength = UnityEngine.Random.Range(0, 100);
            Stats.Wisdom = UnityEngine.Random.Range(0, 100);
            Faction = (Faction)UnityEngine.Random.Range(0, 5);
        }

        public NPC(Faction _Faction, Stats _Stats, int _Health = 100)
        {
            Faction = _Faction;
            Health = _Health;
            Stats = _Stats;
        }
    }

    public class DOT_NET_EXAMPLES
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-8.0
        public NPC[] Npcs = { new(), new(), new(), new(), new(), new(), new() }; 
        public DOT_NET_EXAMPLES()
        {
            List<NPC> demoNPCs = new();
            NPC Jill = new();
            NPC Joe = new();
            NPC Steve = new();
            NPC TJ = new();
            NPC HiddenElf = new();
            HiddenElf.Stats.Damage = 20;
            HiddenElf.Faction = Faction.Elf;
            demoNPCs.Add(Jill);
            demoNPCs.Add(Joe);
            demoNPCs.Add(Steve);
            demoNPCs.Add(TJ);
            //demoNPCs.Add(HiddenElf);

            int numberA = 6; numberA += 6;

            int numberB = numberA;

            // Left hand                    // Right hand                       // Two functions
            Action exampleAction = () => { Debug.Log("Hello");  }; exampleAction += () => { Debug.Log("Hello");  };
            // exampleAction.Invoke();

            Action<int, int> exampleActionWithIntArg = 
                (x, y) => { Debug.Log( x * x ); };

            Func<int, string ,int> funcExample = (someNumber, someString) => { return someNumber + 2; };

            int exampleCalculation = funcExample.Invoke(6, "MyName");

            CustomFunctionRepeaterWithIntArg( x => { Debug.Log(x * x); }, 4);

            //SomeFunctionB(6); 

            // 6, 7, or 8
            CustomFunctionRepeater( () => { Debug.Log("Hello"); }, 5);

            bool hasAtleastOneElf = Npcs.Any(
                (npc) =>
                {
                    return npc.Faction == Faction.Elf /*&& npc.Stats.Damage > 10 */;
                }
                );

            if (hasAtleastOneElf) Debug.Log("We have an elf npc");


            double AverageHealth = Npcs.Average(npc => npc.Health);

            List<NPC> HumanCharacters = Npcs.Where(npc => npc.Faction == Faction.Human).ToList();

            double AverageHumanStrength = Npcs
                .Where(npc => npc.Faction == Faction.Human)
                .Average(npc => npc.Stats.Strength);

            //int totalStrengthOfNPCs = Npcs.Sum(npc => npc.Stats.Strength);

            //int numberOfHumans = Npcs.Count(npc => npc.Faction == Faction.Human);

            //List<NPC> npcList = new List<NPC>();
            //NPC Bob = new();
            //npcList.Add(Bob);
            //npcList.Add(Bob);
            //List<NPC> uniqueNPCs = npcList.Distinct().ToList();

            //NPC firstDeadNpc = npcList.FirstOrDefault(npc => npc.Health <= 0);

            //var npcsByHealthMinToMax = npcList.OrderBy(npc => npc.Health); 
            //List<NPC> npcsByFactionList = npcsByHealthMinToMax.ToList();

            //var npcsByHealthMaxToMin = uniqueNPCs.OrderByDescending(npc => npc.Health);

            //var randomOrderNPCs = uniqueNPCs.OrderBy(npc => UnityEngine.Random.Range(0,100));

            //var npcsByFaction = npcList.GroupBy(npc => npc.Faction);
            //foreach (var group in npcsByFaction)
            //{

            //    foreach (var npc in group)
            //    {
            //    }
            //}

            //var npcsWhoAreElves = Npcs.Where(npc => npc.Faction == Faction.Elf);
            //var npcsWhoHaveNoHealth = Npcs.Where(npc => npc.Health <= 0);
            //                                    // First collection     // Second collection
            //var npcsWhoAreBothElvesAndDead = npcsWhoAreElves.Intersect(npcsWhoHaveNoHealth);

            //int minStrength = Npcs.Min(npc => npc.Stats.Strength);
            //int maxStrength = Npcs.Max(npc => npc.Stats.Strength);

            //// Select - changes an array to array of a different type
            //var uniqueActiveFactions = Npcs.Where(npc => npc.Health > 0).Select(npc => npc.Faction).Distinct();

            //// Page example
            //int pageSize = 10;
            //int pageNumber = 1;
            //var nextPageOfNpcs = Npcs
            //    .Skip(pageSize * pageNumber)
            //    .Take(pageSize);

            //List<NPC> npcListConvert = Npcs.ToList();
            //Npcs = npcListConvert.ToArray();

            //Dictionary<Faction, List<NPC>> dictionaryNpcsByFaction = Npcs
            //    .GroupBy(key => key.Faction, value => value)
            //    .ToDictionary(key => key.Key, value => value.ToList());

            //// https://learn.microsoft.com/en-us/archive/msdn-magazine/2017/march/net-framework-immutable-collections
            //var npcsLookup = Npcs.ToLookup(key => key.Faction, value => value);

            //var elves = npcsLookup[Faction.Elf];
            //var orcs = npcsLookup[Faction.Orc];
        }

        public void CustomFunctionRepeater(Action someFunction, int iterations)
        {
            for (int i = 0; i < iterations; i++) someFunction?.Invoke();
        }

        public void CustomFunctionRepeaterWithIntArg(Action<int> someIntFunction, int iterations)
        {
            for (int i = 0; i < iterations; i++) someIntFunction.Invoke(i);
        }

        public void ConditionalNodeExample(Func<bool> conditional, Action onSuccess, Action onFail)
        {
            if (conditional.Invoke()) onSuccess?.Invoke();
            else  onFail?.Invoke();
        }

        public void SomeFunction()
        {
            Debug.Log("I did something");
        }
                                // Arguments
        public void SomeFunctionB(int blahblah)
        {
            Debug.Log($"Int arg: {blahblah}");
        }

        public void DebugSumAdd(int a, int b)
        {
            Debug.Log($"{ a + b}");
        }

        public int RandomNumberThing()
        {
            return 23109 + 12321;
        }
    }

    #endregion

    #region OPERATOR_OVERLOADING_DEMO

    #endregion

    #region COMMON_DATASTRUCTURES
    public class Common_DataStructures
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/collections/
        public Common_DataStructures()
        {
            List<int> numbersList = new();
            numbersList.Add(12);
            numbersList.Add(13);
            //Debug.Log(numbersList[1]);
            // [ 0 ]
            // array int
            // [ 12 ] [ 13 ] [ 14 ]
            // [ 0  ] [ 1  ] [ 2  ]

            // 2D array example
            List<List<string>> String2DArray = new();
            List<string> stringList = new();
            stringList.Add("Ryan");

            String2DArray.Add(stringList);
            //Debug.Log(String2DArray[0][0]);

            //        [ key ]  [ value ] 
            Dictionary<string, float> numbersDictionary = new Dictionary<string, float>();
            // [ data1 ] [ data2 ] [ data3 ]
            // [ key1 ]  [ key2  ] [ key3  ]
            numbersDictionary.Add("Cruiser", 3);
            float cruiser = numbersDictionary["Cruiser"];
            //Debug.Log(cruiser);

            Dictionary<string, List<string>> numbers2D_Dictionary = new Dictionary<string, List<string>>();
            numbers2D_Dictionary.Add("Ryan", stringList);
            //Debug.Log(numbers2D_Dictionary["Ryan"][0]);

            Stack<string> numbersStack = new Stack<string>();
            numbersStack.Push("Attacked");
            numbersStack.Push("Jumped");
            Debug.Log(numbersStack.Peek());
            Debug.Log(numbersStack.Pop() + " & " + numbersStack.Pop());

            Queue<string> numbersQueue = new Queue<string>();
            numbersQueue.Enqueue("Run");
            numbersQueue.Enqueue("Walk");
            Debug.Log(numbersQueue.Dequeue());
        }
    }
    #endregion

}

