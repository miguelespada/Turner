using UnityEngine;
using System.Collections;
using Spine;
using System;

public class balon : MonoBehaviour {
	
	public GameObject Fx;

	void OnCollisionEnter2D(Collision2D coll) {
		audio.Play();
		Fx = Instantiate(Fx, transform.position, transform.rotation) as GameObject;
		Destroy(Fx, 2);
		Destroy(gameObject);
	}

}

