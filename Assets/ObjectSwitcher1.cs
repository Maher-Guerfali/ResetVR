using UnityEngine;

public class ObjectSwitcher1 : MonoBehaviour
{
    public Material blueMaterial;
    public Material greyMaterial;
    public GameObject GameObject2;

    private Renderer rend1;
    private Renderer rend2;

    private bool touched = false; // To track if the object has been touched

    private void Start()
    {
        rend1 = GetComponent<Renderer>();
        rend2 = GameObject2.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            rend1.material = blueMaterial; 
            rend2.material = greyMaterial;

            // Check if the PlayerPrefs key already exists
            if (!PlayerPrefs.HasKey("TouchFlag"))
            {
                // Save the number 1 in PlayerPrefs
                PlayerPrefs.SetInt("TouchFlag", 1);
            }

            // Get and print the PlayerPrefs value
            int touchFlagValue = PlayerPrefs.GetInt("TouchFlag");
            Debug.Log("PlayerPrefs Value: " + touchFlagValue);

            // Set the touched flag to true to avoid multiple touches
           
        }
    }
}
