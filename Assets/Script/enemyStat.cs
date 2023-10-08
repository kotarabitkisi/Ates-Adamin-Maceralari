using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enemyStat : MonoBehaviour
{
    [SerializeField] int soundnumber;
    public float health, attack, defense, penetration, maxhealth, experience, experienceforlevelup, level,timetodie,speed;
    [SerializeField] Animator anim;
    [SerializeField] GameObject Canvas,player,slimeBall;
    public bool canattack,attacking,running,died;
    [SerializeField] bool isProjectile;
    [SerializeField] float distancetorun, distancetoattack;
    [SerializeField] TextMeshProUGUI leveltext,healthtext;
    [SerializeField] Image HealthBar;
    [SerializeField] AudioClip zombiedeath, skeletondeath, slimedeath;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Canvas.transform.LookAt(Canvas.transform.position+new Vector3(0,-1,1));
        healthtext.text =health.ToString("0")+"/"+ maxhealth.ToString("0");
        HealthBar.fillAmount = health/maxhealth;
        leveltext.text ="Level: "+ level.ToString();
        if (health <= 0&&!died) { die(); }
            
        else if (Vector3.Distance(player.transform.position, transform.position) <= distancetoattack&&canattack)
        {
            canattack=false;
            running = false;
            attacking = true;
            if (!isProjectile) {StartCoroutine(attacktoplayer()); }
            else
            {
                this.transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                StartCoroutine(attacktoplayerProjectile());
            }
        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= distancetorun&&!attacking)
        {
            running = true; 
            anim.SetBool("Attacking",false);
            anim.SetBool("Running", true);
        }
    }
    private void FixedUpdate()
    {
       
        if (running&&!attacking&&!died) {
           
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            GetComponent<Rigidbody>().AddForce(transform.forward*speed);
                }
    }
    public void takedamage(float damage,float penetration)
    {
      health -= damage*(1-(defense-penetration)/100);
    }
    public void die() 
    {
        if (soundnumber == 1) { GetComponent<AudioSource>().PlayOneShot(zombiedeath); }
        else if (soundnumber == 2) { GetComponent<AudioSource>().PlayOneShot(slimedeath); }
        else if (soundnumber == 3) { GetComponent<AudioSource>().PlayOneShot(skeletondeath); }
        GetComponent<CapsuleCollider>().enabled= false;
        if (this.gameObject.tag != null)
        {
this.gameObject.tag = null;
        }
        
        died = true;
        player.GetComponent<stats>().stat.experience += level * level * experience;
        
        anim.SetBool("Died", true);
        anim.SetBool("Attacking", false);
        anim.SetBool("Running", false);
        Destroy(this.gameObject, timetodie);
    }
    public IEnumerator attacktoplayer()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Attacking", true);
        yield return new WaitForSecondsRealtime(2);
        player.GetComponent<stats>().takedamage(attack,penetration);
        canattack=true;
        attacking = false;
    }
    public IEnumerator attacktoplayerProjectile()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Attacking", true);
        yield return new WaitForSecondsRealtime(0.6f);
        shoot(attack,2);
        canattack = true;
        attacking = false;
    }
    public void shoot(float damage, float scale)
    {
        GameObject shootedfire = Instantiate(slimeBall, transform.position + transform.forward * 10 + Vector3.up * 10, this.transform.rotation);
        shootedfire.GetComponent<SlimeBall>().damage = damage;
        shootedfire.transform.DOScale(new Vector3(1, 1, 1) * scale, 0.25f);
    }
    public void Initialize()
    {

        maxhealth *= 1 + (level * 0.5f);
        health *= 1 + (level * 0.5f);
        defense *= 1 + (level * 0.1f);
        penetration *= 1 + (level * 0.2f);
        attack *= 1 + (level * 0.25f);
    }
}
