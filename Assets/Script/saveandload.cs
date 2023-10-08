using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveandload : MonoBehaviour
{
   [SerializeField] GameDataManager gameDataManager;
   [SerializeField] GameObject Betty, StoryCode, Atesadaminannesi, haberci, sef,MC,BettyPrefab;


    private void Start()
    {
        Load();
    }
    public void Save()
    {
        gameDataManager = new GameDataManager();
        gameDataManager.attack = MC.GetComponent<stats>().stat.attack;
        gameDataManager.defense = MC.GetComponent<stats>().stat.defense;
        gameDataManager.penetration = MC.GetComponent<stats>().stat.penetration;
        gameDataManager.health = MC.GetComponent<stats>().stat.health;
        gameDataManager.maxhealth = MC.GetComponent<stats>().stat.maxhealth;
        gameDataManager.experience = MC.GetComponent<stats>().stat.experience;
        gameDataManager.speed = MC.GetComponent<stats>().stat.speed;
        gameDataManager.level = MC.GetComponent<stats>().stat.level;
        gameDataManager.experienceforlevelup = MC.GetComponent<stats>().stat.experienceforlevelup;

        gameDataManager.skillpoint = MC.GetComponent<stats>().stat.skillpoint;
        gameDataManager.attacksp = MC.GetComponent<stats>().stat.attacksp;
        gameDataManager.defensesp = MC.GetComponent<stats>().stat.defensesp;
        gameDataManager.speedsp = MC.GetComponent<stats>().stat.speedsp;
        gameDataManager.healthsp = MC.GetComponent<stats>().stat.healthsp;
        gameDataManager.penetrationsp = MC.GetComponent<stats>().stat.penetrationsp;
        gameDataManager.experiencegainsp = MC.GetComponent<stats>().stat.experiencegainsp;

        gameDataManager.ZombieBossKillCount = MC.GetComponent<stats>().stat.ZombieBossKillCount;
        gameDataManager.SlimeGirlBossKillCount = MC.GetComponent<stats>().stat.SlimeGirlBossKillCount;
        gameDataManager.SkeletonKingBossKillCount = MC.GetComponent<stats>().stat.SkeletonKingBossKillCount;
        gameDataManager.storynumber = GetComponent<StoryCode>().StoryNumber;

        gameDataManager.isatesadaminannesiactive = Atesadaminannesi.activeSelf;
        gameDataManager.habercirunned = GetComponent<StoryCode>().StoryNumber >= 2;
        gameDataManager.isbettyactive = GetComponent<StoryCode>().StoryNumber >= 11;

        if(GetComponent<StoryCode>().StoryNumber >= 3)
        {
            gameDataManager.habercidialogcanvas = haberci.transform.GetChild(7).gameObject;
        }
        else { gameDataManager.habercidialogcanvas = haberci.transform.GetChild(6).gameObject; }
        if(GetComponent<StoryCode>().StoryNumber >= 4)
        {
            gameDataManager.þefdialogcanvas=sef.transform.GetChild(GetComponent<StoryCode>().StoryNumber+3).gameObject;
        }
        else { gameDataManager.þefdialogcanvas = sef.transform.GetChild(6).gameObject; }
        if (GetComponent<StoryCode>().StoryNumber >= 11) {gameDataManager.bettydialogcanvas= Betty.GetComponent<littlegirl>().secondCanvas; }

        string JsonString=JsonUtility.ToJson(gameDataManager);
        File.WriteAllText(Application.dataPath + "/Save.json", JsonString);

    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/Save.json"))
        {
            string readjson = File.ReadAllText(Application.dataPath + "/Save.json");
            GameDataManager savedstats = JsonUtility.FromJson<GameDataManager>(readjson);
            MC.GetComponent<stats>().stat.attack = savedstats.attack;
            MC.GetComponent<stats>().stat.defense = savedstats.defense;
            MC.GetComponent<stats>().stat.penetration = savedstats.penetration;
            MC.GetComponent<stats>().stat.speed = savedstats.speed;
            MC.GetComponent<stats>().stat.maxhealth = savedstats.maxhealth;
            MC.GetComponent<stats>().stat.health = savedstats.health;
            MC.GetComponent<stats>().stat.experienceforlevelup = savedstats.experienceforlevelup;
            MC.GetComponent<stats>().stat.experience = savedstats.experience;
            MC.GetComponent<stats>().stat.level = savedstats.level;

            MC.GetComponent<stats>().stat.skillpoint = savedstats.skillpoint;
            MC.GetComponent<stats>().stat.attacksp = savedstats.attacksp;
            MC.GetComponent<stats>().stat.defensesp = savedstats.defensesp;
            MC.GetComponent<stats>().stat.speedsp = savedstats.speedsp;
            MC.GetComponent<stats>().stat.healthsp = savedstats.healthsp;
            MC.GetComponent<stats>().stat.penetrationsp = savedstats.penetrationsp;
            MC.GetComponent<stats>().stat.experiencegainsp = savedstats.experiencegainsp;

            GetComponent<StoryCode>().StoryNumber = savedstats.storynumber;
            MC.GetComponent<stats>().stat.ZombieBossKillCount = savedstats.ZombieBossKillCount;
            MC.GetComponent<stats>().stat.SlimeGirlBossKillCount = savedstats.SlimeGirlBossKillCount;
            MC.GetComponent<stats>().stat.SkeletonKingBossKillCount = savedstats.SkeletonKingBossKillCount;

            Atesadaminannesi.SetActive(savedstats.isatesadaminannesiactive);
            haberci.GetComponent<dialogcode>().dialogCanvas = savedstats.habercidialogcanvas;
            sef.GetComponent<dialogcode>().dialogCanvas = savedstats.þefdialogcanvas;
            if (savedstats.habercirunned) { haberci.transform.position = new Vector3(680, 50, 1610); haberci.transform.rotation = Quaternion.Euler(0,180,0); }
            if (savedstats.isbettyactive) { Betty = Instantiate(BettyPrefab, new Vector3(530, 50, 1402),Quaternion.Euler(0, 180, 0)); 
            Betty.GetComponent<dialogcode>().dialogCanvas=savedstats.bettydialogcanvas;
            }
        }

        else { }

    }
    [System.Serializable]
    public class GameDataManager
    {
        public float health, attack, defense, penetration, maxhealth, experience, experienceforlevelup, level, speed;
        public int skillpoint, healthsp, attacksp, defensesp, penetrationsp, speedsp, experiencegainsp, ZombieBossKillCount, SlimeGirlBossKillCount, SkeletonKingBossKillCount, storynumber;
        public bool isatesadaminannesiactive, habercirunned, isbettyactive;
        public GameObject habercidialogcanvas, þefdialogcanvas, bettydialogcanvas;
    }
}
