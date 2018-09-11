using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocklife : MonoBehaviour {

	float minDist;
	GameObject[] ships;

	void Start(){
		StartCoroutine(Check());
	}

	IEnumerator Check(){
		yield return new WaitForSeconds (10);	//start within 10 s
		while (true) {
			minDist = 20;
			foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship")) {
				float thisDist = (ship.transform.position - transform.position).magnitude;
				if (thisDist < minDist) {
					minDist = thisDist;
				}
			}
			if (minDist > 15) {
				Destroy (gameObject);
			}
			yield return new WaitForSeconds (3);
		}
	}
}
