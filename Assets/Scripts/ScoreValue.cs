using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValue : MonoBehaviour {

	public float scoreDisplayTimer;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplayTimer -= Time.deltaTime;

		if (scoreDisplayTimer <= 0) {
			Destroy (this.gameObject);
		}
	}
}
