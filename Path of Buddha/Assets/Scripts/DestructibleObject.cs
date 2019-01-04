using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour {
    
    public float destructibleObjectWeight;
    GameObject playerObject;
    Player player;

    void Start () {

        GetComponentInChildren<TextMesh>().text = "> " + destructibleObjectWeight.ToString();

        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (player.currentWeight > destructibleObjectWeight)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
