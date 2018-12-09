using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorActIfLower: MonoBehaviour {

    //If the player's weight is lower than the pressure plate, the trap is activated
    //If the player's weight is higher than the pressure plate, nothing happens

    GameObject playerObject;
    Player player;
    Material material;
    public int id;
    private GameObject[] offTrapWalls;
    private GameObject[] onTrapWalls;
    public float sensorWeight;

	void Start ()
    {
        GetComponentInChildren<TextMesh>().text = sensorWeight.ToString();

        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        material = GetComponent<Renderer>().material;

        offTrapWalls = GameObject.FindGameObjectsWithTag("Off" + id.ToString());
        onTrapWalls = GameObject.FindGameObjectsWithTag("On" + id.ToString());

        foreach (GameObject i in offTrapWalls)
        {
            i.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (player.currentWeight <= sensorWeight)
            {
                //Activate Trap

                foreach (GameObject i in offTrapWalls)
                {
                    i.SetActive(true);
                }

                foreach (GameObject i in onTrapWalls)
                {
                    i.SetActive(false);
                }
                //Change to Activated Sprite
                material.color = Color.black;
            }
        }
    }
}
