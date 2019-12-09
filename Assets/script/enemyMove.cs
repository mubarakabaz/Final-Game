using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMove : MonoBehaviour {

	private Vector3 naik;
	private Vector3 turun;
	private Vector3 nexPos;
	Player komponenGerak;

	[SerializeField] private float speed = 15;
	[SerializeField] private Transform mace;
	[SerializeField] private Transform transformB;
	// Use this for initialization
	void Start () {
		naik = mace.localPosition;
		turun = transformB.localPosition;
		nexPos = turun;
		komponenGerak = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	private void Move(){
		mace.localPosition = Vector3.MoveTowards(mace.localPosition,nexPos,speed * Time.deltaTime);

		if (Vector3.Distance(mace.localPosition,nexPos) <= .1f)
		{
			tukar();
		}
	}

	private void tukar(){
		if (nexPos != naik)
		{
			nexPos = naik;
			speed = 10;
		}
		else
		{
			nexPos = turun;
			speed = 20;
		}
	}


	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
		{
			Destroy(komponenGerak.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
	}
}
