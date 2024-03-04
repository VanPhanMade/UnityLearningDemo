using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitieStats", menuName = "ScriptableObjects/AbilitieStats")]
public class Abilities : ScriptableObject
{
    [field: SerializeField] [field: Range(0, 10)] public float CoolDown { get; private set; }
    [field: SerializeField] [field: Range(0, 100)] public float Damage { get; private set; }

}
