using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitZombie : MonoBehaviour
{
    // Reference to the "enemy" GameObject, assign this in the Unity Inspector.
    public GameObject enemy;
    public GameObject collided;

    // This method is called when a collision occurs.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has the tag "EnemyHead."
        if (collision.gameObject.CompareTag("solide"))
        {
            collided.SetActive(false);
            
            // Assuming that "enemy" is a sibling of the "EnemyHead" GameObject.
            // Disable the NavMeshAgent component if it exists on the "enemy" GameObject.
            NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = false;
            }

            // Disable the Animator component if it exists on the "enemy" GameObject.
            Animator animator = enemy.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
        }
    }
}
