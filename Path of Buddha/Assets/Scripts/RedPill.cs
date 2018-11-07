using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPill : MonoBehaviour {

    GameObject playerObject;
    Player player;
    int decreaseAmount = 50;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            player.redPillCounter++;
            player.updateRedPillText();
            
        }
    }

    public void onItemUse()
    {
        if (player.redPillCounter > 0)
        {
            player.redPillCounter--;
            player.updateRedPillText();
            player.DecreaseWeight(decreaseAmount);
        }
    }
}
