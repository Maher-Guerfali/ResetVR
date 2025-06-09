using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject linkedFeature;
    public GameObject feature2;
    public bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        isActive = !isActive;
        if (other.CompareTag("Hand"))
        {
            linkedFeature.SetActive(isActive);
            feature2.SetActive(!isActive);
        }
    }

    public void ActivateFeature()
    {
        isActive = true;
        // You can add any activation logic for the feature here.
        // For example, you can enable a particle effect or change the color of the button to indicate activation.
        linkedFeature.SetActive(true);
    }

    public void DeactivateFeature()
    {
        isActive = false;
        // You can add any deactivation logic for the feature here.
        // For example, you can disable the particle effect or reset the color of the button to indicate deactivation.
        linkedFeature.SetActive(false);
    }
}
