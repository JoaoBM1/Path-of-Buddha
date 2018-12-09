using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    private string axish = "Horizontal";
    private string axisv = "Vertical";
    public float initialWeight;
    public float currentWeight;
    private float time;
    private GUIStyle guiFont;


    public int plusWeightCounter;
    public int minusWeightCounter;
    public int transcendenceCounter;

    public Text plusWeightText;
    public Text minusWeightText;
    public Text transcendenceText;


    GameObject plusWeightObject;
    PlusWeightItem plusWeight;

    GameObject minusWeightObject;
    MinusWeightItem minusWeight;

    GameObject transcendenceObject;
    Transcendence transcendence;

    void Start()
    {
        currentWeight = initialWeight;
        guiFont = new GUIStyle();
        guiFont.fontSize = 40;
        guiFont.normal.textColor = Color.white;
        plusWeightCounter = 0;
        minusWeightCounter = 0;
        transcendenceCounter = 0;
        updateMinusWeightText();
        updatePlusWeightText();
        updateTranscendenceText();
        time = Time.deltaTime;

        //transcendenceDuration = 20;

        plusWeightObject = GameObject.Find("PlusWeight");
        plusWeight = plusWeightObject.GetComponent<PlusWeightItem>();

        minusWeightObject = GameObject.Find("MinusWeight");
        minusWeight = minusWeightObject.GetComponent<MinusWeightItem>();

        transcendenceObject = GameObject.Find("Transcendence");
        transcendence = transcendenceObject.GetComponent<Transcendence>();
    }

    void Update()
    {
        currentWeight -= time;
        transform.localScale = new Vector3(currentWeight / 50, currentWeight / 50, currentWeight / 50);

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
            SceneManager.LoadScene("Defeat Scene");
        }

        if(currentWeight <= 0)
        {
            SceneManager.LoadScene("Defeat Scene");
        }
    }

    void FixedUpdate()
    {
        float vh = Input.GetAxisRaw(axish);
        float vv = Input.GetAxisRaw(axisv);
        GetComponent<Rigidbody2D>().velocity = new Vector2(vh, vv) * speed;
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

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 100, 30), "Weight: " + (int)currentWeight, guiFont);
    }
}