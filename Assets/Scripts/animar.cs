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
			valor = -1;
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			skeletonAnimation.state.SetAnimation (0, "idle/anim0", false);
			skeletonAnimation.state.AddAnimation (0, "anim0", true, 1f);
			valor = -1;
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			skeletonAnimation.state.SetAnimation (0, "anim1", true);
			valor = -1;
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			skeletonAnimation.state.SetAnimation (0, "anim2", true);
			valor = -1;
		}
	}

	void anima(int v){
		valor = v;
	}
}
