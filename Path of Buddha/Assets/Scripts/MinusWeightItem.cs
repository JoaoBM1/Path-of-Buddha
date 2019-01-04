using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusWeightItem : MonoBehaviour {

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
            player.minusWeightCounter++;
            player.updateMinusWeightText();
            
        }
    }

    public void onItemUse()
    {
        if (player.minusWeightCounter > 0)
        {
            player.minusWeightCounter--;
            player.updateMinusWeightText();
            player.DecreaseWeight(decreaseAmount);
        }
    }
}
