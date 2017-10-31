using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByMic : MonoBehaviour {
	Rigidbody rig_;
	micInput mic_;

	void Start () {
		rig_ = GetComponent<Rigidbody> ();
		mic_ = FindObjectOfType<micInput> ();
	}

	void Update () {
		rig_.MovePosition (transform.position + Vector3.up + new Vector3 (0, mic_.level_ * 10, 0));
		
	}
}
