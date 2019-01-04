using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    GameObject playerObject;

    public GameObject WinMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            WinMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
