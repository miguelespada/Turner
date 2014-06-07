using UnityEngine;
using System.Collections;
using Spine;
using System;

public class animar : MonoBehaviour {
	
	SkeletonAnimation skeletonAnimation;
	int valor;
	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}

	void Update () {
		if (Input.GetKeyDown ("1") || valor == 0) {
			skeletonAnimation.state.SetAnimation (0, "idle", true);
			skeletonAnimation.timeScale = 1;
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			skeletonAnimation.state.SetAnimation (0, "idle/anim0", false);
			skeletonAnimation.state.AddAnimation (0, "anim0", true, 1f);
			skeletonAnimation.timeScale = 1;
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			skeletonAnimation.state.SetAnimation (0, "anim1", true);
			skeletonAnimation.timeScale = 1;
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			skeletonAnimation.state.SetAnimation (0, "anim2", true);

			skeletonAnimation.timeScale = 1;
		}

		if (Input.GetKeyDown ("5") || valor == 4) {
			skeletonAnimation.state.SetAnimation (0, "anim2", true);
			skeletonAnimation.timeScale = 2;

		}
		if(valor >= 0) valor = -1; 
	}

	void anima(int v){
		valor = v;
	}
}
