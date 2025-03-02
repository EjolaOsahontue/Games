using UnityEngine;

public class collectcoin : MonoBehaviour
{
    public AudioSource coinFX;
    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount += 1;
        this.gameObject.SetActive(false);   
    }

}
