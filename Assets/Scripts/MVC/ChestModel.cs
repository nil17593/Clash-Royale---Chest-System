using System.Collections;
using UnityEngine;


public class ChestModel
{
    public string Type { get; private set; }
    public int Coins { get; private set; }
    public int Gems { get; private set; }
    public int TimeToUnlock { get; private set; }


    public ChestModel(ChestScriptableObject chestScriptableObject)
    {
        Type = chestScriptableObject.chestType;
        Coins = Random.Range(chestScriptableObject.minCoins, chestScriptableObject.maxCoins);
        Gems = Random.Range(chestScriptableObject.minGems, chestScriptableObject.maxGems);
        TimeToUnlock = chestScriptableObject.timeToUnlockChest;
    }

    public void SetType(string type) 
    { 
        Type = type;
    }

    public void SetCoins(int coins) 
    { 
        Coins = coins; 
    }

    public void SetGems(int gems) 
    {
        Gems = gems;
    }

    public void SetTimeToUnlock(int time) 
    {
        TimeToUnlock = time; 
    }
}  