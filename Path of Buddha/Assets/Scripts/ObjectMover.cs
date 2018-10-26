using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {

    public float yVel;
    Vector3 vel;

    void Start () {
        vel = new Vector3(0, yVel, 0);
    }
	
	void Update () {
        transform.position -= vel * Time.deltaTime / 2;
    }
}
