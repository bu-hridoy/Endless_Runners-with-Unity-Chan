using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;

	private float speed = 5.0f;
	private float velocity = 0.0f;
	private float startTime;

	private float animationDuration = 3.0f;
	private bool isdead = false;


	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (isdead)
			return;

		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		
		moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
		moveVector.y = velocity * Time.deltaTime;
		moveVector.z = speed*Time.deltaTime;

		controller.Move (moveVector);
	}

	public void SetSpeed(float modif)
	{
		speed = 5.0f + modif;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + controller.radius)
			Death ();
	}

	private void Death()
	{
		isdead = true;
		GetComponent<Score> ().Ondeath ();
	}
}
