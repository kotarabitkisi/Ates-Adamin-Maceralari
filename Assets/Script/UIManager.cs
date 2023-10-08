using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject MC;
    [SerializeField] GameObject statspanel,ControlsPanel;
    public bool statsopened;
    [SerializeField] TextMeshProUGUI Attack, Health, Defense, Penetration, Level, Speed,SPcount;
    public ScriptableForStats Stats;
    public Image ASPBar, DSPBar, PSPBar, SSPBar, EGSPBar, HSPBar, skill1, skill2, skill3;

   [SerializeField] Image can,exp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {ControlsPanel.SetActive(false);}
        exp.fillAmount = Stats.experience / Stats.experienceforlevelup;
        can.fillAmount = Stats.health / Stats.maxhealth;
        skill1.fillAmount = MC.GetComponent<SkillManager>().skill1cd / MC.GetComponent<SkillManager>().skill1cdtime;
        skill2.fillAmount = MC.GetComponent<SkillManager>().skill2cd / MC.GetComponent<SkillManager>().skill2cdtime;
        skill3.fillAmount = MC.GetComponent<SkillManager>().skill3cd / MC.GetComponent<SkillManager>().skill3cdtime;
    }
   public void MovePanel(GameObject Panel)
    {
        Attack.text ="Attack: "+ Stats.attack.ToString();
        Health.text = "Health: " + Stats.health.ToString("0")+"/"+ Stats.maxhealth.ToString("0");
        Defense.text = "Defense: " + Stats.defense.ToString();
        Penetration.text = "Penetration: " + Stats.penetration.ToString();
        Level.text = "Level: " + Stats.level.ToString();
        Speed.text = "Speed: " + Stats.speed.ToString();
        SPcount.text = "Skill Point: " +Stats.skillpoint;
        ASPBar.fillAmount = (float)Stats.attacksp / 5;
        DSPBar.fillAmount = (float)Stats.defensesp / 5;
        PSPBar.fillAmount = (float)Stats.penetrationsp / 5;
        SSPBar.fillAmount = (float)Stats.speedsp / 5;
        EGSPBar.fillAmount = (float)Stats.experiencegainsp / 5;
        HSPBar.fillAmount = (float)Stats.healthsp / 5;
        statsopened = !statsopened;
        if (statsopened)
        {
            Panel.transform.DOMoveX(Screen.width/2, 2);
        }
        else 
        {
            Panel.transform.DOMoveX(Screen.width+772, 2);
        }
    }

    public void attacksparttýr() {
        if (Stats.skillpoint > 0&&Stats.attacksp!=5) {
            Stats.skillpoint--;
            Stats.attacksp++;
            ASPBar.fillAmount =(float)Stats.attacksp/5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
    public void Defensesparttýr() {
        if (Stats.skillpoint > 0 && Stats.defensesp != 5)
        {
            Stats.skillpoint--;
            Stats.defensesp++;
            DSPBar.fillAmount = (float)Stats.defensesp / 5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
    public void Penetrationsparttýr() {
        if (Stats.skillpoint > 0 && Stats.penetrationsp != 5)
        {
            Stats.skillpoint--;
            Stats.penetrationsp++;
            PSPBar.fillAmount = (float)Stats.penetrationsp / 5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
    public void Speedsparttýr() {
        if (Stats.skillpoint > 0 && Stats.speedsp != 5)
        {
            Stats.skillpoint--;
            Stats.speedsp++;
            SSPBar.fillAmount = (float)Stats.speedsp / 5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
    public void experiencegainsparttýr() {
        if (Stats.skillpoint > 0 && Stats.experiencegainsp != 5)
        {
            Stats.skillpoint--;
            Stats.experiencegainsp++;
            EGSPBar.fillAmount = (float)Stats.experiencegainsp / 5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
    public void healthsparttýr() {
        if (Stats.skillpoint > 0 && Stats.healthsp != 5)
        {
            Stats.skillpoint--;
            Stats.healthsp++;
            HSPBar.fillAmount = (float)Stats.healthsp / 5;
            MC.GetComponent<stats>().SkillPointUsed();
            SPcount.text = "Skill Point:" + Stats.skillpoint;
        }
    }
}
