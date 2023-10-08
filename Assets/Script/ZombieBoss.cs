using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZombieBoss : MonoBehaviour
{
    [SerializeField] AudioClip deathsound,skillsound;
    public float health, attack, defense, penetration, maxhealth, experience, level, timetodie, speed;
    public Animator anim;
    public GameObject player;
    public bool canattack, attacking, walking, died,skill1using;
    public float distancetoattack;
    public TextMeshProUGUI leveltext;
    public Image HealthBar;
   
    private void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Skill1());
    }
    private void Update()
    {
        
        HealthBar.fillAmount = health / maxhealth;
        leveltext.text = "Zombie Boss Level: " + level.ToString();
        if (health <= 0 && !died) { die(); }
      
        else if (Vector3.Distance(player.transform.position, transform.position) <= distancetoattack && canattack && !skill1using)
        {
            canattack = false;
            walking = false;
            attacking = true;
          
           
                this.transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
          StartCoroutine(attacktoplayer());
        }
        else if(!attacking&& !skill1using)
        {
            walking = true;
            anim.SetBool("Attacking", false);
            anim.SetBool("Walking", true);
        }
    }
    private void FixedUpdate()
    {

        if (walking && !attacking && !died)
        {

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&skill1using)
        {
            player.GetComponent<stats>().takedamage(attack,penetration);
        }
    }
    public void takedamage(float damage, float penetration)
    {
        health -= damage * (1 - (defense - penetration) / 100);
    }
    public void die()
    {

        GetComponent<AudioSource>().PlayOneShot(deathsound);
        this.gameObject.tag = null;
        died = true;
        player.GetComponent<stats>().stat.experience += level*level * experience;
        player.GetComponent<stats>().stat.ZombieBossKillCount++;
        GetComponent<CapsuleCollider>().enabled = false;
        anim.SetBool("Died", true);
        anim.SetBool("Attacking", false);
        anim.SetBool("Walking", false);
        
        Destroy(this.gameObject, timetodie);
    }
    public IEnumerator attacktoplayer()
    {
        anim.SetBool("Walking", false);
        anim.SetBool("Attacking", true);
        yield return new WaitForSecondsRealtime(2);
        player.GetComponent<stats>().takedamage(attack, penetration);
        canattack = true;
        attacking = false;
    }
    public void Initialize()
    {
        maxhealth *= 1 + (level * 0.5f);
        health *= 1 + (level * 0.5f);
        defense *= 1 + (level * 0.1f);
        penetration *= 1 + (level * 0.2f);
        attack *= 1 + (level * 0.25f);
    }
    public IEnumerator Skill1()
    {

        GetComponent<AudioSource>().PlayOneShot(skillsound);
        Vector3 playertransform = player.transform.position;
        skill1using = true;
        anim.SetBool("Walking", false);
        anim.SetBool("RunningSkill", true);
        yield return new WaitForSecondsRealtime(2);
        transform.DOMove(playertransform, 2);
        yield return new WaitForSecondsRealtime(2);
        anim.SetBool("Walking", true);
        anim.SetBool("RunningSkill", false);
        skill1using = false;
        yield return new WaitForSecondsRealtime(10);
        StartCoroutine(Skill1());

    }
}
