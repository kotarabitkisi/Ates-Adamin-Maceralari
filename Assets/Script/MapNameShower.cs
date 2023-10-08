using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapNameShower : MonoBehaviour
{
    public string PlaceName;
    public TextMeshProUGUI txt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(textanimation());
        } 
    }
    public IEnumerator textanimation()
    {
        txt.text = PlaceName;
        txt.transform.DOScale(new Vector3(2,2,2),1);
        yield return new WaitForSecondsRealtime(4);
        txt.transform.DOScale(new Vector3(1,1,1)/10000, 1);
    }
}
