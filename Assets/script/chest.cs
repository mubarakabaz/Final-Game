using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chest : MonoBehaviour {

	public int score = 0;
	Animator anim;
	private enum State {Idle, Open};
	private State state = State.Idle;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger("peti",(int)state);
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && state == State.Idle)
		{
			state = State.Open;
			score += 5;
			Debug.Log(score);
		}
	}
}
