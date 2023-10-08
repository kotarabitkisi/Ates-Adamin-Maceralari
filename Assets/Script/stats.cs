using UnityEngine;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    public ScriptableForStats stat;
    [SerializeField] Animator anim;
    [SerializeField] bool isdied;
    private void Update()
    {
        if (stat.experience >= stat.experienceforlevelup)
        {
            levelup();
        }
        if (!isdied&&stat.health<=0)
        {
            GetComponent<MainCharacterMovement>().Died = true;
            isdied = true;
            die();
        }
    }
    public void levelup()
    {
        stat.level++;
        stat.experience -= stat.experienceforlevelup;
        stat.maxhealth = 100 * (1 + 0.2f * stat.level + 0.4f * stat.healthsp);
        if (stat.level == 2) { stat.experienceforlevelup = 150; }
        else {
        stat.experienceforlevelup = 50 * (stat.level-2) * (stat.level-2) / (1 - 0.1f * stat.experiencegainsp); 
        }
        stat.attack= 5 * (1 + 0.25f * stat.level + 0.5f * stat.attacksp);
        stat.defense = 5 * (1 + 0.05f * stat.level + 0.5f * stat.defensesp);
        stat.health = 100 * (1 + 0.2f * stat.level + 0.4f * stat.healthsp);
        stat.penetration= 5 * (1 + 0.2f * stat.level + 0.5f * stat.penetrationsp);
        stat.speed = 200 * (1 + 0.025f * stat.level + 0.1f * stat.speedsp);
        stat.skillpoint++;

    }
    public void SkillPointUsed()
    {
        stat.maxhealth = 100 * (1 + 0.2f * stat.level + 0.4f * stat.healthsp);
        if (stat.level == 2) { stat.experienceforlevelup = 150; }
        else
        {
            stat.experienceforlevelup = 100 * stat.level * (stat.level - 2)/(1-0.1f*stat.experiencegainsp);
        }
        stat.attack = 5 * (1 + 0.25f * stat.level + 0.5f * stat.attacksp);
        stat.defense = 5 * (1 + 0.05f * stat.level + 0.5f * stat.defensesp);
        stat.health = 100 * (1 + 0.2f * stat.level + 0.4f * stat.healthsp);
        stat.penetration = 5 * (1 + 0.2f * stat.level + 0.5f * stat.penetrationsp);
        stat.speed = 200 * (1 + 0.025f * stat.level + 0.1f * stat.speedsp);
    }
    public void takedamage(float damage,float penetration)
    {
        if(!gameObject.GetComponent<MainCharacterMovement>().startdashworking)
        stat.health -= damage*(1-(stat.defense-penetration)/100);
    }
    public void die() 
    {
        GetComponent<MainCharacterMovement>().Canmove = false;
        anim.SetBool("Died", true);
        Invoke("kaybetmeekranýaç", 3);
    }
    public void kaybetmeekranýaç()
    {
        canvas.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene("Village");
    }
    public void oyundançýk()
    {
        Application.Quit();
    }
}
