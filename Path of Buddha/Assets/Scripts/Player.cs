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
    private GUIStyle guiFont;
    public int redPillCounter;
    public int greenPillCounter;

    public Text redPillText;
    public Text greenPillText;
    //private float transcendenceDuration;

    GameObject redPillObject;
    RedPill redPill;

    GameObject greenPillObject;
    GreenPill greenPill;

    void Start()
    {
        currentWeight = initialWeight;
        guiFont = new GUIStyle();
        guiFont.fontSize = 40;
        guiFont.normal.textColor = Color.white;
        redPillCounter = 0;
        greenPillCounter = 0;

        updateRedPillText();
        updateGreenPillText();
        //transcendenceDuration = 20;

        redPillObject = GameObject.Find("RedPill");
        redPill = redPillObject.GetComponent<RedPill>();

        greenPillObject = GameObject.Find("GreenPill");
        greenPill = greenPillObject.GetComponent<GreenPill>();
    }

    void Update()
    {
        currentWeight -= Time.deltaTime;
        transform.localScale = new Vector3(currentWeight / 50, currentWeight / 50, currentWeight / 50);

        //Key Input Detection for Pills:

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            redPill.onItemUse();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            greenPill.onItemUse();
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

    public void updateRedPillText()
    {
        redPillText.text = "x" + redPillCounter.ToString();
    }

    public void updateGreenPillText()
    {
        greenPillText.text = "x" + greenPillCounter.ToString();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 100, 30), "Weight: " + (int)currentWeight, guiFont);
    }
}