using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GeceGündüzDöngüsü : MonoBehaviour
{
    public float time;
   public GameObject güneş,gündüzvolume,gecevolume;
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        
        if (time >= 360)
        {
            gündüzvolume.SetActive(false);
            gecevolume.SetActive(true);
            güneş.SetActive(false);
        }
        else
        {
            güneş.SetActive(true);
            gündüzvolume.SetActive(true);
            gecevolume.SetActive(false);
        }
        if (time >= 720)
        {
            time = 0;
        }
        güneş.transform.rotation=Quaternion.Euler(time/2,0,0);
    }
}
