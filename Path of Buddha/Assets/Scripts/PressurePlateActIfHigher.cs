using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActIfHigher : MonoBehaviour {

    //If the player's weight is lower than the pressure plate, nothing happens
    //If the player's weight is higher than the pressure plate, the trap is activated

    GameObject playerObject;
    Player player;
    Material material;
    private GUIStyle guiFont;
    public float pressurePlateWeight;
    Rigidbody2D rb2d;

	void Start ()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        material = GetComponent<Renderer>().material;
        rb2d = GetComponent<Rigidbody2D>();

        guiFont = new GUIStyle();
        guiFont.fontSize = 10;
        guiFont.normal.textColor = Color.white;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(player.currentWeight >= pressurePlateWeight)
            {
                //Activate Trap
                //Change to Activated Sprite
                material.color = Color.black;
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(rb2d.position.x + 50, rb2d.position.y, 100, 30), pressurePlateWeight.ToString(), guiFont);
    }
}
