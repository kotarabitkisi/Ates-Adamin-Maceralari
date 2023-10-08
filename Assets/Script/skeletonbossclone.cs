using DG.Tweening;
using UnityEngine;

public class skeletonbossclone : MonoBehaviour
{
   [SerializeField] GameObject player, BossBall,hand;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
    public void shoot(float damage, float scale)
    {
        GameObject shootedfire = Instantiate(BossBall, hand.transform.position, this.transform.rotation);
        shootedfire.GetComponent<SlimeBall>().damage = damage;
        
        shootedfire.transform.DOScale(new Vector3(1, 1, 1) * scale, 0.25f);
    }
}
