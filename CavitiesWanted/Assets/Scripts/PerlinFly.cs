using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinFly : MonoBehaviour {

	public float scale = 1f;
	public float heightScale = 1f;
    public float defaultHeight = 1f;

	float posY;

	void Update () {
		transform.position = new Vector3 (transform.position.x, defaultHeight + posY, transform.position.z);
		posY = heightScale * Mathf.PerlinNoise (Time.time + (transform.position.x * scale), Time.time + (transform.position.z * scale));
	}
}
