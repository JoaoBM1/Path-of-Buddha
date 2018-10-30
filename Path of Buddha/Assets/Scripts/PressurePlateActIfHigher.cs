using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActIfHigher : MonoBehaviour {

    //If the player's weight is lower than the pressure plate, nothing happens
    //If the player's weight is higher than the pressure plate, the trap is activated

    GameObject playerObject;
    Player player;
    Material material;
    public float pressurePlateWeight;

	void Start ()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        material = GetComponent<Renderer>().material;
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
}
