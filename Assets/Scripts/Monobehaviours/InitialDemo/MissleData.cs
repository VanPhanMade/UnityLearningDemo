using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monobehaviours.Missile
{
    public class MissleData : MonoBehaviour
    {
        [SerializeField] private MeshFilter MeshFilter;
        [SerializeField] private MeshRenderer MeshRenderer;
        private float speed;
        private float damage;
        public void Init(float newSpeed, float newDamage, Mesh newMesh, Material newMaterial)
        {
            speed = newSpeed;
            damage = newDamage;
            MeshFilter.mesh = newMesh;
            MeshRenderer.material = newMaterial;
        }
    }
}

