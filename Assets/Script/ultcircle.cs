using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ultcircle : MonoBehaviour
{
   public ScriptableForStats stat;
     void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag == "ZombieBoss")
            {
                other.gameObject.GetComponent<ZombieBoss>().takedamage(stat.attack*3, stat.penetration / 2);
            
        }
        
            else if (other.gameObject.tag == "SlimeGirlBoss")
            {
                other.gameObject.GetComponent<SlimeBoss>().takedamage(stat.attack*3, stat.penetration / 2);

            }
        
       
            else if (other.gameObject.tag == "SkeletonKingBoss")
            {
                other.gameObject.GetComponent<SkeletonKingBoss>().takedamage(stat.attack*3, stat.penetration/2);

            }
        

        else if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyStat>().takedamage(stat.attack*3, stat.penetration/2);

        }
    }
}
