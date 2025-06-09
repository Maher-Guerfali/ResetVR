using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public Material blueMaterial;
    public Material greyMaterial;

    private Renderer rend1;
    private Renderer rend2;
    private bool isBlue = true;
    public GameObject GameObject1;
    public GameObject GameObject2;

    private void Start()
    {
        rend1 = GameObject1.GetComponent<Renderer>();
        rend2 = GameObject2.GetComponent<Renderer>();

        rend1.material = blueMaterial;
        rend2.material = greyMaterial;

        // Add colliders and rigidbodies to both GameObjects
    }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("hand"))
            {
                if (isBlue)
                {
                    rend1.material = greyMaterial;
                    rend2.material = blueMaterial;
                    isBlue = false;
                }
                else
                {
                    rend1.material = blueMaterial;
                    rend2.material = greyMaterial;
                    isBlue = true;
                }
            }
        }
    }