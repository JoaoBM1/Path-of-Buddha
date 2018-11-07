using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPill : MonoBehaviour {

    GameObject playerObject;
    Player player;
    int IncreaseAmount = 50;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("hi");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            player.greenPillCounter++;
            player.updateGreenPillText();
        }
    }

    public void onItemUse()
    {
        if (player.greenPillCounter > 0)
        {
            player.greenPillCounter--;
            player.updateGreenPillText();
            player.IncreaseWeight(IncreaseAmount);
        }
    }
}
