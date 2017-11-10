using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        //-1 if moving backwards. +1  if moving forwards.
        float mouseVertical = Input.GetAxis("Mouse Y");

        //rotate the object (maybe the main Cam) based on mouse movement
        transform.Rotate(-mouseVertical, mouseHorizontal, 0);
        //un-roll camera
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        //Cursor Lock & invisibility
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
