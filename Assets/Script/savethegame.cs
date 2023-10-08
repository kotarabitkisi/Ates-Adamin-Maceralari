using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savethegame : MonoBehaviour
{
  [SerializeField]  GameObject GM,Canvas,Pressfcanvas;
    bool canchangecanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&& canchangecanvas) {
            Changepage(true);
        }
       else if (Input.GetKeyDown(KeyCode.Escape)&& canchangecanvas)
        {
            Changepage(false);
        }
    }
    public void Changepage(bool isActive)
    {
        Canvas.SetActive(isActive);
    }
    public void Save()
    {
        GM.GetComponent<saveandload>().Save();
        Canvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            canchangecanvas = true;
            Pressfcanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            canchangecanvas = false;
            Pressfcanvas.SetActive(true);
        }
    }
}
