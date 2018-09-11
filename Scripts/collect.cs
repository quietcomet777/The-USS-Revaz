using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour {

	public string tag;
	public GameObject[] dots;
	int count = 0;

	void OnCollisionEnter2D(Collision2D thing){
		if (thing.transform.tag == tag) {
			Destroy (thing.gameObject);
			if (count < 5) {
				dots [count].GetComponent<SpriteRenderer> ().color =  new Color32( 0xD1, 0xCD, 0x4C, 0xFF );
				count++;
				if (count == 5) {
					manager.won += 1;
				}
			}
		}
	}

}
