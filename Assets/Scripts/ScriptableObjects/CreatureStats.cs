using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.CreatureStats
{
    [CreateAssetMenu(fileName = "CreatureStats", menuName = "ScriptableObjects/CreatureData")]
    public class CreatureStats : ScriptableObject
    {
        [field: SerializeField] [field: Range(0, 100)] public float Health { get; private set; }
        [field: SerializeField] [field: Range(0, 100)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(0, 100)] public float Armor { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}

