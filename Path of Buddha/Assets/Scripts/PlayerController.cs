using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private string axish = "Horizontal";

    void FixedUpdate()
    {
        float vh = Input.GetAxisRaw(axish);
        GetComponent<Rigidbody2D>().velocity = new Vector2(vh, 0) * speed;
    }
}