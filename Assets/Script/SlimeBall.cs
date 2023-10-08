using DG.Tweening;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    public float speed,damage,penetration;
     GameObject player;
    private void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");
        Destroy(this.gameObject,10);
        transform.DOMoveY(player.transform.position.y,1);
    }
    private void FixedUpdate()
    {
        
        transform.Translate(new Vector3(0,0,speed * Time.fixedDeltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<stats>().takedamage(damage,penetration);
            Destroy(this.gameObject);
        }
    }
   
}
