using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour {

	[SerializeField] private float ACap;
	[SerializeField] private float BCAP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 5);
	}
}
