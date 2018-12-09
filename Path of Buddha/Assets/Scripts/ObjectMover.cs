using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {

    private float yVel;
    Vector3 vel;

    void Start () {
        yVel = 9.5f;
        vel = new Vector3(0, yVel, 0);
    }
	
	void Update () {
        transform.position -= vel * Time.deltaTime / 2;
    }
}
