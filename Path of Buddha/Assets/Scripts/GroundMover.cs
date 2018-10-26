using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour {

    Material material;
    Vector2 offset;

    public float yVel;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    
    void Start () {
        offset = new Vector2(0, yVel);
	}
	
	void Update () {
        material.mainTextureOffset += offset * Time.deltaTime / 2;
	}
}
