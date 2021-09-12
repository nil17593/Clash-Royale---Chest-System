using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoGenericSingleton<PlayerController>
{
    [SerializeField] PlayerScriptableObject playerSO;
    [SerializeField] TextMeshProUGUI NameText;
    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] TextMeshProUGUI GemsText;
    [SerializeField] string Name;
    [SerializeField] int Coins;
    [SerializeField] int Gems;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayerData(playerSO);
        ShowPlayerData();
    }

    private void SetPlayerData(PlayerScriptableObject playerSO)
    {
        Name = playerSO.playerName;
        gameObject.name = Name;
        Coins = playerSO.numberOfCoins;
        Gems = playerSO .numberOfGems;
    }

    private void ShowPlayerData()
    {
        NameText.text = Name;
        CoinsText.text = Coins.ToString();
        GemsText.text = Gems.ToString();
    }

    public void AddToPlayer(int coinsToAdd, int GemsToAdd)
    {
        Coins += coinsToAdd;
        Gems += GemsToAdd;
        ShowPlayerData();
    }

    public bool RemoveFromPlayer(int GemsToSub)
    {
        bool sufficientGems = true;
        if (Gems >= GemsToSub)
            Gems -= GemsToSub;
        else
            sufficientGems = false;
        ShowPlayerData();
        return sufficientGems;
    }
}
