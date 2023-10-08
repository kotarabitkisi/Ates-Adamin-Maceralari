using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Camera, Player;
    [SerializeField] float speed, zoom;
    public bool canfollow;
    private void FixedUpdate()
    {
        if (canfollow)
        {
 GetComponent<Rigidbody>().velocity= (Player.transform.position - transform.position) *speed;
        if (Input.GetKey(KeyCode.Z)) { zoom += Time.fixedDeltaTime*3; }
        else if (Input.GetKey(KeyCode.X)) { zoom -= Time.fixedDeltaTime*3; }
        zoom = Mathf.Clamp(zoom, 6f, 12f);
        Camera.transform.localPosition = new Vector3(0, 6, -3) * zoom;
        }
       
    }
}
