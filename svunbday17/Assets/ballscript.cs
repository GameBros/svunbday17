using UnityEngine;
using System.Collections;

public class ballscript : MonoBehaviour {

	Rigidbody rigi;
	Transform trans;

	bool move = true;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		trans = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			rigi.AddForce(new Vector3(0,0,-0.1f));
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			move = false;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Player") {
			move = true;
		}
	}
}
