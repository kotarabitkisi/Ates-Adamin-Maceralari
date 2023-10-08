using UnityEngine;

public class musicplayer : MonoBehaviour
{
    [SerializeField] AudioSource musicSource,musicSource2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        musicSource.enabled = true;
        musicSource2.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            musicSource.enabled = false;
            musicSource2.enabled = true;
        }
    }
}
