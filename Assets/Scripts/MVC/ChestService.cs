using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestService : MonoGenericSingleton<ChestService>
{
    public GameObject ChestSlotGroup;
    [SerializeField] private int NoOfChestSlots;
    private ChestController[] ChestSlots;
    [SerializeField] private ChestScriptableObjectList chestSOL;
    [SerializeField] private List<ChestView> unlockingQueue;
    [SerializeField] private int AllowedChestToUnlock = 3;
    [SerializeField] private Sprite[] chestSprites;
    [SerializeField] private ChestView chestPrefab;
    public bool timerStarted = false;
    private ChestModel chestModel;
    private ChestController chestController;
    ChestView PopUpChest;


    void Start()
    {
        ChestSlots = new ChestController[NoOfChestSlots];
        for (int i = 0; i < NoOfChestSlots; i++)
        {
            ChestSlots[i] = CreateEmptyChestSlot();
        }
    }

    private ChestController CreateEmptyChestSlot()
    {
        return CreateNewChestController(chestSOL.chests[chestSOL.chests.Length-1], chestPrefab, chestSprites[chestSprites.Length-1]);
    }

    private ChestController CreateNewChestController(ChestScriptableObject chestScriptableObject, ChestView chestPrefab, Sprite chestSprite)
    {
        chestModel = new ChestModel(chestScriptableObject);
        chestController = new ChestController(chestModel, chestPrefab, chestSprite);
        return chestController;
    }

    public void StartUnlockingFirstChest()
    {
        unlockingQueue.Add(PopUpChest);
        Debug.Log("Unlocking queue=" + unlockingQueue.Count);
        PopUpChest.chestController.addedToQueue = true;
        PopUpChest.chestController.StartTimer();
    }

    internal void UnlockChestUsingGemsSelected()
    {
        PopUpChest.chestController.UnlockChestUsingGems();
    }

    public void CreateRandomChest()
    {
        int randomChest = UnityEngine.Random.Range(0, chestSOL.chests.Length - 1);
        AddChestToSlot(randomChest);
    }

    public void AddChestToUnlockingQueue()
    {
        if (timerStarted && unlockingQueue.Count == AllowedChestToUnlock)
        {
            Debug.Log("Unlocking Queue Limit Reached");
            DisplayMessageOnPopUp("Unlocking Queue Limit Reached");
        }
        else
        {
            Debug.Log("Chest added to Unlocking Queue.");
            DisplayMessageOnPopUp("Chest added to Unlocking Queue.");
            unlockingQueue.Add(PopUpChest);
            PopUpChest.chestController.addedToQueue = true;
        }
    }

    public void AddChestToSlot(int chestIndex)
    {
        //Add Chest
        int chestSlotAlreadyOccupied = 0;
        for (int i = 0; i < ChestSlots.Length; i++)
        {
            if (ChestSlots[i].IsEmpty())
            {
                ChestSlots[i].AddChestToController(chestSOL.chests[chestIndex], chestSprites[chestIndex]);
                DisplayMessageOnPopUp("Chest Added to Slot:" + ++i);
                i = ChestSlots.Length + 1;
            }
            else
                chestSlotAlreadyOccupied++;
        }
        if (chestSlotAlreadyOccupied == ChestSlots.Length)
        {
            //All chest slots are filled
            Debug.Log("Chest not added. All slots are occupied");
            DisplayMessageOnPopUp("Chest not added. All slots are occupied");
        }
    }


    public void UnlockNextChest(ChestView unlockedChestView)
    {
        unlockingQueue.Remove(unlockedChestView);
        if (unlockingQueue.Count > 0)
            unlockingQueue[0].chestController.StartTimer();
        else
            timerStarted = false;

    }

    public void DisplayMessageOnPopUp(string message)
    {
        PopUpManager.Instance.OnlyDisplay(message);
    }

    public void DisplayPopUp(ChestController callingChest, bool chestAddedToQueue, string message, int gemsToUnlock)
    {
        PopUpChest = callingChest.ChestView;
        PopUpManager.Instance.DisplayPopUp(chestAddedToQueue, message, gemsToUnlock);
    }


}