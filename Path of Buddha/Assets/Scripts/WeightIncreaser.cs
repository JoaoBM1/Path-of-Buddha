using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightIncreaser : MonoBehaviour {

    GameObject playerObject;
    Player player;
    int increaseAmount = 20;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.IncreaseWeight(increaseAmount);
            Destroy(this.gameObject);
        }
    }
}
