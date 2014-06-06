using UnityEngine;
using System.Collections;
using Spine;
using System;

public class objeto: MonoBehaviour {
	
	public GameObject Fx;
	private string animationName;

	void Start ()
	{

		StartCoroutine(playAnimation());

	}

	void Update(){
		if (!animation.IsPlaying (animationName) || Input.GetKeyDown ("a")) {
			StartCoroutine(playAnimation());
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		transform.parent.GetComponent<logic>().nextState();
		Fx = Instantiate(Fx, transform.position, transform.rotation) as GameObject;
		Destroy(Fx, 2);
	}

	IEnumerator playAnimation(){
		int v = UnityEngine.Random.Range (0, animation.GetClipCount ());
		animationName = "anim_" + v;

		yield return new WaitForSeconds(2);

		animation.Play(animationName);
	}
}

