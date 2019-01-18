using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActIfHigher : MonoBehaviour {

    //If the player's weight is lower than the pressure plate, nothing happens
    //If the player's weight is higher than the pressure plate, the trap is activated

    GameObject playerObject;
    Player player;
    public int id;
    private GameObject[] offTrapWalls;
    private GameObject[] onTrapWalls;
    public float pressurePlateWeight;
    public Sprite plate1;


    private void Start ()
    {
        GetComponentInChildren<TextMesh>().text = "< " + pressurePlateWeight.ToString();

        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();

        offTrapWalls = GameObject.FindGameObjectsWithTag("Off" + id.ToString());
        onTrapWalls = GameObject.FindGameObjectsWithTag("On" + id.ToString());

        

        foreach (GameObject i in onTrapWalls)
        {
            i.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (player.currentWeight > pressurePlateWeight)
            {                
                foreach (GameObject i in offTrapWalls)
                {
                    i.SetActive(false);
                }

                foreach (GameObject i in onTrapWalls)
                {
                    i.SetActive(true);
                }
            }
        }
    }
}
