using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusWeightItem : MonoBehaviour {

    GameObject playerObject;
    Player player;
    int IncreaseAmount = 50;

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
            player.plusWeightCounter++;
            player.updatePlusWeightText();
        }
    }

    public void onItemUse()
    {
        if (player.plusWeightCounter > 0)
        {
            player.plusWeightCounter--;
            player.updatePlusWeightText();
            player.IncreaseWeight(IncreaseAmount);
        }
    }
}
