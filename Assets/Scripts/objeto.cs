using UnityEngine;
using System.Collections;
using Spine;
using System;

public class objeto: MonoBehaviour {
	
	public GameObject Fx;

	void OnTriggerEnter2D(Collider2D other) {
		audio.Play();
		Fx = Instantiate(Fx, transform.position, transform.rotation) as GameObject;
		Destroy(Fx, 2);
		Destroy(gameObject);
	}

}

