using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	public static int won = 0;
	public static bool dead = false;

	
	// Update is called once per frame
	void Update () {
		if (dead) {
			Debug.Log ("YOU LOSE");
		}
		if (won == 3) {
			Debug.Log ("YOU WIN");
		}
	}
}
