using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	public GameObject ship;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = ship.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (ship.transform.position - offset) / 10;
	}
}
