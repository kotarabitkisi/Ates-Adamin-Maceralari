using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] Bloom bloom;
    [SerializeField] Volume volume;
   [SerializeField] GameObject Camera,CameraHandler,finalblow1,finalblow2;
   [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] GameObject fireball;
  public IEnumerator FinalAnim()
    {
        Camera.transform.parent = null;
        animator.enabled = true;
        CameraHandler.GetComponent<CameraFollow>().canfollow = false;
        yield return new WaitForSecondsRealtime(3.5f);
        animator.enabled = false;
        Camera.transform.position =new Vector3(0,20,0);
        Camera.transform.DORotate(new Vector3(0,270,0),1);
        txt.text = "Sonunda";
        yield return new WaitForSecondsRealtime(1);
        Camera.transform.DORotate(new Vector3(0, 90, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        txt.text = "yok olmaya hazýr ol";
        yield return new WaitForSecondsRealtime(1);
        txt.text = "Ateþ Adam!!!";
        yield return new WaitForSecondsRealtime(3);
        Camera.transform.DORotate(new Vector3(0, 270, 0), 1);
        txt.text = "Evet, Yok olmaya hazýrým";
        yield return new WaitForSecondsRealtime(3);
        txt.text = "Ama seninle birlikte";
        yield return new WaitForSecondsRealtime(3);
        Camera.transform.DORotate(new Vector3(0, 90, 0), 1);
        txt.text = "NE?!";
        yield return new WaitForSecondsRealtime(3);
        txt.text = "Bu Da...";
        Camera.transform.DORotate(new Vector3(-25, -80, 0), 1);
        Camera.transform.DOMove(new Vector3(55, 13, -11), 1);
        yield return new WaitForSecondsRealtime(3);
        Camera.transform.parent = fireball.transform;
        Camera.transform.localPosition =new Vector3(1.5f,0,0);
        Camera.transform.localRotation = Quaternion.Euler(0,-90,0);
        txt.text = "NEEEEEEEEEEEEEEE.";
        yield return new WaitForSecondsRealtime(5);
        Camera.transform.parent = null;
        Camera.transform.position =new Vector3(-76,80,-103);
        Camera.transform.rotation = Quaternion.Euler(28,39,0);
        fireball.transform.DOMove(Vector3.zero,2);
        yield return new WaitForSecondsRealtime(2);
        fireball.transform.DOScale(new Vector3(1,1,1)*170,5);
        yield return new WaitForSecondsRealtime(2);
        Camera.transform.position = new Vector3(0,15,-400);
        Camera.transform.rotation = Quaternion.Euler(0,0,0);
        yield return new WaitForSecondsRealtime(2);
        finalblow1.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        finalblow2.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        volume.profile.TryGet(out bloom);
        for (int i = 0; i < 15; i++)
        {
            bloom.intensity.value += 0.25f;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        SceneManager.LoadScene("Mezar");
        
    }
}
