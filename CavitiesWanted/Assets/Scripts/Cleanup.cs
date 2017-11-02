using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour {

	void FixedUpdate() {
		if (this.transform.position.y < -5) {
			Destroy (this.gameObject);
		}
	}
}
