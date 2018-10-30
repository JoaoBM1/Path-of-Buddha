using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float weightLossOverTime;
    private string axish = "Horizontal";
    private string axisv = "Vertical";
    public float initialWeight;
    public float currentWeight;
    private GUIStyle guiFont;
    //private float transcendenceDuration;

    void Start()
    {
        currentWeight = initialWeight;
        guiFont = new GUIStyle();
        guiFont.fontSize = 40;
        guiFont.normal.textColor = Color.white;
        //transcendenceDuration = 20;
    }

    void Update()
    {
        currentWeight -= weightLossOverTime;
        transform.localScale = new Vector3(currentWeight / 50, currentWeight / 50, currentWeight / 50);
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

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 100, 30), "Weight: " + (int)currentWeight, guiFont);
    }
}