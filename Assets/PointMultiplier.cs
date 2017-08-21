using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMultiplier : MonoBehaviour {

    public GameObject pinBall;
    public float scoreMultiplier;
    public float multiplierTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pinBall = GameObject.FindGameObjectWithTag("Ball");
	}
}
