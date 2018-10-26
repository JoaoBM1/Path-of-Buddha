using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightIncreaser : MonoBehaviour {

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
            player.IncreaseWeight(20);
            Destroy(this.gameObject);
        }
    }
}
