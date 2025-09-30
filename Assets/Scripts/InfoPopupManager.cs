using UnityEngine;
using TMPro;

public class InfoPopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text infoText;

    void Start()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }

    public void ShowInfo(string message)
    {
        if (infoText != null)
            infoText.text = message;
        if (popupPanel != null)
            popupPanel.SetActive(true);
    }

    public void Hide()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}