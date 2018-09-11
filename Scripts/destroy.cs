using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	private GameObject ship;
	private Vector3 offset;

	void Start(){
		offset = transform.position;
	}

	void Update(){
		if (ship == null)
			ship = GameObject.FindWithTag("Ship");
		Debug.Log (ship);
		Debug.Log (ship.transform.position);
		transform.position = ship.transform.position + offset;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != "Enemy") {
			Destroy (collision.gameObject);
		}
	}
}
