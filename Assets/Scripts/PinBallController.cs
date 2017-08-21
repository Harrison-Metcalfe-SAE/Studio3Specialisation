using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinBallController : MonoBehaviour {

    public float thrust;
    private Vector2 velocityOnBall;
    public float speed;
    public Rigidbody2D pinBallrb;
    public GameObject cannon;
    private float initializationTime;
    public float timeSinceInitialization;

    public int bounces;
    public int score;
    public int currScoreMultiplier;
    public float scoreMultiplierTimer;

	public GameObject scoreUI;
    public GameObject endText;
    public GameObject scoreText;

    //////////////////NOT MY VARIABLES///////////////////
    public Vector3 originalCameraPosition;

    float shakeAmt = 0;

    public Camera mainCamera;



    // Use this for initialization
    void Start () {
        pinBallrb = GetComponent<Rigidbody2D>();
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        mainCamera = FindObjectOfType<Camera>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        endText = GameObject.FindGameObjectWithTag("EndText");

        Vector2 direction = transform.position - cannon.transform.position;
        direction.Normalize();
        pinBallrb.AddForce(direction * thrust);

        initializationTime = Time.timeSinceLevelLoad;
    }
	
	// Update is called once per frame
	void Update () {
        velocityOnBall = GetComponent<Rigidbody2D>().velocity;
        speed = velocityOnBall.magnitude;
        ScoreIncrease();
        timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        scoreMultiplierTimer -= Time.deltaTime;
    }

    void ScoreIncrease()
    {
        score = bounces * 1000;
        // scoreText.GetComponent<Text>().text = "Score:" + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if(scoreMultiplierTimer <= 0)
            {
                bounces += 1;
                ContactPoint2D contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
                Vector2 pos = contact.point;
                Instantiate(scoreUI, pos, rot);
                //////////////////NOT MY CODE///////////////////
                shakeAmt = collision.relativeVelocity.magnitude * .0025f;
                InvokeRepeating("CameraShake", 0, .01f);
                Invoke("StopShaking", 0.3f);
            }
            if(scoreMultiplierTimer > 0)
            {
                bounces += (1 * currScoreMultiplier);
                ContactPoint2D contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
                Vector2 pos = contact.point;
                Instantiate(scoreUI, pos, rot);
                //////////////////NOT MY CODE///////////////////
                shakeAmt = collision.relativeVelocity.magnitude * .0025f;
                InvokeRepeating("CameraShake", 0, .01f);
                Invoke("StopShaking", 0.3f);
            }
        }
    }

    //////////////////NOT MY CODE///////////////////

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

}
