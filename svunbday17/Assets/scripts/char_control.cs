﻿using UnityEngine;
using System.Collections;

public class char_control : MonoBehaviour {

	Animator anim;
	Rigidbody rigi;
	Transform trans;
	Collider coll;
	float distToGround;

	public float moveSpeed;
	public float jumpVel;
	public Transform currentSpawnPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigi = GetComponent<Rigidbody> ();
		trans = GetComponent<Transform> ();
		coll = GetComponent<Collider> ();
		distToGround = coll.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.Play ("move");
			trans.Translate (new Vector3(0,0,moveSpeed));
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.Play ("move");
			trans.Translate (new Vector3(0,0,-moveSpeed));
		} else {
			anim.Play ("stand");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGrounded ()) {
				rigi.AddForce (Vector3.up * jumpVel);
			}
		}
	}

	bool isGrounded(){
		return Physics.Raycast (trans.position, Vector3.down, distToGround + 1f);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "killing") {
			respawn();
		}

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Respawn") {
			currentSpawnPoint = col.transform;
		}
	}

	void respawn(){
		transform.position = currentSpawnPoint.position;
	}

}
