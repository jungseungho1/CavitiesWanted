using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private Vector3 center;
    private Vector3 axis;
    public float orbitSpeed = 30.0F;    // degrees per second
    public float rotateSpeed = 20.0F;	// degrees per second

	// Use this for initialization
	void Start () {
        center = new Vector3(0, 0, 0);
        //axis = new Vector3(0.5F, 0.5F, 0.5F);
        axis = new Vector3 (0f,1f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (center, Vector3.up, Time.deltaTime * orbitSpeed);
		this.transform.Rotate (axis, Time.deltaTime * rotateSpeed);
	}
}
