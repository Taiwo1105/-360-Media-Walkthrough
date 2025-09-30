using UnityEngine;

public class Hotspot : MonoBehaviour
{
    private WalkthroughManager.HotspotData data;
    private WalkthroughManager manager;

    public void Setup(WalkthroughManager.HotspotData d, WalkthroughManager m)
    {
        data = d;
        manager = m;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (data.isNavigation)
            {
                manager.LoadLocation(data.targetIndex); // This can be -2!
            }
            else
            {
                Debug.Log(data.info);
            }
        }
    }
}