using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ChestController
{
    public string Status;//chest locked or unlocked
    public int UnlockGems;//gems to unlock 
    public bool addedToQueue;
    public bool isEmpty;
    public bool locked;
    private Sprite emptySprite;
    //Timer timer;
    //public bool startTimer;

    public ChestModel ChestModel { get; }
    public ChestView ChestView { get; }

    public ChestController(ChestModel chestModel, ChestView chestPrefab, Sprite chestSprite)
    {
        ChestModel = chestModel;
        ChestView = GameObject.Instantiate<ChestView>(chestPrefab);
        ChestView.chestController = this;
        emptySprite = chestSprite;
        Debug.Log("ChestView Created", ChestView);
        //timer = ChestView.GetComponent<Timer>();
    }

    //after opening chest will empty
    public void MakeChestEmpty()
    {
        ChestModel.SetType("Empty");
        ChestModel.SetCoins(0);
        ChestModel.SetGems(0);
        ChestModel.SetTimeToUnlock(0);
        isEmpty = true;
        Status = "Empty";
        addedToQueue = false;
        UnlockGems = 0;
        ChestView.currentSprite = emptySprite;
        ChestView.DisplayChestData();
    }

    public void AddChestToController(ChestScriptableObject chestSO, Sprite chestSprite)
    {
        locked = true;
        isEmpty = false;
        ChestModel.SetType(chestSO.chestType);
        ChestModel.SetCoins(UnityEngine.Random.Range(chestSO.minCoins, chestSO.maxCoins));
        ChestModel.SetGems(UnityEngine.Random.Range(chestSO.minGems, chestSO.maxGems));
        ChestModel.SetTimeToUnlock(chestSO.timeToUnlockChest);
        Status = "Locked";
        UnlockGems = CountGemsToUnlock(ChestModel.TimeToUnlock);
        ChestView.currentSprite = chestSprite;
        ChestView.DisplayChestData();
    }

    //returns count of gems to unlock chest
    public int CountGemsToUnlock(int timeToUnlock)
    {
        int noOfGems = 0;
        int unlockTimeInMin = timeToUnlock / 60;
        noOfGems = unlockTimeInMin / 10;
        return noOfGems + 1;
    }

    //opens chest with spending Gems
    public void UnlockChestUsingGems()
    {
        bool chestCanBeUnlocked = PlayerController.Instance.RemoveFromPlayer(UnlockGems);
        if (chestCanBeUnlocked)
            ChestUnlocked();
        else
        {
            ChestService.Instance.DisplayMessageOnPopUp("Unsufficient Gems. Cannot Unlock Chest");
        }
    }


    public void ChestUnlocked()
    {
        Debug.Log("Chest Unlocked");
        //startTimer = false;
        //timer.Enabled = false;
        locked = false;
        Status = "Unlocked";
        ChestModel.SetTimeToUnlock(0);
        UnlockGems = 0;
        ChestView.DisplayChestData();
        ChestService.Instance.UnlockNextChest(ChestView);
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void ChestClicked()
    {
        string message;
        if (isEmpty)
        {
            message = "Chest Slot is Empty";
            ChestService.Instance.DisplayMessageOnPopUp(message);
            return;
        }
        if (!locked)
        {
            PlayerController.Instance.AddToPlayer(ChestModel.Coins, ChestModel.Gems);
            message = "Added " + ChestModel.Coins + " coins and " + ChestModel.Gems + " gems";
            ChestService.Instance.DisplayMessageOnPopUp(message);
            MakeChestEmpty();
        }
        else
        {
            message = "Chest is Locked.";
            ChestService.Instance.DisplayPopUp(this, addedToQueue, message, UnlockGems);
        }
    }

    public void StartTimer()
    {
        //Activate Timer Script
        //timer.SetController(this);
        //.enabled = true;
    }

}