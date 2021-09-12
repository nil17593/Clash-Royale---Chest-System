using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerChestScriptableObject")]
public class PlayerScriptableObject :ScriptableObject
{

    public string playerName;
    public int numberOfCoins;
    public int numberOfGems;
}
