using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeballspawner : MonoBehaviour
{
   public GameObject SlimeBall;
   public float damage, penetration;
  public void blow()
    {
        for (int i = 0; i < 4; i++)
        {
          GameObject slimeball=  Instantiate(SlimeBall,this.transform.position,Quaternion.Euler(0,transform.eulerAngles.y+90*i,0));
            slimeball.GetComponent<SlimeBall>().damage = damage;
            slimeball.GetComponent<SlimeBall>().penetration = penetration;
            slimeball.GetComponent<SlimeBall>().speed = 50;
        }
        Destroy(this.gameObject);
    }
}
