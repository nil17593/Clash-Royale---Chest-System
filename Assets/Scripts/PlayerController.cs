using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public PlayerScriptableObject playerScriptableObject;

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI coinNumbersText;
    public TextMeshProUGUI gemNumbersText;

    [SerializeField] private string playerName;
    [SerializeField] private int coinsNumbers;
    [SerializeField] private int gemsNumbers;


    private void Start()
    {
        SetPlayerdata();
        ShowPlayerData();
    }
    private void SetPlayerdata()
    {
        playerName = playerScriptableObject.playerName;
        coinsNumbers = playerScriptableObject.numberOfCoins;
        gemsNumbers = playerScriptableObject.numberOfGems;
    }

    private void ShowPlayerData()
    {
        playerNameText.text ="Player:" +playerName;
        coinNumbersText.text = coinsNumbers.ToString();
        gemNumbersText.text = gemsNumbers.ToString();
    }
}
