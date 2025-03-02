using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure to include this

public class CollectableControl : MonoBehaviour
{
    public static int coinCount = 0;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

    void Update()
    {
        // Use TMP_Text if you're using TextMeshPro
        coinCountDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
        coinEndDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
    }
}