using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScanner : MonoBehaviour
{
    public GameObject Door;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Hand"))
        {
            Door.SetActive(false);
        }
    }
}
