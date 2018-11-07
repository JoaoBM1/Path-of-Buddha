using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private string axish = "Horizontal";
    private string axisv = "Vertical";

    void FixedUpdate()
    {
        float vh = Input.GetAxisRaw(axish);
        float vv = Input.GetAxisRaw(axisv);
        GetComponent<Rigidbody2D>().velocity = new Vector2(vh, vv) * speed;
    }
}