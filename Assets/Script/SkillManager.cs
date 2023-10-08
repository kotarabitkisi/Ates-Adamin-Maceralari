using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] GameObject fire,fireblow,SkillPet,firepooler,UltBlowPooler;
    [SerializeField] ScriptableForStats stats;
    public float skill1cd,skill2cd,skill3cd;
    public float skill1cdtime, skill2cdtime, skill3cdtime;
    [SerializeField] AudioClip kuþsesi;
    private void FixedUpdate()
    {
        skill1cd -= Time.fixedDeltaTime;
        skill2cd -= Time.fixedDeltaTime;
        skill3cd -= Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&&skill1cd<=0&&GetComponent<MainCharacterMovement>().Canmove)
        {
            skill1cd = skill1cdtime;
            StartCoroutine(skill1(stats.attack,stats.penetration,1));
        }
        else  if (Input.GetKeyDown(KeyCode.E) && skill2cd <= 0 && GetComponent<MainCharacterMovement>().Canmove)
        {
            skill2cd = skill2cdtime;
         GetComponent<AudioSource>().PlayOneShot(kuþsesi);
            Instantiate(SkillPet, transform.position + Vector3.up * 3,transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.R) && skill3cd <= 0 && GetComponent<MainCharacterMovement>().Canmove)
        {
            skill3cd = skill3cdtime;
            StartCoroutine(skill3());
        }
    }
    public IEnumerator skill1(float damage,float penetration, float scale)
    {
        GameObject[] fires=new GameObject[8];
        for (int i = 0; i < 8; i++)
        {
            fires[i] = firepooler.transform.GetChild(0).gameObject;
            fires[i].SetActive(true);
            fires[i].transform.position=this.transform.position;
            fires[i].transform.parent = this.transform;
            fires[i].GetComponent<SphereCollider>().enabled = false;
            fires[i].GetComponent<atestopu>().speed = 0;
            fires[i].GetComponent<atestopu>().damage = damage;
            fires[i].GetComponent<atestopu>().penetration = penetration;
            fires[i].transform.DOScale(new Vector3(1, 1, 1) * scale, 0.25f);

        }
        fires[0].transform.DOLocalMove(new Vector3(-1, 1, 1) * 3, 0.5f);
        fires[1].transform.DOLocalMove(new Vector3(-Mathf.Sqrt(2), 1, 0) * 3, 0.5f);
        fires[2].transform.DOLocalMove(new Vector3(-1, 1, -1) * 3, 0.5f);
        fires[3].transform.DOLocalMove(new Vector3(1, 1, 1) * 3, 0.5f);
        fires[4].transform.DOLocalMove(new Vector3(1, 1, -1) * 3, 0.5f);
        fires[5].transform.DOLocalMove(new Vector3(Mathf.Sqrt(2), 1, 0) * 3, 0.5f);
        fires[6].transform.DOLocalMove(new Vector3(0, 1, -Mathf.Sqrt(2)) * 3, 0.5f);
        fires[7].transform.DOLocalMove(new Vector3(0, 1, Mathf.Sqrt(2)) * 3, 0.5f);
        yield return new WaitForSecondsRealtime(2);
        for (int i = 0; i < 8; i++)
        {
            fires[i].transform.parent = null;
            fires[i].GetComponent<atestopu>().speed=25;
            fires[i].GetComponent<SphereCollider>().enabled = true;
        }

    }
    public IEnumerator skill3()
    {
        GameObject FirstObject = UltBlowPooler.transform.GetChild(0).gameObject;
        FirstObject.transform.localScale = Vector3.zero;
        FirstObject.transform.parent = null;
        FirstObject.SetActive(true);
        FirstObject.transform.position = transform.position +Vector3.up*10;
        FirstObject.transform.DOScale(new Vector3(1, 1, 1) * 25000, 5);
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject SecondObject= UltBlowPooler.transform.GetChild(0).gameObject;
        SecondObject.transform.localScale = Vector3.zero;
        SecondObject.transform.parent = null;
        SecondObject.SetActive(true);
        SecondObject.transform.position = transform.position + Vector3.up * 10;
        SecondObject.transform.DOScale(new Vector3(1, 1, 1) * 25000, 5);
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject ThirdObject = UltBlowPooler.transform.GetChild(0).gameObject;
        ThirdObject.transform.localScale = Vector3.zero;
        ThirdObject.transform.parent = null;
        ThirdObject.SetActive(true);
        ThirdObject.transform.position = transform.position + Vector3.up * 10;
        ThirdObject.transform.DOScale(new Vector3(1, 1, 1) * 25000, 5);
        yield return new WaitForSecondsRealtime(4);
        FirstObject.SetActive(false);
        FirstObject.transform.parent= UltBlowPooler.transform;
        FirstObject.transform.localPosition = Vector3.zero;
        yield return new WaitForSecondsRealtime(0.5f);
        SecondObject.SetActive(false);
        SecondObject.transform.parent = UltBlowPooler.transform;
        SecondObject.transform.localPosition = Vector3.zero;
        yield return new WaitForSecondsRealtime(0.5f);
        ThirdObject.SetActive(false);
        ThirdObject.transform.parent = UltBlowPooler.transform;
        ThirdObject.transform.localPosition = Vector3.zero;
    }
}
