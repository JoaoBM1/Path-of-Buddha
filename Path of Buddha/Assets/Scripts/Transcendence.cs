using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcendence : MonoBehaviour {

    GameObject playerObject;
    Player player;
    float transcendenceDuration;


    void Start()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        transcendenceDuration = 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
            player.transcendenceCounter++;
            player.updateTranscendenceText();
        }
    }

    public void onItemUse()
    {
        if(player.transcendenceCounter > 0)
        {
            player.transcendenceCounter--;
            player.updateTranscendenceText();
            TranscendenceEffects();
        }
    }

    void TranscendenceEffects()
    {
        float timePassed = 0;
        while (timePassed < transcendenceDuration)
        {
            //Transcendence Code Here
            timePassed += Time.deltaTime;
        }
    }
}