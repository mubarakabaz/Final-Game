using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chest : MonoBehaviour {

	public Sprite close;
	public Sprite open;
	private SpriteRenderer openChest;
	public int score = 0;

	// Use this for initialization
	void Start () {
		openChest = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			openChest.sprite = open;
			score += 5;
		}
	}
}
