using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{

    public bool Attacking, Running, Dashing, Died;
    public bool startattackworking, startdashworking,isindialog;
    public bool Canmove;
    public AudioClip alevtopusesi;
    public AudioSource audiosource;
    [SerializeField] Animator anim;
  public GameObject fire, dialogcharacter, pooler;
    private void Update()
    {
        
        GetComponent<Rigidbody>().AddForce(new Vector3(0,-250,0));
         if (!isindialog)
        {
            if (Attacking || Died)
            {

            }
            else if (Input.GetMouseButton(0)&&Canmove)
            {
                Attacking = true;
                if (!startattackworking) { StartCoroutine(startattack()); }

            }
            else if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)&&Canmove)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {

                    Running = false;
                    Dashing = true;
                }
                else
                {

                    Running = true;

                }
            }
            else
            {

                Running = false;

            }
        } 
        anim.SetBool("Attacking", Attacking);
        anim.SetBool("Running", Running);
        anim.SetBool("Died", Died);
        anim.SetBool("Idling", !Attacking && !Running && !Dashing && !Died);
        if (Dashing||startdashworking)
        {
            if (!startdashworking)
            {
             startDash();
            }
        }
    }
    private void FixedUpdate()
    {
       
       
        
        if (Running&&!startattackworking&&Canmove)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"))*GetComponent<stats>().stat.speed);
            Vector3 yön=GetComponent<Rigidbody>().velocity;
            if (yön != Vector3.zero)
            {
            transform.rotation = Quaternion.LookRotation(yön);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
        }
    }
    public IEnumerator startattack()
    {
        startattackworking = true;
        Attacking=false;
        yield return new WaitForSecondsRealtime(0.33f);
        if (!Attacking) { startattackworking = false; yield break; }
        shoot(GetComponent<stats>().stat.attack,2);
        Attacking = false;
        yield return new WaitForSecondsRealtime(0.42f);
        Attacking = false;
        yield return new WaitForSecondsRealtime(0.33f);
        if (!Attacking) { startattackworking = false; yield break; }
            shoot(GetComponent<stats>().stat.attack, 2);
        Attacking = false;
        yield return new WaitForSecondsRealtime(0.42f);
        Attacking = false;
        yield return new WaitForSecondsRealtime(0.33f);
        if (!Attacking) { startattackworking = false; yield break; }
            shoot(3*GetComponent<stats>().stat.attack, 4);
        Attacking = false;
        yield return new WaitForSecondsRealtime(1);
        Attacking = false;
        startattackworking = false;
    }
    public void startDash()
    {
        startdashworking = true;
        Dashing = false;
        anim.SetBool("Dashing",true);
        GetComponent<Rigidbody>().AddForce(transform.forward * GetComponent<stats>().stat.speed *50);
        Invoke("finishdash", 0.5f);
    }
    public void finishdash() {
        Dashing = false;
        startdashworking = false;
        anim.SetBool("Dashing", false);
    }
    public void shoot(float damage,float scale)
    {
        audiosource.PlayOneShot(alevtopusesi);
        GameObject shootedfire = pooler.transform.GetChild(0).gameObject;
        shootedfire.transform.position = transform.position + Vector3.up * 8+transform.forward*5;
        shootedfire.SetActive(true);
        shootedfire.transform.parent = null;
        shootedfire.GetComponent<atestopu>().damage = damage;
        shootedfire.GetComponent<atestopu>().penetration = GetComponent<stats>().stat.penetration;
        shootedfire.transform.localScale=new Vector3(0.001f,0.001f,0.001f);
        shootedfire.transform.DOScale(new Vector3(1,1,1)*scale,0.25f);
    }
}
