using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jebakan : MonoBehaviour {

	Player komponenGerak;

	// Use this for initialization
	void Start () {
		komponenGerak = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			Destroy(komponenGerak.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
