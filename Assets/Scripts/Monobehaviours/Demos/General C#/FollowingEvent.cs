using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowingEvent : MonoBehaviour
{
    [SerializeField] private GameObject EventDispatcher;
    int variable;
    void Start()
    {
        EventDispatcher.GetComponent<DestroyOvertime>().OnDestroyed += CheckIfGameOver;
        EventDispatcher.GetComponent<DestroyOvertime>().OnDestroyed += CheckIfGameOver;
        EventDispatcher.GetComponent<DestroyOvertime>().OnDestroyed += CheckIfGameOver;
    }

    private void DoASpin()
    {
        Debug.Log("Spinning");
    }

    private void CheckIfGameOver(int args1)
    {
        if (args1 == 6) Debug.Log("Game Over");
        if(args1 == 8) Debug.Log("Game Started");
    }
}
