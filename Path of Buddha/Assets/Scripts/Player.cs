using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float initialWeight;
    public float currentWeight;
    private float weightLossWhileMovingFactor;
    private float oldPosition;
    private float weightDecreaserOvertime;

    private float dataPoint1, dataPoint2, dataPoint3, dataPoint4, dataPoint5;
    
    public float totalTime;

    public GameObject loseMenu;

    public int plusWeightCounter;
    public int minusWeightCounter;

    public Text plusWeightText;
    public Text minusWeightText;
    public Text currentWeightText;

    GameObject plusWeightObject;
    PlusWeightItem plusWeight;

    GameObject minusWeightObject;
    MinusWeightItem minusWeight;

    public GameObject defaultPrefab1, defaultPrefab2, defaultPrefab3, mcdonaldsPrefab1, mcdonaldsPrefab2, mcdonaldsPrefab3, 
                      pizzaPrefab1, pizzaPrefab2, pizzaPrefab3, sushiPrefab1, sushiPrefab2, sushiPrefab3;
    private GameObject[] oldGameObjects1, oldGameObjects2, oldGameObjects3;

    public void Start()
    {
        oldGameObjects1 = GameObject.FindGameObjectsWithTag("Food 1");
        oldGameObjects2 = GameObject.FindGameObjectsWithTag("Food 2");
        oldGameObjects3 = GameObject.FindGameObjectsWithTag("Food 3");

        oldPosition = transform.position.x;
        currentWeight = initialWeight;
        updateMinusWeightText();
        updatePlusWeightText();
        plusWeightCounter = 0;
        minusWeightCounter = 0;
        weightDecreaserOvertime = 2f;
        weightLossWhileMovingFactor = 2.5f;

        plusWeightObject = GameObject.Find("PlusWeight");
        plusWeight = plusWeightObject.GetComponent<PlusWeightItem>();

        minusWeightObject = GameObject.Find("MinusWeight");
        minusWeight = minusWeightObject.GetComponent<MinusWeightItem>();

        checkTheme();

        dataPoint1 = 0;
        dataPoint2 = 0;
        dataPoint3 = 0;
        dataPoint4 = 0;
        dataPoint5 = 0;

        Invoke("assignDataPoint1", 5);
        Invoke("assignDataPoint2", 15);
        Invoke("assignDataPoint3", 25);
        Invoke("assignDataPoint4", 35);
        Invoke("assignDataPoint5", 45);
    }

    public void Update()
    {
        if(checkIfPlayerIsMovingHorizontally())
        {
            currentWeight -= (weightDecreaserOvertime * weightLossWhileMovingFactor) * Time.deltaTime;
        } else {
            currentWeight -= weightDecreaserOvertime * Time.deltaTime;
        }

        oldPosition = transform.position.x;

        transform.localScale = new Vector3(currentWeight / 125, currentWeight / 125, currentWeight / 125);
        
        updateCurrentWeightText();

        //Key Input Detection for Pills:

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            minusWeight.onItemUse();
        }

        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            plusWeight.onItemUse();
        }

        //Lose Conditions;

        if (GetComponent<Rigidbody2D>().position.y <= -15 || currentWeight <= 0)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void checkTheme()
    {
        if (PlayerPrefs.GetInt("activeTheme") == 0)
        {
            replaceTheme(oldGameObjects1, defaultPrefab1);
            replaceTheme(oldGameObjects2, defaultPrefab2);
            replaceTheme(oldGameObjects3, defaultPrefab3);

        }
        else if (PlayerPrefs.GetInt("activeTheme") == 1)
        {
            replaceTheme(oldGameObjects1, mcdonaldsPrefab1);
            replaceTheme(oldGameObjects2, mcdonaldsPrefab2);
            replaceTheme(oldGameObjects3, mcdonaldsPrefab3);

        }
        else if (PlayerPrefs.GetInt("activeTheme") == 2)
        {
            replaceTheme(oldGameObjects1, pizzaPrefab1);
            replaceTheme(oldGameObjects2, pizzaPrefab2);
            replaceTheme(oldGameObjects3, pizzaPrefab3);

        }
        else if (PlayerPrefs.GetInt("activeTheme") == 3)
        {
            replaceTheme(oldGameObjects1, sushiPrefab1);
            replaceTheme(oldGameObjects2, sushiPrefab2);
            replaceTheme(oldGameObjects3, sushiPrefab3);
        }
    }

    public void replaceTheme(GameObject[] array, GameObject prefab)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Instantiate(prefab, array[i].transform.position, Quaternion.identity);
            Destroy(array[i]);
        }
    }

    public void assignDataPoint1()
    {
        dataPoint1 = currentWeight;
    }

    public void assignDataPoint2()
    {
        dataPoint2 = currentWeight;
    }

    public void assignDataPoint3()
    {
        dataPoint3 = currentWeight;
    }

    public void assignDataPoint4()
    {
        dataPoint4 = currentWeight;
    }

    public void assignDataPoint5()
    {
        dataPoint5 = currentWeight;
    }

    public void prepareDeathSaveData()
    {
        totalTime = Time.timeSinceLevelLoad;

        DatabaseManager.totalDeaths = 1;
        DatabaseManager.totalPlays = 1;

        DatabaseManager.totalWeight = (int) currentWeight;
        DatabaseManager.totalTime = (int) totalTime;

        CallSaveData();

        totalTime = 0;
        DatabaseManager.totalDeaths = 0;
        DatabaseManager.totalPlays = 0;
    }

    public void prepareWinSaveData()
    {
        totalTime = Time.timeSinceLevelLoad;
        
        DatabaseManager.totalPlays = 1;

        DatabaseManager.totalWeight = (int)currentWeight;
        DatabaseManager.totalTime = (int)totalTime;

        CallSaveData();

        totalTime = 0;
        DatabaseManager.totalPlays = 0;
    }

    public void CallSaveData()
    {
        if (DatabaseManager.username != null)
        {
            StartCoroutine(SavePlayerData(PrintText));
            selectRightTheme();
        }
    }

    private delegate void TextDelegate(string text);

    IEnumerator SavePlayerData(TextDelegate output)
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/savedata.php?name=" + DatabaseManager.username +
                            "&totalDeaths=" + DatabaseManager.totalDeaths + "&totalWeight=" + DatabaseManager.totalWeight +
                            "&totalTime=" + DatabaseManager.totalTime + "&totalPlays=" + DatabaseManager.totalPlays + "&activeTheme=" + PlayerPrefs.GetInt("activeTheme") + 
                            "&dataPoint1=" + dataPoint1 + "&dataPoint2=" + dataPoint2 + "&dataPoint3=" + dataPoint3 + "&dataPoint4=" + dataPoint4 + "&dataPoint5=" + dataPoint5);
        yield return www;

        if(www.text.Equals("0"))
        {
            Debug.Log("Data successfully submitted");
        }
    }

    private void PrintText(string text)
    {
        Debug.Log(text);
    }

    public void selectRightTheme()
    {
        switch (DatabaseManager.activeTheme)
        {
            case 0: StartCoroutine(UpdateThemeDefault(PrintText));
                    break;
            case 1: StartCoroutine(UpdateThemeMcDonalds(PrintText));
                    break;
            case 2: StartCoroutine(UpdateThemePizza(PrintText));
                    break;
            case 3: StartCoroutine(UpdateThemeSushi(PrintText));
                    break;
        }
    }

    IEnumerator UpdateThemeDefault(TextDelegate output)
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/saveDataDefault.php?name=" + DatabaseManager.username +
                            "&totalFoodItem1=" + DatabaseManager.totalFoodItem1 + "&totalFoodItem2=" + DatabaseManager.totalFoodItem2 +
                            "&totalFoodItem3=" + DatabaseManager.totalFoodItem3);
        yield return www;

        DatabaseManager.totalFoodItem1 = 0;
        DatabaseManager.totalFoodItem2 = 0;
        DatabaseManager.totalFoodItem3 = 0;
    }

    IEnumerator UpdateThemeMcDonalds(TextDelegate output)
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/saveDataMcDonalds.php?name=" + DatabaseManager.username +
                            "&totalFoodItem4=" + DatabaseManager.totalFoodItem4 + "&totalFoodItem5=" + DatabaseManager.totalFoodItem5 +
                            "&totalFoodItem6=" + DatabaseManager.totalFoodItem6);
        yield return www;

        DatabaseManager.totalFoodItem4 = 0;
        DatabaseManager.totalFoodItem5 = 0;
        DatabaseManager.totalFoodItem6 = 0;
    }

    IEnumerator UpdateThemePizza(TextDelegate output)
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/saveDataPizza.php?name=" + DatabaseManager.username +
                            "&totalFoodItem7=" + DatabaseManager.totalFoodItem7 + "&totalFoodItem8=" + DatabaseManager.totalFoodItem8 +
                            "&totalFoodItem9=" + DatabaseManager.totalFoodItem9);
        yield return www;

        DatabaseManager.totalFoodItem7 = 0;
        DatabaseManager.totalFoodItem8 = 0;
        DatabaseManager.totalFoodItem9 = 0;
    }

    IEnumerator UpdateThemeSushi(TextDelegate output)
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/saveDataSushi.php?name=" + DatabaseManager.username +
                            "&totalFoodItem10=" + DatabaseManager.totalFoodItem10 + "&totalFoodItem11=" + DatabaseManager.totalFoodItem11 +
                            "&totalFoodItem12=" + DatabaseManager.totalFoodItem12);
        yield return www;

        DatabaseManager.totalFoodItem10 = 0;
        DatabaseManager.totalFoodItem11 = 0;
        DatabaseManager.totalFoodItem12 = 0;
    }

    public void DecreaseWeight(int ammount)
    {
        currentWeight -= ammount;
    }
    public void IncreaseWeight(int ammount)
    {
        currentWeight += ammount;
    }

    public void updateMinusWeightText()
    {
        minusWeightText.text = "x" + minusWeightCounter.ToString();
    }

    public void updatePlusWeightText()
    {
        plusWeightText.text = "x" + plusWeightCounter.ToString();
    }

    private void updateCurrentWeightText()
    {
        currentWeightText.text = ((int) currentWeight).ToString();
    }

    private bool checkIfPlayerIsMovingHorizontally()
    {
        if (oldPosition < transform.position.x || oldPosition > transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall On Left" || collision.gameObject.name == "Wall On Right" ||
            collision.gameObject.name == "Spikes On Center" || collision.gameObject.name == "Fire On")
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}