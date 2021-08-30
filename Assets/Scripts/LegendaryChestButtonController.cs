using System.Collections;
using UnityEngine;

public class LegendaryChestButtonController : MonoBehaviour
{
    public GameObject legendaryBtnpannel;

    public void OnLegendaryButtonClick()
    {
        Debug.Log("Pannel is called");
        Instantiate(legendaryBtnpannel, this.transform.position, Quaternion.identity);
    }
}
