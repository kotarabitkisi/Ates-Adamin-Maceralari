using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogcode : MonoBehaviour
{
    public int dialognumber;
    public bool candialog,dialogfinished,ishaberci;
    public GameObject presstodialogtext, dialogCanvas,GM,MC;
    private void Start()
    {
        MC = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&dialognumber>=1)
        {
            dialogCanvas.gameObject.transform.GetChild(dialognumber - 1).gameObject.SetActive(false);
            dialognumber = 0;
            dialogfinished = true;
            MC.GetComponent<MainCharacterMovement>().isindialog = false;
        }
      else if (candialog && Input.GetKeyDown(KeyCode.F))
        {
            dialognumber++;
         
            if (dialognumber == 1) { dialogCanvas.transform.GetChild(dialognumber - 1).gameObject.SetActive(true); dialogfinished = false; MC.GetComponent<MainCharacterMovement>().isindialog = true;}
            else if (dialognumber > dialogCanvas.transform.childCount)
            {
                dialogfinished = true;
                dialogCanvas.gameObject.transform.GetChild(dialognumber - 2).gameObject.SetActive(false);
                dialognumber = 0;
                MC.GetComponent<MainCharacterMovement>().isindialog = false;
                if (GM != null)
                {
if (GM.GetComponent<StoryCode>().StoryNumber == 1&& ishaberci)
                {
                    GM.GetComponent<StoryCode>().StoryNumber++;
                }
                }
                
            }
            else if (dialognumber > 1)
            {
                dialogfinished = false;
                dialogCanvas.gameObject.transform.GetChild(dialognumber - 2).gameObject.SetActive(false);
                dialogCanvas.gameObject.transform.GetChild(dialognumber - 1).gameObject.SetActive(true);
            }

        }
       
        
            presstodialogtext.SetActive(candialog);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            candialog = true;
            other.gameObject.GetComponent<MainCharacterMovement>().dialogcharacter = this.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<MainCharacterMovement>().dialogcharacter = this.gameObject;
            candialog = false;
        }
    }
}
