using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak : MonoBehaviour {

	public int speed = 5;
	public float jumpspeed = 8f;
	private Rigidbody2D rigidBody;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool isTouchingGround;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,groundLayer);

		if(Input.GetKey(KeyCode.D)){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.W) && isTouchingGround){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpspeed);
		}
		{
			
		}
	}
}
