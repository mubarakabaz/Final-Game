using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenChager : MonoBehaviour {

	[SerializeField] private string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}
