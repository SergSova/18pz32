using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class PersonalAreaButtons : MonoBehaviour
{

    public GameObject exitForm;
    public GameObject statisticsForm;
    public GameObject mapsForm;
    public GameObject shopForm;

    public object currentTank;
    GameObject selectedTank;

    public GameObject tank1prefab;
    public GameObject tank2prefab;
    public GameObject tank3prefab;
    public GameObject tank4prefab;

    public Vector3 positionStandart;
    public Vector3 positionForT55;

    public Vector3 rotationTank1;
    public Vector3 rotationTank2;
    public Vector3 rotationTank3;
    public Vector3 rotationTank4;

    public GameObject notEnoughMoneyText1;
    public GameObject notEnoughMoneyText2;
    public GameObject notEnoughMoneyText3;

    public Text userName;
    public Text experienceValue;
    public Text moneyValue;

    private int tankIdent;

    private string userNameValue;

    public Text nameTankValue;
    public Text speedTankValue;
    public Text rotationTankValue;
    public Text healthTankValue;
    public Text armorTankValue;

    public GameObject buttonTank1;
    public GameObject buttonTank2;
    public GameObject buttonTank3;
    public GameObject buttonTank4;

    public Sprite buttonTank1UnlockSprite;
    public Sprite buttonTank2UnlockSprite;
    public Sprite buttonTank3UnlockSprite;
    public Sprite buttonTank4UnlockSprite;

    public Sprite buttonTank2LockSprite;
    public Sprite buttonTank3LockSprite;
    public Sprite buttonTank4LockSprite;

    private int moneyAmount;
    private int experienceAmount;

    private int tank2_PanzerIV_Price;
    private int tank3_T34_Price;
    private int tank4_T55_Price;

    //Statistics
    private int valueGamesWin;
    private int valueGamesOver;

    public Text statUserName;
    public Text statGamesWin;
    public Text statGamesOver;
    public Text statMoney;
    public Text statExperience;

    public static bool isServerEnabled;
    private static int levelnumb;

    public void Start()
    {
        positionStandart = GameObject.FindWithTag("SpawnPoint").transform.position;

        TankInstantiate(tank1prefab, positionStandart, rotationTank1);

        // UserName Get From DataBase
        userNameValue = "SKuh";
        userName.text = userNameValue;

        // Money Get From DataBase   
        moneyAmount = 200000;
        moneyValue.text = moneyAmount.ToString();

        // Experience Get From DataBase
        experienceAmount = 30000;
        experienceValue.text = experienceAmount.ToString();

        // Tanks prices
        tank2_PanzerIV_Price = 20000;
        tank3_T34_Price = 50000;
        tank4_T55_Price = 100000;

        // Tank technical characteristics Get From DataBase
        nameTankValue.text = "Panzer II";
        speedTankValue.text = "60";
        rotationTankValue.text = "20";
        healthTankValue.text = "100";
        armorTankValue.text = "100";

    }

    public void Exit()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        exitForm.SetActive(!exitForm.activeSelf);
    }

    public void Statistics()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        statisticsForm.SetActive(!statisticsForm.activeSelf);

        // Get From DataBase
        valueGamesWin = 100;
        valueGamesOver = 100;

        //
        statUserName.text = userNameValue;
        statGamesWin.text = valueGamesWin.ToString();
        statGamesOver.text = valueGamesOver.ToString();
        statMoney.text = moneyAmount.ToString();
        statExperience.text = experienceAmount.ToString();

    }

    public void Battle()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        LoadLevel.playerPref = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(w => w.name == selectedTank.name).FirstOrDefault() as GameObject;
        //if (!Servers.isEnable)
        //{
        //    levelnumb = Random.Range(2, 5);
        //    Application.LoadLevel(2);
        //    isServerEnabled = true;
        //}
        //else
        //{
            Application.LoadLevel(2);
        //}
    }

    public void exitForm_StartMenuButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        Application.LoadLevel(0);
    }

    public void exitForm_ExitGameButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        Application.Quit();
    }


    public void statisticForm_CancelButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        statisticsForm.SetActive(!statisticsForm.activeSelf);
    }

    public void mapsForm_BattleButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        LoadLevel.playerPref = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(w => w.name == selectedTank.name).FirstOrDefault() as GameObject;
        Application.LoadLevel(Random.Range(2, 5));


    }

    public void mapsForm_CancelButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        mapsForm.SetActive(!mapsForm.activeSelf);
    }

    void TankInstantiate(GameObject TankPrefab, Vector3 position, Vector3 rotation)
    {
        if (currentTank != null)
        {
            Destroy((currentTank as Transform).gameObject);
            currentTank = Instantiate(TankPrefab, position, Quaternion.Euler(rotation));
        }
        else
        {
            currentTank = Instantiate(TankPrefab, position, Quaternion.Euler(rotation));
        }
        selectedTank = TankPrefab;
    }

    public void tank1stButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        TankInstantiate(tank1prefab, positionStandart, rotationTank1);

        // Tank technical characteristics Get From DataBase
        nameTankValue.text = "Panzer II";
        speedTankValue.text = "60";
        rotationTankValue.text = "20";
        healthTankValue.text = "100";
        armorTankValue.text = "100";
    }

    public void tank2ndButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        TankInstantiate(tank2prefab, positionStandart, rotationTank2);

        // Tank technical characteristics Get From DataBase
        nameTankValue.text = "Panzer IV";
        speedTankValue.text = "80";
        rotationTankValue.text = "30";
        healthTankValue.text = "100";
        armorTankValue.text = "100";
    }


    public void tank3rdButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        TankInstantiate(tank3prefab, positionStandart, rotationTank3);

        // Tank technical characteristics Get From DataBase
        nameTankValue.text = "T-34";
        speedTankValue.text = "100";
        rotationTankValue.text = "40";
        healthTankValue.text = "100";
        armorTankValue.text = "100";
    }

    public void tank4thButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        TankInstantiate(tank4prefab, positionForT55, rotationTank4);

        // Tank technical characteristics Get From DataBase
        nameTankValue.text = "T-55";
        speedTankValue.text = "120";
        rotationTankValue.text = "50";
        healthTankValue.text = "100";
        armorTankValue.text = "100";
    }

    public void Shop()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();
        shopForm.SetActive(!shopForm.activeSelf);
        if (notEnoughMoneyText1.activeSelf == true)
        {
            notEnoughMoneyText1.SetActive(false);
        }

        if (notEnoughMoneyText2.activeSelf == true)
        {
            notEnoughMoneyText2.SetActive(false);
        }

        if (notEnoughMoneyText3.activeSelf == true)
        {
            notEnoughMoneyText3.SetActive(false);
        }
    }

    public void shopForm_PanzerIVBuyButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();

        if (moneyAmount >= tank2_PanzerIV_Price)
        {
            moneyAmount = moneyAmount - tank2_PanzerIV_Price;
            moneyValue.text = moneyAmount.ToString();
            buttonTank2.GetComponent<Image>().overrideSprite = buttonTank2UnlockSprite;
        }
        else
        {
            notEnoughMoneyText1.SetActive(true);
        }
    }

    public void shopForm_T34BuyButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();

        if (moneyAmount >= tank3_T34_Price)
        {
            moneyAmount = moneyAmount - tank3_T34_Price;
            moneyValue.text = moneyAmount.ToString();
            buttonTank3.GetComponent<Image>().overrideSprite = buttonTank3UnlockSprite;
        }
        else
        {
            notEnoughMoneyText2.SetActive(true);
        }
    }

    public void shopForm_T55BuyButtonClick()
    {
        GameObject.FindWithTag("SoundButton2").GetComponent<AudioSource>().Play();

        if (moneyAmount >= tank4_T55_Price)
        {
            moneyAmount = moneyAmount - tank4_T55_Price;
            moneyValue.text = moneyAmount.ToString();
            buttonTank4.GetComponent<Image>().overrideSprite = buttonTank4UnlockSprite;
        }
        else
        {
            notEnoughMoneyText3.SetActive(true);
        }
    }

}
