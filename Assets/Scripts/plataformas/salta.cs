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
	public GameObject Fx;

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}


	void Update () {
		if(state == 2)
			StartCoroutine(backToNormal());

		if (state == 0 && (Input.GetKeyDown (jumpKey) || j) ) {
			skeletonAnimation.state.SetAnimation (0, "jumpUp", false);
			rigidbody2D.velocity = Vector2.up * speed;
			j = false;
			state = 1;
			plataformaJump();
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(state == 2) return;
		if(coll.gameObject.tag == "plataforma"){
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
			StartCoroutine(playEffect());
			state = 0;
		}
		else{
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
			state = 0;

		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.layer == gameObject.layer) { 
			if (other.gameObject.name == "camiseta") {
				skeletonAnimation.state.SetAnimation (0, "jumpDown", false);
				skeletonAnimation.state.AddAnimation (0, "idleC", true, 0);
				state = 2;
			}
			other.audio.Play ();
			Destroy (other.gameObject, 0.1f);
		}

	}

	void jump(float v){
		j = true;
	}

	void plataformaJump(){
		foreach (Transform child in transform.parent) 
		{
			if (child.name == "collider")
			{
				child.rigidbody2D.AddForce(Vector2.up * 10000);
				child.audio.Play();
				
			}
		}
	}

	IEnumerator playEffect(){
		Fx.SetActive(true);
		yield return new WaitForSeconds(1);
		Fx.SetActive(false);
	}

	IEnumerator backToNormal(){
		yield return new WaitForSeconds(2);
		state = 0;
		skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
	}

}

