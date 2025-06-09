using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to toggle
    public Button toggleButton; // Reference to the button component

    private bool isObjectEnabled; // Current state of the targetObject

    private void Start()
    {
        // Set the initial state of the targetObject
        isObjectEnabled = targetObject.activeSelf;

        // Attach the button click event listener
        toggleButton.onClick.AddListener(ToggleObject);
    }

    private void ToggleObject()
    {
        // Toggle the state of the targetObject
        isObjectEnabled = !isObjectEnabled;
        targetObject.SetActive(isObjectEnabled);
    }
}
