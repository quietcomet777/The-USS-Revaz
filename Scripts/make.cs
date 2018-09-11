using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make : MonoBehaviour {

	public float dist = 15;
	public GameObject[] blocks;
	Vector3 avg;

	// Use this for initialization
	void Start () {
		avg = transform.position;
		StartCoroutine (build ());
		StartCoroutine (pos ());
	}

	IEnumerator pos(){
		while (true) {
			int number = 0;
			foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship")) {
				avg += ship.transform.position;
				number++;
			}
			if (number != 0) {
				avg /= number;
			}
			float max = 0;
			foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship")) {
				float dist = (ship.transform.position - avg).magnitude;
				if (dist > max) {
					max = dist;
				}
			}
			dist = max + 15;
			yield return new WaitForSeconds (1);
		}
	}


	IEnumerator build(){
		Vector3 rando = new Vector3(0,0,0);
		rando.x = Random.Range (-10, 10);
		rando.y = Random.Range (-10, 10);
		rando = rando.normalized * dist;

		int choice = 0;
		int twerk = 0;
		GameObject thisOne;
		Rigidbody2D rb;

		while (true){
			choice = Random.Range (0, 2);
			twerk = Random.Range (-2 + choice, 2 - choice) * 80;

			yield return new WaitForSeconds(0.5f);
			thisOne = Instantiate (blocks[choice], avg + rando, Quaternion.identity);

			rando.x = Random.Range (-10, 10);
			rando.y = Random.Range (-10, 10);
			rando = rando.normalized * dist;

			rb = thisOne.GetComponent<Rigidbody2D> ();
			rb.AddForce ((rando) * 80f);
			rb.AddTorque (twerk);
		}
	}
}