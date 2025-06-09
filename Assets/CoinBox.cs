using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField]
    private int requiredCoins;// The number of coins required for the box to disappear
 public GameObject Playerbody;
    private bool canDeactivate = false;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerBody") != null)
        {
            
            Playerbody = GameObject.FindGameObjectWithTag("PlayerBody");
        }
    }

    // Update the visibility of the box based on the player's coin count




    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            if (Playerbody.GetComponent<Health>().GetCoins() >= requiredCoins)
            {
                Playerbody.GetComponent<Health>().coins = Playerbody.GetComponent<Health>().coins - requiredCoins;
                Debug.Log("door opnned paid");
                // The player has enough coins, so hide the box
               gameObject.SetActive(false);
            }
            
        }
    }

    // OnTriggerExit is called when the Collider other exits the trigger


    // Update is called once per frame

}
