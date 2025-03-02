using System.Collections;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject fadeIn;
    public AudioSource goFX;

    void Start()
    {
        // Ensure all countdown objects are initially inactive
        countDown3.SetActive(false);
        countDown2.SetActive(false);
        countDown1.SetActive(false);
        countDownGo.SetActive(false);

        // Optionally activate fadeIn if needed
        if (fadeIn != null)
        {
            fadeIn.SetActive(true);
        }

        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(false); // Deactivate after showing
        countDown2.SetActive(true);
        goFX.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(false); // Deactivate after showing
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(false); // Deactivate after showing
        countDownGo.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(false); // Deactivate after showing
        PlayerMove.canMove = true;
        // Optionally deactivate fadeIn if needed
        if (fadeIn != null)
        {
            fadeIn.SetActive(false);
        }
    }
}