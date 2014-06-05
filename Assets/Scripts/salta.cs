using UnityEngine;
using System.Collections;
using Spine;
using System;

public class salta : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	bool j; 
	int state = 0;
	public int speed = 3000;
	public string jumpKey = "a"; 

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}


	void Update () {

		if (state == 0 && (Input.GetKeyDown (jumpKey) || j) ) {
			skeletonAnimation.state.SetAnimation (0, "jumpUp", false);
			rigidbody2D.velocity = Vector2.up * speed;
			j = false;
			state = 1;
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "plataforma"){
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
			state = 0;
		}
		else{
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
			state = 0;

		}
	}
	
	void jump(float v){
		j = true;
	}

}

