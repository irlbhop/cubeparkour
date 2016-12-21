using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour
{
	public int jPow = 0;
	public int speed;

	private Rigidbody rb;
	private ConstantForce cf;
	private bool isGrounded = true;

	private Vector3 movement;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		cf = GetComponent<ConstantForce>();

	}

	void FixedUpdate ()
	{
		movement = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
		rb.velocity = movement;

		if (isGrounded && Input.GetKey(KeyCode.Space)) {

			rb.AddForce (Vector3.up * 10, ForceMode.Impulse);
		}
			

		//Debug.Log (Time.time);
		//rb.AddForce (transform.up * 10);
		//make a boolean for whether it's in the air or not
		//if it's on the ground, and, if SPACE is pressed, add rb.velocity.y
	}

	void OnCollisionStay()
	{
		isGrounded = true;

	}

	void OnCollisionExit()
	{
		
		isGrounded = false;
	}
}