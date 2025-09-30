using UnityEngine;

public class WalkthroughManager : MonoBehaviour
{
    [System.Serializable]
    public class HotspotData
    {
        public string info = "Info";
        public Vector3 localPosition = Vector3.zero;
        public bool isNavigation = false;
        public int targetIndex = 0; // Use -2 ONLY for the final "End Tour" hotspot
    }

    [System.Serializable]
    public class Location
    {
        public string name = "Location";
        public Material skybox;
        public Vector3 position = new Vector3(0, 1.6f, 0);
        public HotspotData[] hotspots;
    }

    public Location[] locations;
    public GameObject hotspotPrefab;

    private GameObject[] activeHotspots;

    void Start()
    {
        if (locations != null && locations.Length > 0)
        {
            LoadLocation(0);
        }
        else
        {
            Debug.LogError("❌ Assign 5 locations in Inspector!");
        }
    }

    public void LoadLocation(int index)
    {
        // If index is -2 → show outro
        if (index == -2)
        {
            ShowOutro();
            return;
        }

        // Prevent invalid index
        if (index < 0 || index >= locations.Length)
        {
            Debug.LogWarning("Invalid location index: " + index);
            return;
        }

        // Set skybox and position
        RenderSettings.skybox = locations[index].skybox;
        Camera.main.transform.position = locations[index].position;

        // Clean up old hotspots
        if (activeHotspots != null)
        {
            foreach (var hs in activeHotspots)
                if (hs != null) Destroy(hs);
        }

        // Spawn new hotspots
        var loc = locations[index];
        activeHotspots = new GameObject[loc.hotspots?.Length ?? 0];
        for (int i = 0; i < activeHotspots.Length; i++)
        {
            Vector3 pos = loc.position + loc.hotspots[i].localPosition;
            GameObject hs = Instantiate(hotspotPrefab, pos, Quaternion.identity);
            hs.AddComponent<Hotspot>().Setup(loc.hotspots[i], this);
            activeHotspots[i] = hs;
        }
    }

    void ShowOutro()
    {
        OutroPanel panel = FindObjectOfType<OutroPanel>();
        if (panel != null)
            panel.Show();
        else
            Debug.LogError("❌ OutroPanel not found!");
    }
}