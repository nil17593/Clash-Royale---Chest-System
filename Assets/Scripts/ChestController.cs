using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public Button buttonCreateChest;
    public Image slotFullPanel;
    public Image[] images;
    public Button[] chestButtons;
    int num = 0;

        
    public void OnCreateChestButtonClick()
    {
        CreateChest(GetRandomIndex());
    }

    void CreateChest(int chestNum)
    {
        if (num < 4)
        {
            images[num].gameObject.SetActive(false);
            Button chestSlot = Instantiate(chestButtons[chestNum], images[num].gameObject.transform.position, Quaternion.identity);
            chestSlot.gameObject.transform.SetParent(this.transform);
            num++;
        }
        else
        {
            slotFullPanel.gameObject.SetActive(true);
            Debug.Log("All chest slots are Occupied");
        }

    }

    public void CloseButtonOnClick()
    {
        slotFullPanel.gameObject.SetActive(false);
    }

    int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, chestButtons.Length);
        return randomIndex;
    }
}
