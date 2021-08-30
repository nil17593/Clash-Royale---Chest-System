using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CommonButtonController : MonoBehaviour
    {
        public GameObject commonBtnPannel;

        public void OnCommonButtonClick()
        {
            Debug.Log("Pannel is called");
            Instantiate(commonBtnPannel, this.transform.position, Quaternion.identity);
        }
    }
}