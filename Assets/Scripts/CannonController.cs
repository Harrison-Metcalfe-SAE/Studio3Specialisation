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
        if (Input.GetMouseButton(0) && !FindObjectOfType<EndLevel>().EndPanel.active)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            if (mousePos.x <= screenPoint.x)
            {
                CannonTiltLeft();
            }
            else
            {
                CannonTiltRight();
            }
        }
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
        if (canFire)
        {
            canFire = false;
            GameObject _pinBall = Instantiate(pinBall, barrelTip.transform.position, barrelTip.transform.rotation);
            GameObject.FindGameObjectWithTag("EndScreen").gameObject.GetComponent<EndLevel>().pinBall = _pinBall;
        }
    }

    void OnMouseDown()
    {
        CannonFire();
    }
}
