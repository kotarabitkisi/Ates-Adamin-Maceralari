using DG.Tweening;
using UnityEngine;

public class ending : MonoBehaviour
{
    [SerializeField] GameObject panelObj;
    private void Start()
    {
        panelObj.GetComponent<RectTransform>().DOMoveY(2000, 50);
    }
    
}
