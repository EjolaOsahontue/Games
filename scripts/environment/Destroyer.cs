using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;
    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(150);
        if(parentName == " section(Clone)"){
            Destroy(gameObject);
        }
    }
}
