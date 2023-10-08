using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
  [SerializeField] float minX,maxX,minY,maxY,minZ,maxZ,spawnrate;
   [SerializeField] int numberofmob,minlvl,maxlvl,minnumber,maxnumber;
    [SerializeField] bool canspawn;
  [SerializeField] GameObject zombie,skeleton,slime,terrain;
    private void Start()
    {
        numberofmob = Random.Range(minnumber,maxnumber+1);
       
        if (numberofmob == 1) {StartCoroutine(spawn(zombie,Random.Range(minlvl,maxlvl+1))); }
        else if (numberofmob == 2) { StartCoroutine(spawn(skeleton, Random.Range(minlvl, maxlvl + 1))); }
        else if (numberofmob == 3) { StartCoroutine(spawn(slime, Random.Range(minlvl, maxlvl + 1))); }
        
        
                
    }
    private void Update()
    {
        spawnrate = 2 * -(Mathf.Abs(terrain.GetComponent<GeceGündüzDöngüsü>().time - 360)/180 - 2)+1;
    }
    IEnumerator spawn(GameObject mob,int level)
    {
        if (canspawn) {
        GameObject spawnedmob = Instantiate(mob,new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)),Quaternion.identity);
        spawnedmob.GetComponent<enemyStat>().level = level;
        spawnedmob.GetComponent<enemyStat>().Initialize();
        }
        yield return new WaitForSecondsRealtime(10 / spawnrate);
        numberofmob = Random.Range(minnumber, maxnumber + 1);
        if (numberofmob == 1) { StartCoroutine(spawn(zombie, Random.Range(minlvl, maxlvl + 1))); }
        else if (numberofmob == 2) { StartCoroutine(spawn(skeleton, Random.Range(minlvl, maxlvl + 1))); }
        else if (numberofmob == 3) { StartCoroutine(spawn(slime, Random.Range(minlvl, maxlvl + 1))); }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            canspawn=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canspawn = false;
        }
    }
}
