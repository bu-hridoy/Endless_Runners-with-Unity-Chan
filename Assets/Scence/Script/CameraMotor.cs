using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 start;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animationDuration = 3.0f;
	private Vector3 animationoffset = new Vector3 (0, 5, 5);


	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		start = transform.position - lookAt.position;

	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + start;
		moveVector.x = 0;
		moveVector.y = Mathf.Clamp (moveVector.y, 3, 5);

		if (transition > 1.0f) 
		{
			transform.position = moveVector;
		} 
		else {
			transform.position = Vector3.Lerp (moveVector + animationoffset, moveVector, transition);
			transition += Time.deltaTime * 1 / animationDuration; 
			transform.LookAt (lookAt.position + Vector3.up);
		}
		//transform.position = lookAt.position + start;

	}
}
