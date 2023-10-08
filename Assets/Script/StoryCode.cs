using DG.Tweening;
using System.Collections;
using UnityEngine;

public class StoryCode : MonoBehaviour
{
    public bool habercirunning;
   public int StoryNumber;
   public GameObject Haberci,Þef,MC,Anne;
    public ScriptableForStats statMC;
    private void Update()
    {
        
        switch (StoryNumber)
        {
            case 1:
                Haberci.GetComponent<dialogcode>().dialogCanvas = Haberci.transform.GetChild(6).gameObject;
                break;
            case 2:
                if (!habercirunning)
                {
                StartCoroutine(SNtwotothree());
                }
                break;
            case 3:
                Haberci.GetComponent<dialogcode>().dialogCanvas = Haberci.transform.GetChild(7).gameObject;

                if(Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog) 
                {
                    StoryNumber = 4; Þef.GetComponent<dialogcode>().dialogfinished = false; 
                }
                break;
            case 4:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(7).gameObject;

                if(statMC.level >= 10) { StoryNumber = 5; Þef.GetComponent<dialogcode>().dialogfinished = false; }
                break;
            case 5:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(8).gameObject;

                if (Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog)
                {
                    StoryNumber = 6; Þef.GetComponent<dialogcode>().dialogfinished = false;
                }
                break;
            case 6:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(9).gameObject;
                if (statMC.ZombieBossKillCount>=1)
                {
                    StoryNumber = 7; Þef.GetComponent<dialogcode>().dialogfinished = false;
                  
                }
                break;
            case 7:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(10).gameObject;
                if (Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog)
                {
                    StoryNumber = 8; Þef.GetComponent<dialogcode>().dialogfinished = false;
                    
                }
                break;
            case 8:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(11).gameObject;
                if (statMC.level >= 20)
                {
                    StoryNumber = 9; Þef.GetComponent<dialogcode>().dialogfinished = false;
                    Anne.SetActive(true);

                }
                break;
            case 9:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(12).gameObject;
                
                if (Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog)
                {
                    StoryNumber = 10; Þef.GetComponent<dialogcode>().dialogfinished = false;

                }
                break;
            case 10:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(13).gameObject;
                if (statMC.SlimeGirlBossKillCount>=1)
                {
                    StoryNumber = 11; Þef.GetComponent<dialogcode>().dialogfinished = false;

                }
                break;
            case 11:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(14).gameObject;
                if (Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog)
                {
                    StoryNumber = 12; Þef.GetComponent<dialogcode>().dialogfinished = false;

                }

                break;
            case 12:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(15).gameObject;
                if (statMC.level>=50)
                {
                    StoryNumber = 13; Þef.GetComponent<dialogcode>().dialogfinished = false;

                }
                break;
            case 13:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(16).gameObject;
                if (Þef.GetComponent<dialogcode>().dialogfinished && Þef.GetComponent<dialogcode>().candialog)
                {
                    StoryNumber = 14; Þef.GetComponent<dialogcode>().dialogfinished = false;

                }
                break;
            case 14:
                Þef.GetComponent<dialogcode>().dialogCanvas = Þef.transform.GetChild(17).gameObject;
                if (statMC.SkeletonKingBossKillCount>=1)
                {
                    StoryNumber = 15; Þef.GetComponent<dialogcode>().dialogfinished = false;
                }
                break;
        }

    }
    IEnumerator SNtwotothree()
    {
        habercirunning = true;
        Haberci.GetComponent<BoxCollider>().enabled = false;
        Haberci.GetComponent<Animator>().SetBool("Running",true);
        Haberci.GetComponent<dialogcode>().candialog = false;
        Haberci.transform.DOMove(new Vector3(680, 50, 1610), 30);
        Haberci.transform.LookAt(new Vector3(680, 50, 1610));

        yield return new WaitForSecondsRealtime(30);
        Haberci.GetComponent<BoxCollider>().enabled = true;
        Haberci.GetComponent<Animator>().SetBool("Running", false);
        StoryNumber = 3;
        Haberci.transform.DORotate(new Vector3(0,180,0),1);
    }
}
