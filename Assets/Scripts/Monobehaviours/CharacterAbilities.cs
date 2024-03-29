using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ScriptableObjects.MissleStats;
using Monobehaviours.Missile;
using UnityEngine.Pool;
using Scripts.CharacterSwappingStates;


public class CharacterAbilities : MonoBehaviour
{
    #region Fields
    [field: SerializeField] public MissileStats missileStats { get; private set; }

    [SerializeField] private GameObject missilePrefab;

    [SerializeField] private Animator AbilityAnimator;

    [SerializeField] private AudioSource PlayerAudioSource;

    private event Action AttackEvent;
    private event Action CannonsClosedEvent;
    private event Func<bool> CannonsOpenEvent;

    private ObjectPool<MissleMovement> misslePool;

    private bool bCannonsOpen = false;

    private AudioClip SFXCannonShot;
    #endregion

    #region Unity
    private void Awake()
    {
        if (missilePrefab == null) missilePrefab = Resources.Load<GameObject>("Prefabs/Missile");
        if (missilePrefab == null) throw new System.Exception($"CharacterAbilities ({this.gameObject.name}): Couldn't find Missile Prefab.");
        if (missileStats == null) throw new System.Exception($"CharacterAbilities ({this.gameObject.name}): Doesn't have Missile Stats.");

        if (AbilityAnimator == null) AbilityAnimator = GetComponent<Animator>();
        if (AbilityAnimator == null) throw new System.Exception($"Class ({this.gameObject.name}): Missing an animator");

        if (SFXCannonShot == null) SFXCannonShot = Resources.Load<AudioClip>("Audio/CannonShot");
        if (SFXCannonShot == null) throw new System.Exception($"Class ({this.gameObject.name}): Missing cannon audio clip");

        if (PlayerAudioSource == null) PlayerAudioSource = GetComponent<AudioSource>();
        if (PlayerAudioSource == null) throw new System.Exception($"Class ({this.gameObject.name}): Missing an audio source component");

        AttackEvent += Attack;
        CannonsClosedEvent += () =>
        {
            bCannonsOpen = false;
        };
        CannonsOpenEvent += () =>
        {
            bCannonsOpen = true;
            return bCannonsOpen;
        };

        misslePool = new ObjectPool<MissleMovement>(
            SpawnObject,
            missileMovement => {
                missileMovement.gameObject.SetActive(true);
                missileMovement.Init(missileStats.Speed);
                missileMovement.gameObject.transform.position = new Vector3(0, 1, 0) + transform.forward * 2 + transform.position;
                missileMovement.GetComponent<MissleData>().Init(missileStats.Speed, missileStats.Damage, missileStats.MissleMesh, missileStats.MissleMaterial);
            },
            missileMovement => { missileMovement.gameObject.SetActive(false); },
            missileMovement => { Destroy(missileMovement.gameObject); },
            false,
            2, 5
        );


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AttackEvent?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Missile Mode");
            AttackEvent = null;
            AttackEvent += AbilityOne;
            OnSwitchAbilities();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Cannon Mode");
            AttackEvent = null;
            AttackEvent += AbilityTwo;
            OnSwitchAbilities();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Plane mode");
            AttackEvent = null;
            AttackEvent += AbilityThree;
            OnSwitchAbilities();
        }
    }
    #endregion

    #region CharacterAbilities
    public virtual void Attack()
    {
        Debug.Log("Player attacked!");
    }

    MissleMovement SpawnObject()
    {
        return GameObject.Instantiate(missilePrefab).GetComponent<MissleMovement>();
    }

    public virtual void AbilityOne()
    {
        MissleMovement newMissile = misslePool.Get();
        newMissile.MissleOutOfGas += () => { misslePool.Release(newMissile); };
    }
    public virtual void AbilityTwo()
    {
        if (bCannonsOpen == false)
        {
            AbilityAnimator.Play("OpenCannons", 0);
        }
        else
        {
            PlayerAudioSource.PlayOneShot(SFXCannonShot, .1f);
            Debug.Log("Firing cannons!");
        }
    }
    public virtual void AbilityThree()
    {
        CharacterSwappingStates.CurrentUsedCharacter = 1;

        Debug.Log("Player used ability three!");
    }

    public virtual bool AbilityFour()
    {
        
        return false;
    }

    public virtual void OnSwitchAbilities()
    {
        if (bCannonsOpen)
        {
            AbilityAnimator.Play("CloseCannons", 0);
            bCannonsOpen = false;
        }
    }

    // Animation callback events
    public void OnCannonsOpenTrigger()
    {
        CannonsOpenEvent?.Invoke();
    }

    public void OnCannonsClosedTrigger()
    {
        CannonsClosedEvent?.Invoke();
    }
    #endregion

}
