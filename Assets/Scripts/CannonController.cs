using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public float rotationSpeed;

    public bool canFire;

    public Rigidbody2D cannonBarrel;
    public GameObject barrelTip;
    public GameObject pinBall;

    // Use this for initialization
    void Start () {
        cannonBarrel = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        CannonFire();
    }

    public void CannonTiltLeft()
    {
		cannonBarrel.MoveRotation(cannonBarrel.rotation + rotationSpeed * Time.fixedDeltaTime);
    }


	public void CannonTiltRight()
	{
		cannonBarrel.MoveRotation(cannonBarrel.rotation - rotationSpeed * Time.fixedDeltaTime);
	}

    void CannonFire()
    {
        if (Input.GetKeyDown("up") && canFire)
        {
            canFire = false;
            Instantiate(pinBall, barrelTip.transform.position, barrelTip.transform.rotation);
        }
    }
}
