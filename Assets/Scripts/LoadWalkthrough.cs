using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWalkthrough : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("WalkthroughScene");
        }
    }
}