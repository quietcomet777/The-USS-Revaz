using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public GameObject unluckyShip;
	float minDist = 10f;
	public float thrust = 1;
	Rigidbody2D rb;
	Vector2 dir;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		StartCoroutine (Hunt ());
	}

	IEnumerator Hunt(){
		while (true) {
			minDist = 10f;
			foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship")) {
				float thisDist = (ship.transform.position - transform.position).magnitude;
				Debug.Log (thisDist);
				if (thisDist < minDist) {
					minDist = thisDist;
					unluckyShip = ship;
				}
			}
			yield return new WaitForSeconds (3);
		}
	}

	void Update () {
			dir = unluckyShip.transform.position - transform.position;
			transform.up = dir;
			rb.AddForce (transform.up * thrust * (dir.sqrMagnitude + 20));
	}
}
