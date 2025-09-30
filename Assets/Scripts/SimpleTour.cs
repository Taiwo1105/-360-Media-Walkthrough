using UnityEngine;

public class SimpleTour : MonoBehaviour
{
    public Material[] skyboxes; // This creates the "Skyboxes" array

    void Start()
    {
        if (skyboxes.Length > 0)
        {
            RenderSettings.skybox = skyboxes[0];
            Debug.Log("✅ Loaded first location");
        }
        else
        {
            Debug.LogError("❌ Assign 5 skybox materials in Inspector!");
        }
    }
}