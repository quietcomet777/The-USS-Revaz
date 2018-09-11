using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject flames;

	Vector3 where;
	bool touched = false;

	public GameObject button;
	Vector3 offset;
	public KeyCode[] keys; //up down left right

	public float force = 5;
	public GameObject booster;

	void Start () {
		offset = Vector3.zero;
		rb = GetComponent<Rigidbody2D> ();
		flames.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
			where = Vector3.zero;
		if (Input.GetKey(keys[0])){
				where += new Vector3 (0, 1, 0);
		}
		if (Input.GetKey(keys[1])){
				where += new Vector3 (0, -1, 0);
		}
		if (Input.GetKey(keys[2])){
				where += new Vector3 (-1, 0, 0);
		}
		if (Input.GetKey(keys[3])){
				where += new Vector3 (1, 0, 0);
		}
		if (where != Vector3.zero) {
			where.Normalize ();
			if (!touched) {
				flames.SetActive(true);
				touched = true;
			}
			rb.AddForce (where * force * 7);
			booster.transform.up = where;
		}
		button.transform.localPosition = offset + where *40;
		where *= 7;
		if (touched && where == Vector3.zero) {
			flames.SetActive(false);
			touched = false;
		}
	}
}
