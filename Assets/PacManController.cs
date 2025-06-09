using UnityEngine;
using UnityEngine.AI;

public class PacManController : MonoBehaviour
{
    // Reference to the player
    public Transform player;

    // Plane surface representing the map
    public GameObject planeSurface;

    // Radius for chasing the player
    public float chaseRadius = 10f;

    // Reference to the Animator component
    private Animator animator;

    // Reference to the NavMeshAgent component
    private NavMeshAgent navAgent;

    // Bounds of the plane surface
    private Bounds planeBounds;

    // Random target position within the map
    private Vector3 randomTarget;

    // Walking steps sound effect
    public AudioClip walkingSound;

    // Scream sound effect
    public AudioClip screamSound;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Reference to the player's collider
    public Collider playerCollider;

    // Start is called before the first frame update
    private void Start()
    {
        // Get references to the Animator, NavMeshAgent, and AudioSource components
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        // Set up the audio source properties for walking sound
        audioSource.loop = true;

        // Get the bounds of the plane surface
        planeBounds = planeSurface.GetComponent<Renderer>().bounds;

        // Set the initial random target position
        SetRandomTargetPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is within the chase radius
        bool playerWithinChaseRadius = Vector3.Distance(transform.position, player.position) <= chaseRadius;

        if (playerWithinChaseRadius)
        {
            // Chase the player
            navAgent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);

            // Check if walking sound is not playing
            if (!audioSource.isPlaying || audioSource.clip != walkingSound)
            {
                // Play the walking steps sound
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
        }
        else
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    // Reached the current target position

                    // Check if the Pac-Man has finished chasing the player
                    if (animator.GetBool("IsWalking"))
                    {
                        // Stop chasing and set a new random target position
                        animator.SetBool("IsWalking", false);
                        SetRandomTargetPosition();

                        // Stop the walking steps sound
                        audioSource.Stop();
                    }
                    else
                    {
                        // Start moving towards the next random target position
                        SetRandomTargetPosition();
                        navAgent.SetDestination(randomTarget);
                        animator.SetBool("IsWalking", true);
                    }
                }
            }
        }
    }

    // Called when the enemy collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other == playerCollider)
        {
            // Trigger the "Scream" bool parameter
            animator.SetBool("Scream", true);
            Debug.Log("scream!");
            // Play the scream sound effect
            audioSource.PlayOneShot(screamSound);

            // Stop the walking steps sound
            audioSource.Stop();
        }
    }

    // Called when the enemy stops colliding with another collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the collided object is the player
        if (other == playerCollider)
        {
            // Reset the "Scream" bool parameter
            animator.SetBool("Scream", false);
        }
    }

    // Set a new random target position within the map bounds
    private void SetRandomTargetPosition()
    {
        float x = Random.Range(planeBounds.min.x, planeBounds.max.x);
        float z = Random.Range(planeBounds.min.z, planeBounds.max.z);
        randomTarget = new Vector3(x, 0f, z);
    }
}
