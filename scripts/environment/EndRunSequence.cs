using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;
    public float initialWaitTime = 5f;
    public float fadeWaitTime = 5f;

    void Start()
    {
        // Ensure objects start hidden
        if (liveCoins != null)
        {
            liveCoins.SetActive(false);
        }
        else
        {
            Debug.LogError("liveCoins GameObject is not assigned.");
        }

        if (liveDis != null)
        {
            liveDis.SetActive(false);
        }
        else
        {
            Debug.LogError("liveDis GameObject is not assigned.");
        }

        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }

        if (fadeOut != null)
        {
            fadeOut.SetActive(false);
        }

        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(initialWaitTime);

        // Activate End Screen + Coins & Distance together
        if (endScreen != null)
        {
            endScreen.SetActive(true);
            Debug.Log("End screen is now active.");
        }

        if (liveCoins != null)
        {
            liveCoins.SetActive(true);
            Debug.Log("liveCoins is now active.");
        }

        if (liveDis != null)
        {
            liveDis.SetActive(true);
            Debug.Log("liveDis is now active.");
        }

        yield return new WaitForSeconds(fadeWaitTime);

        // Hide Coins & Distance before fade-out
        if (liveCoins != null)
        {
            liveCoins.SetActive(false);
            Debug.Log("liveCoins is now hidden.");
        }

        if (liveDis != null)
        {
            liveDis.SetActive(false);
            Debug.Log("liveDis is now hidden.");
        }

        if (fadeOut != null)
        {
            fadeOut.SetActive(true);
            Debug.Log("Fade-out effect is now active.");
        }

        yield return new WaitForSeconds(2); // Missing semicolon fixed

        SceneManager.LoadScene(0); // Fixed SceneManager spelling
    }
}
