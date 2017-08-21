using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMultiplier : MonoBehaviour {

    public GameObject pinBall;
    public int scoreMultiplier;
    public float multiplierTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pinBall = GameObject.FindGameObjectWithTag("Ball");
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            pinBall.GetComponent<PinBallController>().currScoreMultiplier = scoreMultiplier;
            pinBall.GetComponent<PinBallController>().scoreMultiplierTimer = multiplierTime;
            Destroy(this.gameObject);
        }
    }
}
