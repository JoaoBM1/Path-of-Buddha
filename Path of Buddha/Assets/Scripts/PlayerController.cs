using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 11;
    private string axish = "Horizontal";

    void FixedUpdate()
    {
        float vh = Input.GetAxisRaw(axish);
        GetComponent<Rigidbody2D>().velocity = new Vector2(vh, 0) * speed;

        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(vh, 0) * speed;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(vh, 0) * speed;
            }
        }
    }
}