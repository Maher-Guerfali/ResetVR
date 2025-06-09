using UnityEngine;

public class ObjectSwitcher2 : MonoBehaviour
{
    public Material blueMaterial;
    public Material greyMaterial;
    public GameObject GameObject1;

    private Renderer rend1;
    private Renderer rend2;

    private bool touched = false; // To track if the object has been touched

    private void Start()
    {
        rend1 = GameObject1.GetComponent<Renderer>();
        rend2 = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") )
        {
            rend1.material = greyMaterial; 
            rend2.material = blueMaterial;

            // Check if the PlayerPrefs key already exists
            if (!PlayerPrefs.HasKey("TouchFlag"))
            {
                // Save the number 2 in PlayerPrefs
                PlayerPrefs.SetInt("TouchFlag", 2);
            }

            // Set the touched flag to true to avoid multiple touches
           
        }
    }
}
