using UnityEngine;

public class OutroPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
        else
            Debug.LogWarning("⚠️ OutroPanel: 'panel' not assigned!");
    }

    public void Show()
    {
        Debug.Log("✅ OutroPanel.Show() called");
        if (panel != null)
            panel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("🚪 Quitting application");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}