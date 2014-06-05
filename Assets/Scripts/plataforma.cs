using UnityEngine;
using System.Collections;
using Spine;
using System;

public class plataforma: MonoBehaviour {

	bool j; 
	int state = 0;
	public string jumpKey = "a"; 

	void Start () {
	}


	void Update () {
					
		if ((Input.GetKeyDown (jumpKey) || j) && state == 0) {
			rigidbody2D.AddForce(Vector2.up * 10000);
			j = false;
			audio.Play();
		}
	}

	
	void jump(float v){
		j = true;
	}

}

