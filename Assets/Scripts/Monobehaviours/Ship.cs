using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Monobehaviours.Ship
{
    public enum Team
    {
        Red = 0,
        Blue = 1
    }

    public class Ship : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private Team shipTeam;

        [SerializeField] SphereCollider radarCollisionRange;
        public Team ShipTeam { get { return shipTeam; } }

        [Tooltip("Ships that are detected only by line of sight directly from this ship")]
        [SerializeField] private List<Ship> DirectlySpottedShips = new();

        [Tooltip("Ships detected from line of sight or allied ship detection")]
        [SerializeField] private List<Ship> SpottedShips = new();

        [SerializeField] private List<Ship> ShipsThatSeeMe = new();

        public static List<Ship> AllShips = new();

        private WaitForSeconds StartDelay;

        private float radarRange;

        // Events that fire broadcasted to allies when your ship detects an enemy ship
        public event Action<Ship> onDetectedEnemy;
        public event Action<Ship> onUnDetectedEnemy;

        //public event Action onAttack;

        private bool spotted = false;
        #endregion

        #region UNITY
        private void Awake()
        {
            StartDelay = new WaitForSeconds(.1f);
            if (ShipsThatSeeMe == null) SpottedShips = new List<Ship>();
        }

        private void Start()
        {
            foreach (Ship Ship in AllShips)
            {
                if (Ship.ShipTeam == shipTeam)
                {
                    Ship.onDetectedEnemy += DetechedEnemyFromAlly;
                    Ship.onUnDetectedEnemy += UnDetechedEnemyFromAlly;
                }
            }
        }

        private void OnEnable()
        {
            if (radarCollisionRange == null) radarCollisionRange = GetComponent<SphereCollider>();
            if (radarCollisionRange == null) throw new System.Exception($"Ship ({this.gameObject.name}): Couldn't find SphereCollider.");
            radarRange = radarCollisionRange.radius;

            if (AllShips == null) AllShips = new List<Ship>();
            AllShips.Add(this);

            if (SpottedShips == null) SpottedShips = new List<Ship>();

            if (ShipsThatSeeMe == null) SpottedShips = new List<Ship>();

            foreach (Ship Ship in AllShips)
            {
                if (Ship != this)
                {
                    if (Vector3.Distance(this.transform.position, Ship.transform.position) <= radarRange && Ship.ShipTeam != shipTeam)
                    {
                        DirectlySpottedShips.Add(Ship);
                        SpottedShips.Add(Ship);
                    }
                }
            }
        }

        private void Update()
        {
            if (DirectlySpottedShips.Count != 0)
            {
                foreach (Ship enemyShip in DirectlySpottedShips)
                {
                    if (CheckIfEnemyInSight(enemyShip))
                    {
                        if (!SpottedShips.Contains(enemyShip))
                        {
                            SpottedShips.Add(enemyShip);
                            enemyShip.AddNumberOfShipsSpotting(1, this);
                            onDetectedEnemy?.Invoke(enemyShip);
                        }
                    }
                    else
                    {
                        SpottedShips.Remove(enemyShip);
                        enemyShip.AddNumberOfShipsSpotting(-1, this);
                        onUnDetectedEnemy?.Invoke(enemyShip);
                    }
                }
            }
        }

        public void OnTriggerEnter(Collider _other)
        {
            //Debug.Log($"Collision Occured with: {_other.gameObject.name}");
            //if (_other.gameObject.tag != "Ship") return;
            Ship CollidingShip = _other.gameObject.GetComponent<Ship>();
            if (CollidingShip != null)
            {
                if (CollidingShip.ShipTeam != shipTeam)
                {
                    if (!DirectlySpottedShips.Contains(CollidingShip)) DirectlySpottedShips.Add(CollidingShip);
                }
            }
        }

        public void OnTriggerExit(Collider _other)
        {
            //Debug.Log($"Collision Exit Occured with: {_other.gameObject.name}");
            Ship CollidingShip = _other.gameObject.GetComponent<Ship>();
            if (CollidingShip == null) _other.gameObject.GetComponentInParent<Ship>();

            if (CollidingShip != null)
            {
                if (CollidingShip.ShipTeam != shipTeam)
                {
                    DirectlySpottedShips.Remove(CollidingShip);
                }
            }
        }
        #endregion

        #region SHIP
        public virtual bool AddNumberOfShipsSpotting(int ShipsSpottingIterator, Ship Spotter)
        {
            if (ShipsSpottingIterator > 0)
            {
                ShipsThatSeeMe.Add(Spotter);
            }
            else
            {
                ShipsThatSeeMe.Remove(Spotter);
            }

            if (ShipsThatSeeMe.Count >= 1)
            {

                spotted = true;
                return spotted;
            }
            else
            {
                spotted = false;
                return false;
            }
        }

        public virtual bool CheckIfEnemyInSight(Ship EnemyShip)
        {

            if (Physics.Raycast(transform.position, EnemyShip.transform.position, out RaycastHit HitData) &&
               Vector3.Distance(transform.position, EnemyShip.transform.position) <= radarRange)
            {
                Debug.DrawLine(transform.position, EnemyShip.transform.position, Color.green);

                return true;
            }
            else
            {
                Debug.DrawLine(transform.position, EnemyShip.transform.position, Color.red);
                return false;
            }

        }

        public virtual void DetechedEnemyFromAlly(Ship EnemyShip)
        {
            if (!this.SpottedShips.Contains(EnemyShip)) this.SpottedShips.Add(EnemyShip);
        }

        public virtual void UnDetechedEnemyFromAlly(Ship EnemyShip)
        {
            if (!this.CheckIfEnemyInSight(EnemyShip)) this.SpottedShips.Remove(EnemyShip);
        }
        #endregion
    }
}

