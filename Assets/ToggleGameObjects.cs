using UnityEngine;

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject objectToActivateFirst;
    public GameObject objectToActivateSecond;

    public bool isFirstObjectActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (isFirstObjectActive)
            {
                if (objectToActivateFirst != null)
                    objectToActivateFirst.SetActive(false);

                if (objectToActivateSecond != null)
                    objectToActivateSecond.SetActive(true);
            }
            else
            {
                if (objectToActivateFirst != null)
                    objectToActivateFirst.SetActive(true);

                if (objectToActivateSecond != null)
                    objectToActivateSecond.SetActive(false);
            }

            isFirstObjectActive = !isFirstObjectActive;
        }
    }
}
