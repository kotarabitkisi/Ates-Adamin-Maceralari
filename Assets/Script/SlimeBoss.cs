using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBoss : MonoBehaviour
{
    [SerializeField] AudioClip skillsound;
    public float health, attack, defense, penetration, maxhealth, experience, level, timetodie, speed,distancetoattack;
    [SerializeField] Animator anim;
    [SerializeField] GameObject hand1, hand2;
    [SerializeField] GameObject player, littlegirl, SlimeBall,SlimeBallSpawner,SlimeGirlDeathEffect;
    public bool canattack, attacking, walking, died, skill1using, skill2using;
    [SerializeField] TextMeshProUGUI leveltext;
    [SerializeField] Image HealthBar;
    [SerializeField] Material normalgirlMaterial;
    [SerializeField] GameObject[] childs;
  
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("chooseskill",3);
    }
    private void Update()
    {

        HealthBar.fillAmount = health / maxhealth;
        leveltext.text = "Slime Boss Level: " + level.ToString();
        if (health <= 0 && !died) { StartCoroutine(die()); }
        if (!died)
        {
 transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }

        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && skill1using)
        {
            player.GetComponent<stats>().takedamage(attack, penetration);
        }
    }
   void chooseskill()
    {
        if (!died)
        {
  int num = Random.Range(1,3);
        if (num == 1) { StartCoroutine(Skill1()); }
        else if (num == 2) { StartCoroutine(Skill2()); }
        }
      
    }
    public void takedamage(float damage, float penetration)
    {
        health -= damage * (1 - (defense - penetration) / 100);
    }
    public IEnumerator die()
    {
        
        this.gameObject.tag = null;
        died = true;
        player.GetComponent<stats>().stat.experience += level * level * experience;
        player.GetComponent<stats>().stat.SlimeGirlBossKillCount++;
        
        yield return new WaitForSecondsRealtime(5);
        SlimeGirlDeathEffect.SetActive(true);
   GameObject litgirl=Instantiate(littlegirl,transform.position,transform.rotation);
        litgirl.GetComponent<Animator>().SetBool("IsDamaged",true);
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        yield return new WaitForSecondsRealtime(2.56f);
        SlimeGirlDeathEffect.SetActive(false);
        litgirl.GetComponent<Animator>().SetBool("IsDamaged", false);
        if (GameObject.FindGameObjectsWithTag("littlegirl").Length > 1)
        {
            Destroy(litgirl);
        }
        Destroy(this.gameObject);
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
        yield return new WaitForSecondsRealtime(1);
        skill1using = true;
        anim.SetBool("Walking", false);
        anim.SetBool("Skill1Using", true);
        
        
         
        GameObject SBS1 = Instantiate(SlimeBallSpawner,transform.position+Vector3.up*7,transform.rotation);
        SBS1.GetComponent<slimeballspawner>().damage = attack;
        SBS1.GetComponent<slimeballspawner>().penetration = penetration;
        Vector3 playertransform = player.transform.position;
        transform.DOMove(playertransform, 1);
        GetComponent<AudioSource>().PlayOneShot(skillsound);
        yield return new WaitForSecondsRealtime(1);

        GameObject SBS2 = Instantiate(SlimeBallSpawner, transform.position+ Vector3.up * 7,transform.rotation);
        SBS2.GetComponent<slimeballspawner>().damage = attack;
        SBS2.GetComponent<slimeballspawner>().penetration = penetration;
        playertransform = player.transform.position;
        transform.DOMove(playertransform, 1);
        GetComponent<AudioSource>().PlayOneShot(skillsound);
        yield return new WaitForSecondsRealtime(1);

        GameObject SBS3 = Instantiate(SlimeBallSpawner, transform.position+ Vector3.up * 7,transform.rotation);
        SBS3.GetComponent<slimeballspawner>().damage = attack;
        SBS3.GetComponent<slimeballspawner>().penetration = penetration;
        playertransform = player.transform.position;
        transform.DOMove(playertransform, 1);
        GetComponent<AudioSource>().PlayOneShot(skillsound);
        yield return new WaitForSecondsRealtime(1);

        anim.SetBool("Walking", true);
        anim.SetBool("Skill1Using", false);
        skill1using = false;
        yield return new WaitForSecondsRealtime(2);
        SBS1.GetComponent<slimeballspawner>().blow();
        SBS2.GetComponent<slimeballspawner>().blow();
        SBS3.GetComponent<slimeballspawner>().blow();
        yield return new WaitForSecondsRealtime(2);
        chooseskill();

    }
    public IEnumerator Skill2()
    {
        yield return new WaitForSecondsRealtime(1);
        transform.DOMoveY(transform.position.y+10,1);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        skill1using = true;
        anim.SetBool("Walking", false);
        anim.SetBool("Skill2Using", true);
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < 25; i++)
        {
            if (i % 2 == 0)
            {
GameObject SpawnedBall= Instantiate(SlimeBall, hand1.transform.position,transform.rotation);
                SpawnedBall.transform.DOMoveY(player.transform.position.y, 0.5f);
                SpawnedBall.GetComponent<SlimeBall>().damage = attack;
                SpawnedBall.GetComponent<SlimeBall>().penetration = penetration;
            }
            else { 
                GameObject SpawnedBall = Instantiate(SlimeBall, hand2.transform.position, transform.rotation);
                SpawnedBall.transform.DOMoveY(player.transform.position.y,0.5f);
                SpawnedBall.GetComponent<SlimeBall>().damage = attack;
                SpawnedBall.GetComponent<SlimeBall>().penetration = penetration;
            }
          
            yield return new WaitForSecondsRealtime(0.25f-0.01f*i);
        }
        transform.DOMoveY(transform.position.y - 9, 1);
       
        yield return new WaitForSecondsRealtime(1);
        anim.SetBool("Walking", true);
        anim.SetBool("Skill2Using", false);
        yield return new WaitForSecondsRealtime(1);
        chooseskill();

    }
}
