using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SkillPet : MonoBehaviour
{
    public Animator animator;
    public float timetoshoot;
    public GameObject nearestenemy,ZombieBoss,SlimeGirlBoss,SkeletonKingBoss,fire,kafa;
   public GameObject[] Enemies;
    public float Speed;
    public ScriptableForStats MCstat;
    private void Start()
    {
        Speed = MCstat.speed;
        Destroy(this.gameObject,10);
    }
    void FixedUpdate()
    {
        timetoshoot += Time.fixedDeltaTime;
        if (timetoshoot >= 1)
        {
            timetoshoot = 0;
            shoot(MCstat.attack,1);
        }
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ZombieBoss = GameObject.FindGameObjectWithTag("ZombieBoss");
        SlimeGirlBoss = GameObject.FindGameObjectWithTag("SlimeGirlBoss");
        SkeletonKingBoss = GameObject.FindGameObjectWithTag("SkeletonKingBoss");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (i == 0) { nearestenemy = Enemies[i]; }
            else if (Vector3.Distance(Enemies[i].transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
            {
                if (!Enemies[i].GetComponent<enemyStat>().died) { nearestenemy = Enemies[i]; }

            }
        }
        if (ZombieBoss != null)
        {
            if (nearestenemy == null)
            {
                nearestenemy = ZombieBoss;
            }
            else if (Vector3.Distance(ZombieBoss.transform.position, this.transform.position) < Vector3.Distance(nearestenemy.transform.position, this.transform.position))
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

        if (nearestenemy != null)
        {
          
            if (Vector3.Distance(nearestenemy.transform.position, this.transform.position) < 200&& Vector3.Distance(nearestenemy.transform.position, this.transform.position)>30) {
               
             transform.Translate(0,0,Speed*Time.fixedDeltaTime);
                animator.SetBool("IsRunning",true);
                
            }
            else { animator.SetBool("IsRunning", false); }
            this.transform.LookAt(new Vector3(nearestenemy.transform.position.x, transform.position.y, nearestenemy.transform.position.z)); 
        }
        else { animator.SetBool("IsRunning", false); }
       
    }
  
        public void shoot(float damage, float scale)
        {
            GameObject shootedfire = Instantiate(fire, kafa.transform.position, this.transform.rotation);
            shootedfire.GetComponent<atestopu>().damage = damage/2;
        shootedfire.GetComponent<atestopu>().penetration = MCstat.penetration/2;
        shootedfire.transform.DOScale(new Vector3(1, 1, 1) * scale, 0.25f);
        }
    
}
