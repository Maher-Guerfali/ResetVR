using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redknife : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f; // Damage amount to apply to the zombie

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an object with the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().Damage(13f);
            
        }
    }
}
