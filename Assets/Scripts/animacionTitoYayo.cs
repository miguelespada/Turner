using UnityEngine;
using System.Collections;
using Spine;
using System;
public class animacionTitoYayo : MonoBehaviour {
	
	SkeletonAnimation skeletonAnimation;
	int valor;
	// Use this for initialization
	void Start () {
		
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")|| valor == 0) {
			skeletonAnimation.state.SetAnimation (0, "idle0", true);
			valor = -1;
		}
		if (Input.GetKeyDown ("2")|| valor == 1) {
			skeletonAnimation.state.SetAnimation (0, "idle/anim0", false);
			skeletonAnimation.state.AddAnimation (0, "anim0", true, 1f);
			valor = -1;
		}

		if (Input.GetKeyDown("3")|| valor == 2) {
			skeletonAnimation.state.AddAnimation (0, "anim1", true, 1f);
			valor = -1;
		}

		if (Input.GetKeyDown ("4")|| valor == 3) {
			skeletonAnimation.state.AddAnimation (0, "anim2Loop3", true, 1f);
			valor = -1;
		}


	}
	
	void anima(int v){
		valor = v;
	}
}
