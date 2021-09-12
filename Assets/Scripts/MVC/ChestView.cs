using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestView : MonoBehaviour
{
    public ChestController chestController;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI TypeText;
    [SerializeField] private TextMeshProUGUI CoinsText;
    [SerializeField] private TextMeshProUGUI GemsText;
    [SerializeField] private TextMeshProUGUI StatusText;
    [SerializeField] private TextMeshProUGUI UnlockGemsText;
    public Sprite currentSprite;


    void Start()
    {
        transform.SetParent(ChestService.Instance.ChestSlotGroup.transform);
        chestController.MakeChestEmpty();
    }

    // Update is called once per frame
    /*  void Update()
      {
          if (chestController.startTimer)
          {
             chestController.StartUnlockingChest();
          }
      }
  */
    public void DisplayChestData()
    {
        TimerText.text = "Timer:" + DisplayTimerForChestOpening(chestController.ChestModel.TimeToUnlock);
        TypeText.text = "Type:" + chestController.ChestModel.Type;
        GemsText.text = "Gems:" + chestController.ChestModel.Gems.ToString();
        CoinsText.text = "Coins:" + chestController.ChestModel.Coins.ToString();
        StatusText.text = "Status:" + chestController.Status;
        UnlockGemsText.text = "GemsToUnlock:" + chestController.UnlockGems.ToString();
        gameObject.GetComponent<Image>().sprite = currentSprite;
    }

    public void ChestButtonClicked()
    {
        chestController.ChestClicked();
    }

    public void DisplayTimerAndUnlockGems(int timeLeft, int UnlockGems)
    {
        TimerText.text = "Timer:" + DisplayTimerForChestOpening(timeLeft);
        UnlockGemsText.text = "GemsToUnlock:" + UnlockGems.ToString();
    }

    public string DisplayTimerForChestOpening(int timeInSec)
    {
        //Debug.Log("TimeInSec=" + timeInSec);
        string Time = timeInSec.ToString();
        if (timeInSec >= 60)
        {
            int min = timeInSec / 60;
            if (min >= 60)
                min = min % 60;
            int sec = timeInSec % 60;
            int hour = timeInSec / 3600;
            if (hour > 0)
                Time = hour.ToString() + "hr" + min.ToString() + "min" + sec.ToString();
            else
                Time = min.ToString() + "min" + sec.ToString();
        }
        return Time + "sec";
    }

}