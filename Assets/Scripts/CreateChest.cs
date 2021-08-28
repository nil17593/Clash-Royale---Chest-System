using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateChest : MonoBehaviour
{
    [SerializeField] private Button buttonCreateChest;

    void Start()
    {
        buttonCreateChest.onClick.AddListener(CreateNewChest);
    }

    void CreateNewChest()
    {
        
    }
        
}
