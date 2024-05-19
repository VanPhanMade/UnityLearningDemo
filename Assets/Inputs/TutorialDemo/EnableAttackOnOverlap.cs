using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MoveType
{
    Punch,
    Kick
}
public class EnableAttackOnOverlap : MonoBehaviour
{
    [SerializeField] MoveType moveType;
    private void OnTriggerEnter(Collider other)
    {
        TutorialCharacterInputs character = other.GetComponent<TutorialCharacterInputs>();
        if(character != null)
        {
            character.ClearAttack();
            
            switch (moveType)
            {
                case MoveType.Punch:
                    character.ChangeTutorialText("Punch learned");
                    character.Attack += (ctx) =>
                    {
                        NavMeshAgent AIAgent = character.GetComponent<NavMeshAgent>();
                        if (AIAgent) AIAgent.SetDestination(AIAgent.transform.position);

                        Animator characterAnimator = character.GetComponent<Animator>();
                        if (characterAnimator) characterAnimator.Play("Jab Cross");

                    };
                    break;
                case MoveType.Kick:
                    character.ChangeTutorialText("Kick learned");
                    character.Attack += (ctx) =>
                    {
                        NavMeshAgent AIAgent = character.GetComponent<NavMeshAgent>();
                        if (AIAgent) AIAgent.SetDestination(AIAgent.transform.position);

                        Animator characterAnimator = character.GetComponent<Animator>();
                        if (characterAnimator) characterAnimator.Play("Roundhouse Kick");

                    };
                    break;
                default:
                    Debug.Log("No move assigned?");
                    break;
            }
            
        }
    }
}
