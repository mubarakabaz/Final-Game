using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jebakan : MonoBehaviour {

	Gerak komponenGerak;

	// Use this for initialization
	void Start () {
		komponenGerak = GameObject.Find("Player").GetComponent<Gerak>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			Destroy(komponenGerak.gameObject);
		}
	}
}
