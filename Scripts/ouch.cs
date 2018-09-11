using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouch : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer sr;
	public Sprite[] cracks;
	public float power = 100;
	private int count = 0;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy"  && count < 4) {
			sr.sprite = cracks[count];
			count++;
			if (count == 4) {
				manager.dead = true;
				//Destroy (gameObject);
			}
			rb.AddForce ((collision.transform.position - transform.position) * power * 10);
			rb.AddTorque (power);
		}
	}
}
