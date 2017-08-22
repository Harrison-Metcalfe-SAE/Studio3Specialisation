using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLineRenderer : MonoBehaviour {

    public float velocity;

    public LineRenderer lineRenderer;

    public float maxTime;

    public float timeResolution;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocityVector = transform.forward * velocity;

        lineRenderer.SetVertexCount((int)(maxTime / timeResolution));

        int index = 0;

        Vector2 currentPosition = transform.position;

        for (float t = 0.0f; t < maxTime; t+= timeResolution)
        {
            lineRenderer.SetPosition(index, currentPosition);
            currentPosition += velocityVector * timeResolution;
            index++;
        }
	}
}
