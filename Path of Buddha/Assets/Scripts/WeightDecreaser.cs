using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDecreaser : MonoBehaviour {

    GameObject playerObject;
    Player player;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.DecreaseWeight(10);
        }
    }
}
