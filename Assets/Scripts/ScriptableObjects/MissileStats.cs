using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.MissleStats
{
    [CreateAssetMenu(fileName = "MissileStats", menuName = "ScriptableObjects/MissileStats")]
    public class MissileStats : ScriptableObject
    {
        [field: SerializeField] [field: Range(0, 100)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(0, 100)] public float Damage { get; private set; }
        [field: SerializeField] public Mesh MissleMesh { get; private set; }
        [field: SerializeField] public Material MissleMaterial { get; private set; }
    }
}

