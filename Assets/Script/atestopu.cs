using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atestopu : MonoBehaviour
{
    public float speed,damage,penetration;
   [SerializeField] GameObject[] Enemies,Clones;
    [SerializeField] GameObject nearestenemy,player,ZombieBoss,SlimeGirlBoss,SkeletonKingBoss,pooler;

    private void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");
        pooler = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject;
        Invoke("DisableFire",10);
    }
    private void FixedUpdate()
    {
        Clones = GameObject.FindGameObjectsWithTag("Clone");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ZombieBoss = GameObject.FindGameObjectWithTag("ZombieBoss");
        SlimeGirlBoss = GameObject.FindGameObjectWithTag("SlimeGirlBoss");
        SkeletonKingBoss = GameObject.FindGameObjectWithTag("SkeletonKingBoss");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (i == 0) {nearestenemy = Enemies[i];}
           else if (Vector3.Distance(Enemies[i].transform.position,this.transform.position)< Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                if (!Enemies[i].GetComponent<enemyStat>().died) {nearestenemy = Enemies[i]; }
                
            }
        }
        for (int i = 0; i < Clones.Length; i++)
        {
            if (Clones[i] != null)
            {
 if (nearestenemy == null) {nearestenemy= Clones[i];}
            else if (Vector3.Distance(Clones[i].transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                nearestenemy = Clones[i]; 

            }
            }
           
        }
        if (ZombieBoss != null)
        {
            if (nearestenemy == null)
            {
                nearestenemy = ZombieBoss;
            }
           else if(Vector3.Distance(ZombieBoss.transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                nearestenemy = ZombieBoss;
            }
        }
        if (SlimeGirlBoss != null)
        {
            if (nearestenemy == null)
            {
                nearestenemy = SlimeGirlBoss;
            }
            else if (Vector3.Distance(SlimeGirlBoss.transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                nearestenemy = SlimeGirlBoss;
            }
        }
        if (SkeletonKingBoss != null)
        {
            if (nearestenemy == null)
            {
                nearestenemy = SkeletonKingBoss;
            }
            else if (Vector3.Distance(SkeletonKingBoss.transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                nearestenemy = SkeletonKingBoss;
            }
        }

        if (nearestenemy != null )
        {
            if(Vector3.Distance(nearestenemy.transform.position, this.transform.position) < 200) { this.transform.LookAt(new Vector3(nearestenemy.transform.position.x, transform.position.y, nearestenemy.transform.position.z)); }

        }
       
        transform.Translate(new Vector3(0,0,speed * Time.fixedDeltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (ZombieBoss != null)
        {
         if (other.gameObject.tag == "ZombieBoss")
        {
                other.gameObject.GetComponent<ZombieBoss>().takedamage(damage, penetration);
                DisableFire();
            }
        }
        if (SlimeGirlBoss != null)
        {
            if (other.gameObject.tag == "SlimeGirlBoss")
            {
                other.gameObject.GetComponent<SlimeBoss>().takedamage(damage, penetration);
                DisableFire();
            }
        }
        if (SkeletonKingBoss != null)
        {
            if (other.gameObject.tag == "SkeletonKingBoss")
            {
                other.gameObject.GetComponent<SkeletonKingBoss>().takedamage(damage, penetration);
                DisableFire();
            }
        }
        if (other.gameObject.tag == "Clone")
        {
            DisableFire();
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyStat>().takedamage(damage,penetration);
            DisableFire();
        }
    }
    public void DisableFire()
    {
        this.gameObject.SetActive(false);
        transform.parent = pooler.transform;
        
    }
}
