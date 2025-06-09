using UnityEngine;

public class DisableAnimatorOnTrigger : MonoBehaviour
{
    public GameObject knife; // The GameObject representing the knife
    public GameObject targetObject; // The GameObject whose Animator will be disabled

    private Animator targetAnimator; // Reference to the Animator component of the target object

    private void Start()
    {
        // Check if the targetObject has an Animator component
        targetAnimator = targetObject.GetComponent<Animator>();
        if (targetAnimator == null)
        {
            Debug.LogError("The targetObject does not have an Animator component!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collision is with the knife GameObject
        if (other.gameObject == knife)
        {
            // Disable the Animator component on the targetObject
            if (targetAnimator != null)
            {
                targetAnimator.enabled = false;
            }
        }
    }
}
