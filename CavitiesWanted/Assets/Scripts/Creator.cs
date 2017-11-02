using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

	public GameObject create;
	private Vector3 random;


	void Update () {
		random = new Vector3 (Random.Range(-1F,1F), Random.Range(10F,20F), Random.Range(-1F,1F));


        if (Input.GetKeyDown(KeyCode.Space))
        //if (Input.GetMouseButtonDown (0)) 
        {
            Instantiate(create, random, Quaternion.identity);
    }

}
}
