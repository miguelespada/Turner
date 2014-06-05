using UnityEngine;
using System.Collections;
using Spine;
using System;
public class animacionMordecai : MonoBehaviour {
	
	SkeletonAnimation skeletonAnimation;
	int valor;
	// Use this for initialization
	void Start () {
		
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")|| valor == 0) {
			skeletonAnimation.state.SetAnimation (0, "idle", true);
			valor = -1;
		}
		if (Input.GetKeyDown ("2")|| valor == 1) {
			skeletonAnimation.state.AddAnimation (0, "anim2", true, 1f);
			valor = -1;
		}

		if (Input.GetKeyDown("3")|| valor == 2) {
			skeletonAnimation.state.SetAnimation (0, "anim3",  true);
			valor = -1;
		}

		if (Input.GetKeyDown ("4")|| valor == 3) {
			skeletonAnimation.state.SetAnimation (0, "anim4",  true);
			valor = -1;
		}


	}
	
	void anima(int v){
		valor = v;
	}
}
