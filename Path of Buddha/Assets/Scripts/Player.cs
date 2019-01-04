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

    public GameObject loseMenu;

    public int plusWeightCounter;
    public int minusWeightCounter;
    public int transcendenceCounter;

    public Text plusWeightText;
    public Text minusWeightText;
    public Text transcendenceText;
    public Text currentWeightText;


    GameObject plusWeightObject;
    PlusWeightItem plusWeight;

    GameObject minusWeightObject;
    MinusWeightItem minusWeight;

    GameObject transcendenceObject;
    Transcendence transcendence;

    void Start()
    {
        oldPosition = transform.position.x;
        currentWeight = initialWeight;
        updateMinusWeightText();
        updatePlusWeightText();
        updateTranscendenceText();
        plusWeightCounter = 0;
        minusWeightCounter = 0;
        transcendenceCounter = 0;
        weightDecreaserOvertime = 2f;
        weightLossWhileMovingFactor = 2.5f;

        //transcendenceDuration = 20;

        plusWeightObject = GameObject.Find("PlusWeight");
        plusWeight = plusWeightObject.GetComponent<PlusWeightItem>();

        minusWeightObject = GameObject.Find("MinusWeight");
        minusWeight = minusWeightObject.GetComponent<MinusWeightItem>();

        transcendenceObject = GameObject.Find("Transcendence Buff");
        transcendence = transcendenceObject.GetComponent<Transcendence>();
    }

    void Update()
    {
        if(checkIfPlayerIsMovingHorizontally())
        {
            currentWeight -= (weightDecreaserOvertime * weightLossWhileMovingFactor) * Time.deltaTime;
        } else {
            currentWeight -= weightDecreaserOvertime * Time.deltaTime;
        }

        oldPosition = transform.position.x;

        transform.localScale = new Vector3(currentWeight / 75, currentWeight / 75, currentWeight / 75);
        
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

        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            transcendence.onItemUse();
        }



        //Lose Conditions:

        if (GetComponent<Rigidbody2D>().position.y <= -10)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(currentWeight <= 0)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
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

    public void updateTranscendenceText()
    {
        transcendenceText.text = "x" + transcendenceCounter.ToString();
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
}