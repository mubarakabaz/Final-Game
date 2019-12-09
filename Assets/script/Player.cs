using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	private Rigidbody2D rb;
	private Collider2D col;
	private Animator anim;

	private enum State {Idle, Run, Jump, Fall};
	private State state = State.Idle;

	

	[SerializeField] private int score = 0;
	[SerializeField] private float speed = 7;
	[SerializeField] private float jumpspeed = 8f;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Text scoreText;
	[SerializeField] private AudioSource jumpSound;
	[SerializeField] private AudioSource coin;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		jumpSound = GetComponent<AudioSource>();
		col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		coin.Play();
		Movement();
		VelocityState();
		anim.SetInteger("state", (int)state);

	}

	private void OnTriggerEnter2D(Collider2D other) {
		scoreText.text = score.ToString();
		if (other.tag == "Coin")
		{
			Destroy(other.gameObject);
			score += 1;
			scoreText.text = score.ToString();
		}
		if (other.tag == "Treasure")
		{
			score += 5;
			scoreText.text = score.ToString();
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
		}
	}
	
	private void Movement(){
		float movement = Input.GetAxis("Horizontal");


		if(Input.GetKey(KeyCode.D)){
			rb.velocity = new Vector2(movement*speed,rb.velocity.y);
			// pindah = -1;
			transform.localScale = new Vector2(1, 1);
		}
		else if(Input.GetKey(KeyCode.A)){
			rb.velocity = new Vector2(movement*speed, rb.velocity.y);
			// pindah = 1;
			transform.localScale = new Vector2(-1, 1);
		}
		if (Input.GetKey(KeyCode.W) && col.IsTouchingLayers(groundLayer)){
			rb.velocity = new Vector2(rb.velocity.x,jumpspeed);
			state = State.Jump;
			playSoundJump();
		}
	}

	private void VelocityState(){
		if (state == State.Jump)
		{
			if (rb.velocity.y < .1f)
			{
				state = State.Fall;
			}
		}
		else if (state == State.Fall)
		{
			if (col.IsTouchingLayers(groundLayer))
			{
				state = State.Idle;
			}
		}

		else if (Mathf.Abs(rb.velocity.x) > .2f)
		{
			state = State.Run;
		}
		else
		{
			state = State.Idle;
		}
	}

	public void playSoundJump(){
		jumpSound.Play();
	}
}
