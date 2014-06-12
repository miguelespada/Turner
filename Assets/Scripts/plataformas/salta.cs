using UnityEngine;
using System.Collections;
using Spine;
using System;

public class salta : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	int level = 0; 
	public int state = -1;
	int speed = 3000;
	public GameObject Fx;
	public int backToNormalTime = 3;
	private Quaternion q;

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
		state = -1;
		q = transform.rotation; 
	}


	void Update () {
		transform.rotation = q;
		if(state == 2) {
			state = 3;
			StartCoroutine(backToNormal());
		}

		if (state == 0 ) {
			if(level > 0){
				skeletonAnimation.state.SetAnimation (0, "jumpUp", false);
				rigidbody2D.velocity = Vector2.up * speed;
				plataformaJump();
				setGravityScale(level);
				level = 0;
				state = 1;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(state != 1) return;

		if(coll.gameObject.tag == "plataforma"){
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
			StartCoroutine(playEffect());
			state = 0;
		}

	}
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.layer == gameObject.layer && state == 1) { 
			if (other.gameObject.tag == "camiseta") {
				skeletonAnimation.state.SetAnimation (0, "jumpDown", false);
				skeletonAnimation.state.AddAnimation (0, "idleC", true, 0);
				transform.Find("audio_camiseta").audio.Play();
				state = 2;
			}
			else {
				transform.Find("audio_coge").audio.Play();
			}
			Destroy (other.gameObject);
		}

	}

	void jump(int v){
		level = v;
		if(state == -1) {
			transform.parent.Find("items").GetComponent<logic> ().Reset ();
			state = 0;
		}
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
		yield return new WaitForSeconds(backToNormalTime);
		state = -1;
		skeletonAnimation.state.AddAnimation (0, "idle", true, 0);
	}

	void setGravityScale(int speed){
		
		if(level == 1) rigidbody2D.gravityScale = 22;
		else if(level == 2) rigidbody2D.gravityScale = 18;
		else if(level == 3) rigidbody2D.gravityScale = 14;
		else if(level == 4) rigidbody2D.gravityScale = 12.5f;
		else if(level == 5) rigidbody2D.gravityScale = 8;
		else if(level == 6) rigidbody2D.gravityScale = 6;
		else rigidbody2D.gravityScale = 12.5f;
		rigidbody2D.gravityScale += UnityEngine.Random.Range(-1f, 1f);
	}

}

