using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonbossdoor : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
