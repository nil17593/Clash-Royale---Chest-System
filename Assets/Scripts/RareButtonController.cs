using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class RareButtonController : MonoBehaviour
{
    public GameObject rareBtnPannel;

    public void OnRareButtonClick()
    {
        Debug.Log("Pannel is called");
        Instantiate(rareBtnPannel, this.transform.position, Quaternion.identity);
    }
}