using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreValue : MonoBehaviour {

	public float scoreDisplayTimer;
    public GameObject pinBall;
    public int scoreToDisplay;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
        pinBall = GameObject.FindGameObjectWithTag("Ball");
        if (pinBall.GetComponent<PinBallController>().scoreMultiplierTimer > 0)
        {
            scoreToDisplay = 1000 * pinBall.GetComponent<PinBallController>().currScoreMultiplier;
        }
        else
        {
            scoreToDisplay = 1000;
        }
        GetComponent<TextMesh>().text = scoreToDisplay.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplayTimer -= Time.deltaTime;

		if (scoreDisplayTimer <= 0) {
			Destroy (this.gameObject);
		}
	}
}
