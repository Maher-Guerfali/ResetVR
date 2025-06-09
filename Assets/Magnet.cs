using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float attractingForce = 10f;
    public float attractionRadius = 3f;
    public string targetTag = "Enemy";

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();

                if (targetRigidbody != null)
                {
                    Vector3 direction = (collider.transform.position - transform.position).normalized;
                    targetRigidbody.AddForce(direction * attractingForce);
                }
            }
        }
    }
}
