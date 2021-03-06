using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/NewChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    public string chestType;
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;
    public int timeToUnlockChest;
}

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/NewChestListScriptableObject")]
public class ChestScriptableObjectList : ScriptableObject
{
    public ChestScriptableObject[] chests;
}
