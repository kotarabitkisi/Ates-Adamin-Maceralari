using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonKingBoss : MonoBehaviour
{
    [SerializeField] AudioClip skillsound;
    public float health, attack, defense, penetration, maxhealth, experience, level, timetodie, speed;
    [SerializeField] int skillspeed;
    [SerializeField] Animator anim;
    [SerializeField] GameObject hand1;
    [SerializeField] GameObject player, BossBall, BossBallSpawner,SkeletonKingClone;
    [SerializeField] bool skill1using, skill2using,skill3using,died;
    [SerializeField] TextMeshProUGUI leveltext;
    [SerializeField] Image HealthBar;
    [SerializeField] GameObject[] childs;
    [SerializeField] Material SkeletonMaterial, CloakMaterial,CloneMaterial;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("chooseskill", 3);
    }
    private void Update()
    {
        skillspeed = (int)Mathf.Round(maxhealth / health);
        skillspeed = Mathf.Clamp(skillspeed, 1, 3);
        HealthBar.fillAmount = health / maxhealth;
        leveltext.text = "Skeleton Boss Level: " + level.ToString();
        if (health <= 0 && !died) { StartCoroutine(die()); }
        if (!died)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }


    }

   
    void chooseskill()
    {
       
        if (!died)
        {

            transform.DOMove(new Vector3(Random.Range(-75,75),transform.position.y, Random.Range(-75, 75)), 1);
            int num = Random.Range(1, 4);
            if (num == 1) { StartCoroutine(Skill1()); }
            else if (num == 2) { StartCoroutine(Skill2()); }
            else if (num == 3) { StartCoroutine(Skill3()); }
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
        player.GetComponent<stats>().stat.experience += level * experience;
        player.GetComponent<stats>().stat.SkeletonKingBossKillCount++;
     yield return new WaitForSecondsRealtime(1);
        player.GetComponent<MainCharacterMovement>().Canmove = false;
        this.transform.position = new Vector3(40,13,0);
        transform.rotation = Quaternion.Euler(0,-90,0);
        player.transform.position = new Vector3(-50, 13, 0);
        player.transform.rotation = Quaternion.Euler(0, 90, 0);
        StartCoroutine(GameObject.FindGameObjectWithTag("Finish").GetComponent<FinalAnimation>().FinalAnim());
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
        for (int i = 0; i < 10*skillspeed; i++)
        {
            GameObject Bball = Instantiate(BossBall, hand1.transform.position, Quaternion.LookRotation(transform.forward * Random.Range(0f, 1f) + transform.right * Random.Range(-1f, 1f)));
            Bball.GetComponent<SlimeBall>().damage = attack;
            Bball.GetComponent<SlimeBall>().penetration = penetration;
            yield return new WaitForSecondsRealtime(1/skillspeed);
        }
      chooseskill();
    }
    public IEnumerator Skill2()
    {
        transform.DOMove(new Vector3(0,transform.position.y,0), 1);
        yield return new WaitForSecondsRealtime(1);
      GameObject Clone1=  Instantiate(SkeletonKingClone,transform.position,Quaternion.identity);
        GameObject Clone2 = Instantiate(SkeletonKingClone, transform.position, Quaternion.identity);
        GameObject Clone3 = Instantiate(SkeletonKingClone, transform.position, Quaternion.identity);
        childs[0].GetComponent<MeshRenderer>().material = CloneMaterial;
        childs[1].GetComponent<SkinnedMeshRenderer>().material = CloneMaterial;
        int number = Random.Range(1,5);
        if (number == 1)
        {
            transform.DOMove(new Vector3(50, 10, 0),0.5f);
            Clone1.transform.DOMove(new Vector3(-50, 10, 0), 0.5f);
            Clone2.transform.DOMove(new Vector3(0, 10, 50), 0.5f);
            Clone3.transform.DOMove(new Vector3(0, 10, -50), 0.5f);
        }
        else if (number == 2)
        {
            Clone3.transform.DOMove(new Vector3(50, 10, 0), 0.5f);
            Clone1.transform.DOMove(new Vector3(-50,10, 0), 0.5f);
            Clone2.transform.DOMove(new Vector3(0, 10, 50), 0.5f);
            transform.DOMove(new Vector3(0, 10, -50), 0.5f);
        }
        else if (number == 3)
        {
            Clone2.transform.DOMove(new Vector3(50, 10, 0), 0.5f);
            Clone1.transform.DOMove(new Vector3(-50, 10, 0), 0.5f);
            transform.DOMove(new Vector3(0, 10, 50), 0.5f);
            Clone3.transform.DOMove(new Vector3(0, 10, -50), 0.5f);
        }
        else if (number == 4)
        {
            Clone1.transform.DOMove(new Vector3(50, 10, 0), 0.5f);
            transform.DOMove(new Vector3(-50, 10, 0), 0.5f);
            Clone2.transform.DOMove(new Vector3(0, 10, 50), 0.5f);
            Clone3.transform.DOMove(new Vector3(0, 10, -50), 0.5f);
        }
        yield return new WaitForSecondsRealtime(1/skillspeed);
        Clone1.GetComponent<skeletonbossclone>().shoot(attack,2);
        Clone2.GetComponent<skeletonbossclone>().shoot(attack, 2);
        Clone3.GetComponent<skeletonbossclone>().shoot(attack, 2);
        shoot(attack, 2);
        yield return new WaitForSecondsRealtime(1 / skillspeed);
        Clone1.GetComponent<skeletonbossclone>().shoot(attack, 2);
        Clone2.GetComponent<skeletonbossclone>().shoot(attack, 2);
        Clone3.GetComponent<skeletonbossclone>().shoot(attack, 2);
        shoot(attack, 2);
        yield return new WaitForSecondsRealtime(1 / skillspeed);
        Clone1.GetComponent<skeletonbossclone>().shoot(attack, 2);
        Clone2.GetComponent<skeletonbossclone>().shoot(attack, 2);
        Clone3.GetComponent<skeletonbossclone>().shoot(attack, 2);
        shoot(attack, 2);
        yield return new WaitForSecondsRealtime(5/skillspeed);
        Destroy(Clone1);
        Destroy(Clone2);
        Destroy(Clone3);
        childs[0].GetComponent<MeshRenderer>().material = CloakMaterial;
        childs[1].GetComponent<SkinnedMeshRenderer>().material = SkeletonMaterial;
        chooseskill();

    }
    public IEnumerator Skill3()
    {
        for (int i = 0; i < 30 * skillspeed; i++)
        {
            GameObject Bball = Instantiate(BossBall, new Vector3(Random.Range(-100, 100), 75, Random.Range(-75, 75)), Quaternion.Euler(90,0,0));
            Bball.GetComponent<SlimeBall>().damage = attack;
            Bball.GetComponent<SlimeBall>().penetration = penetration;
            yield return new WaitForSecondsRealtime(0.01f);
            Bball.transform.DOMoveY(0,1);
            yield return new WaitForSecondsRealtime(1 / skillspeed);
        }
        chooseskill();
    }
    public void shoot(float damage, float scale)
        {
            GameObject shootedfire = Instantiate(BossBall, transform.position + transform.forward * 10 + Vector3.up * 10, this.transform.rotation);
            shootedfire.GetComponent<SlimeBall>().damage = damage;
            shootedfire.transform.DOScale(new Vector3(1, 1, 1) * scale, 0.25f);
        }
}
