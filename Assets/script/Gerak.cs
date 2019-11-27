using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak : MonoBehaviour {


	public float speed = 5f;
	public float jumpspeed = 8f;
	private Rigidbody2D rb;
	private float movement = 0f;
	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool isTouchingGround;
	public bool balik;
	public int pindah;
	private Collider2D col;
	Animator anim;
	private enum State {Idle, Run, Jump, Fall};
	private State state = State.Idle;
	public AudioSource jumpSound;
	public AudioSource backsound;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		playBackSound();
	}

	// Update is called once per frame
	void Update () {
		isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,groundLayer);
		movement = Input.GetAxis("Horizontal");

		// mulai gerak player
		if(Input.GetKey(KeyCode.D)){
			rb.velocity = new Vector2(movement*speed,rb.velocity.y);
			pindah = 1;
		}
		else if(Input.GetKey(KeyCode.A)){
			rb.velocity = new Vector2(movement*speed, rb.velocity.y);
			pindah = -1;

		}
		if (Input.GetKey(KeyCode.W) && isTouchingGround){
			playSoundJump();
			rb.velocity = new Vector2(rb.velocity.x,jumpspeed);

		}
		//stop gerak player

		//mulai balik player
		if (pindah > 0 && !balik)
		{
			balikBadan();
		}
		else if(pindah < 0 && balik){
			balikBadan();
		}
		//stop balik player

	}

	public void playSoundJump(){
		jumpSound.Play();
	}

	public void playBackSound(){
		backsound.Play();
	}

	void balikBadan(){
		 balik = !balik;
		 Vector3 karakter = transform.localScale;
		 karakter.x *= -1;
		 transform.localScale = karakter;

	}
}
