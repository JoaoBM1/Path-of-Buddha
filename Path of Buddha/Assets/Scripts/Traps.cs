using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {

    public GameObject loseMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
