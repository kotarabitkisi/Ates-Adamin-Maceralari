using DG.Tweening;
using System.Collections;
using UnityEngine;

public class littlegirl : MonoBehaviour
{
   public GameObject secondCanvas;
    bool isrunned=false;
    void Update()
    {
       if(this.GetComponent<dialogcode>().dialogfinished && this.GetComponent<dialogcode>().candialog&&!isrunned)
        {
            StartCoroutine(RunToVillage());
        }
    }
    IEnumerator RunToVillage()
    {
        isrunned = true; 
        GetComponent<dialogcode>().candialog = false;
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Animator>().SetBool("IsRunning",true);
        transform.LookAt(new Vector3(600,transform.position.y,586));
        transform.DOMove(new Vector3(600, 50, 586), 10);
        yield return new WaitForSecondsRealtime(10);
        transform.LookAt(new Vector3(1036, transform.position.y, 869));
        transform.DOMove(new Vector3(1036, 50, 869), 15);
        yield return new WaitForSecondsRealtime(15);
        transform.LookAt(new Vector3(1036, transform.position.y, 1610));
        transform.DOMove(new Vector3(1036, 50, 1610), 15);
        yield return new WaitForSecondsRealtime(15);
        transform.LookAt(new Vector3(530, transform.position.y, 1610));
        transform.DOMove(new Vector3(530, 50, 1610), 15);
        yield return new WaitForSecondsRealtime(15);
        transform.LookAt(new Vector3(530, transform.position.y, 1402));
        transform.DOMove(new Vector3(530, 50, 1402), 15);
        yield return new WaitForSecondsRealtime(15);
        this.GetComponent<Animator>().SetBool("IsRunning", false);
        transform.rotation= Quaternion.Euler(0,180,0);
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<dialogcode>().dialogCanvas = secondCanvas;
    }
}
