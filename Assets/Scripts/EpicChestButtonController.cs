using System.Collections;
using UnityEngine;


public class EpicChestButtonController : MonoBehaviour
{
    public GameObject epicBtnPannel;

    public void OnEpicButtonClick()
    {
        Debug.Log("Pannel is called");
        Instantiate(epicBtnPannel, this.transform.position, Quaternion.identity);
        //epicBtnPannel.interactable = false;
    }
}
