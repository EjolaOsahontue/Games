using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    private bool creatingSection = false;
    private int secNum;

    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        if (section.Length == 0) yield break; // Prevent errors if the array is empty

        secNum = Random.Range(0, section.Length); // Adjusts to the actual array size
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(8f); // Corrected syntax
        creatingSection = false;
    }
}
