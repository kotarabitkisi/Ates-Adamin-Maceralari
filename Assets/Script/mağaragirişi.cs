using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mağaragirişi : MonoBehaviour
{
    [SerializeField] GameObject GM,Canvasmagara;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Canvasmagara.SetActive(true);
        }
    }
   public void MağaraAç() {
        SceneManager.LoadScene("Magara");
    }
    public void MağaraKapat()
    {
        Canvasmagara.SetActive(false);
    }
}
