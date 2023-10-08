using System.Collections;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject ChosenBossforSpawn, SpawnedBoss, Canvas, BossSpawnEffect;
    public bool usable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && SpawnedBoss == null)
        {
            usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            usable = false;
        }
    }
    private void Update()
    {
        if (usable && Input.GetKeyDown(KeyCode.F))
        {
            ChangeBossPanel(true);
        }
    }
    public void SpawnTheBoss(int level)
    {
        StartCoroutine(StarttoSpawnBoss(level));

    }
    public void ChangeBossPanel(bool IsActive)
    {
        Canvas.SetActive(IsActive);
    }

    public IEnumerator StarttoSpawnBoss(int level) { 
        usable = false;
        Canvas.SetActive(false);
        BossSpawnEffect.SetActive(true);
        yield return new WaitForSeconds(5);
        GameObject Boss = Instantiate(ChosenBossforSpawn, transform.position + Vector3.up * 5, Quaternion.identity);
        BossSpawnEffect.SetActive(false);
        if (Boss.tag == "ZombieBoss")
        {
            Boss.GetComponent<ZombieBoss>().level = level;
            Boss.GetComponent<ZombieBoss>().Initialize();
        }
        if (Boss.tag == "SlimeGirlBoss")
        {
            Boss.GetComponent<SlimeBoss>().level = level;
            Boss.GetComponent<SlimeBoss>().Initialize();
        }
        if (Boss.tag == "SkeletonKingBoss")
        {
            Boss.GetComponent<SkeletonKingBoss>().level = level;
            Boss.GetComponent<SkeletonKingBoss>().Initialize();
        }
        SpawnedBoss = Boss; 
    }
}
