using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateChest : MonoBehaviour
{

    public Button addChestButton;
    public Image[] image;
    public bool[] status;
    public Button[] chestButtons;
    //public Button chestButton1;
    //public Button chestButton2;
    //public Button chestButton3;
    //public Button chestButton4;
    public GameObject[] chestUI;
    public Sprite openBox;
    public Canvas canvas;
    //private Button newButton;


    private void Start()
    {
        addChestButton.onClick.AddListener(addChest);
    }

    void addChest()
    {
        for (int i = 0; i < 4; i++)
        {
            if (status[i] == false)
            {
                Vector3 position = image[i].gameObject.transform.position;
                int k = Random.Range(0, 3);
                Button button = GameObject.Instantiate(chestButtons[k]).GetComponent<Button>();
                button.name = "Button" + i;
                PlayerPrefs.SetString(button.name, chestButtons[k].name);
                button.transform.position = position;
                button.gameObject.SetActive(true);
                button.gameObject.transform.SetParent(image[i].gameObject.transform);
                status[i] = true;
                button.onClick.AddListener(openChest);

                return;
            }
        }
    }

    void openChest()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject button = GameObject.Find(name);
        //button.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        button.gameObject.GetComponent<Button>().image.sprite = openBox;

        string buttonType = PlayerPrefs.GetString(button.name);

        if (buttonType == "Button0")
        {
            chestUI[0].gameObject.SetActive(true);
        }
        else if (buttonType == "Button1")
        {
            chestUI[1].gameObject.SetActive(true);
        }
        else if (buttonType == "Button2")
        {
            chestUI[2].gameObject.SetActive(true);
        }
        else if (buttonType == "Button3")
        {
            chestUI[3].gameObject.SetActive(true);
        }
    }
    ////public ChestScriptableObjectList chestList;
    ////public List<ChestScriptableObjectList> chests;
    //[SerializeField] private Button buttonCreateChest;
    //public Image[] image;
    ////[SerializeField] private Queue <ChestScriptableObject> chests;
    ////public GameObject chest;
    //public List<ChestScriptableObject> chestPrefabList;
    //private ChestGroup chestGroup;
    //public Canvas canvas;
    //public GameObject chestPrefab;

    //void Start()
    //{
    //    buttonCreateChest = GetComponent<Button>();
    //    buttonCreateChest.onClick.AddListener(CreateNewChest);
    //}

    //void CreateNewChest()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        // target= chestGroup.GetChestGroupTransform();
    //        //this.gameObject.transform.SetParent(canvas.transform);
    //        int rand = Random.Range(0, 4);
    //        Instantiate(chestPrefab, transform.position,Quaternion.identity);
    //        //Instantiate(Random.Range(0,chestList.chest.Length,this.transform.position,Quaternion.identity);

    //        //gameObject.SetActive(true);
    //    }
    //}

}
