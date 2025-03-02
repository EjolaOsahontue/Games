using System.Collections;
using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay; // Reference to the UI TextMeshPro GameObject for current distance
    public GameObject disEndDisplay; // Reference to the end display for final distance
    public int disRun; // Distance run
    public bool addingDis = false; // Flag to control coroutine execution
    public float disDelay = 0.35f; // Delay between increments

    void Update()
    {
        if (!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;

        // Check if disDisplay is assigned and has a TMP_Text component
        if (disDisplay != null)
        {
            TMP_Text displayText = disDisplay.GetComponent<TMP_Text>();
            if (displayText != null)
            {
                displayText.text = disRun.ToString();
            }
            else
            {
                Debug.LogError("TMP_Text component is missing on disDisplay GameObject.");
            }
        }
        else
        {
            Debug.LogError("disDisplay GameObject is not assigned in the Inspector.");
        }

        // Check if disEndDisplay is assigned and has a TMP_Text component
        if (disEndDisplay != null)
        {
            TMP_Text endDisplayText = disEndDisplay.GetComponent<TMP_Text>();
            if (endDisplayText != null)
            {
                endDisplayText.text = disRun.ToString();
            }
            else
            {
                Debug.LogError("TMP_Text component is missing on disEndDisplay GameObject.");
            }
        }
        else
        {
            Debug.LogError("disEndDisplay GameObject is not assigned in the Inspector.");
        }

        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}