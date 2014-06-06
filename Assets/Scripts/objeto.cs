using UnityEngine;
using System.Collections;
using Spine;
using System;

public class objeto: MonoBehaviour {
	
	public GameObject Fx;

	void Start ()
	{
		animation.Play ();
		UnityEngine.Random.Range (0, animation.GetClipCount ());
	}

	void Update(){
		if (Input.GetKeyDown ("a")){
			int v = UnityEngine.Random.Range (0, animation.GetClipCount ());
			animation.Play("anim_" + v);
			              
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		audio.Play();
		Fx = Instantiate(Fx, transform.position, transform.rotation) as GameObject;
		Destroy(Fx, 2);
		Destroy(gameObject);
	}

}

