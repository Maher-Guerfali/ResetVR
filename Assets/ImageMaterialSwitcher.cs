using UnityEngine;

public class ImageMaterialSwitcher : MonoBehaviour
{
    public Texture[] baseMaps;       // Array of base maps (textures) for the billboard
    public Texture[] emissionMaps;  // Array of emission maps (textures) for the billboard
    public float switchInterval = 2.0f; // Time interval between switches

    private Material billboardMaterial;
    private int currentIndex = 0;
    private float timer = 0.0f;

    void Start()
    {
        // Assuming you have two materials, one for the frame and one for the billboard.
        // You need to retrieve the material for the billboard.
        // Make sure you've set the material for the billboard in the Inspector.
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.materials.Length >= 2) // Make sure you have at least two materials
        {
            billboardMaterial = renderer.materials[1]; // Assuming the billboard material is the second material in the array
        }
        else
        {
            Debug.LogError("The GameObject should have at least two materials.");
            enabled = false;
            return;
        }

        if (baseMaps.Length != emissionMaps.Length || baseMaps.Length == 0)
        {
            Debug.LogError("Base maps and emission maps arrays must have the same length and not be empty.");
            enabled = false;
            return;
        }

        // Initialize the billboard material with the first textures
        billboardMaterial.mainTexture = baseMaps[0];
        billboardMaterial.SetTexture("_EmissionMap", emissionMaps[0]);
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to switch textures
        if (timer >= switchInterval)
        {
            // Reset the timer
            timer = 0.0f;

            // Increment the index and wrap around if necessary
            currentIndex = (currentIndex + 1) % baseMaps.Length;

            // Update the billboard material with the new textures
            billboardMaterial.mainTexture = baseMaps[currentIndex];
            billboardMaterial.SetTexture("_EmissionMap", emissionMaps[currentIndex]);
        }
    }
}
