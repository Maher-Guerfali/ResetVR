using UnityEngine;

public class TagChanger : MonoBehaviour
{
    private const string playerTag = "Player";
    private const string robotTag = "Robot";
    private const float tagChangeDuration = 5f;

    private float timer;
    private bool isTagChanged;

    private void Start()
    {
        timer = 0f;
        isTagChanged = false;
    }

    private void Update()
    {
        // Check if the tag is currently changed
        if (isTagChanged)
        {
            timer += Time.deltaTime;

            // Check if the timer has exceeded the tag change duration
            if (timer >= tagChangeDuration)
            {
                // Change the tag back to "Player"
                gameObject.tag = playerTag;
                isTagChanged = false;
                timer = 0f;
            }
        }
    }

    // Call this method to change the tag to "Robot" for a specific duration
    public void ChangeTagToRobot()
    {
        // Change the tag to "Robot"
        gameObject.tag = robotTag;
        isTagChanged = true;
        timer = 0f;
    }
}
