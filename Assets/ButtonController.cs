using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public ButtonScript[] buttons;
    public ButtonScript activeButton;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            ButtonScript button = other.GetComponent<ButtonScript>();
            if (button != null)
            {
                ToggleFeatureActivation(button);
            }
        }
    }

    void ToggleFeatureActivation(ButtonScript clickedButton)
    {
        // If the clicked button is different from the currently active button, deactivate the active button's feature.
        if (activeButton != null && activeButton != clickedButton)
        {
            DeactivateActiveButtonFeature();
        }

        // If the clicked button is not active, activate it and deactivate other buttons.
        if (!clickedButton.isActive)
        {
            clickedButton.ActivateFeature();
            activeButton = clickedButton;
        }
        // If the clicked button is already active, deactivate it.
        else
        {
            clickedButton.DeactivateFeature();
            activeButton = null;
        }
    }

    void DeactivateActiveButtonFeature()
    {
        if (activeButton != null)
        {
            activeButton.DeactivateFeature();
            activeButton = null;
        }
    }
}
