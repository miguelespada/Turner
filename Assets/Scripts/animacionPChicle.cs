using UnityEngine;
using System.Collections;
using Spine;
using System;
public class animacionPChicle : MonoBehaviour {
	
	SkeletonAnimation skeletonAnimation;
	int valor;
	// Use this for initialization
	void Start () {
		
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")|| valor == 0) {
			if(UnityEngine.Random.Range(0, 10) > 5){
				skeletonAnimation.state.SetAnimation (0, "idle", true);
			}
			else{
				skeletonAnimation.state.SetAnimation (0, "idle2", true);
			}
			valor = -1;
		}
		if (Input.GetKeyDown ("2")|| valor == 1) {
			skeletonAnimation.state.AddAnimation (0, "anim0", true, 1f);
			valor = -1;
		}

		if (Input.GetKeyDown("3")|| valor == 2) {
			skeletonAnimation.state.SetAnimation (0, "anim1",  true);
			valor = -1;
		}

		if (Input.GetKeyDown ("4")|| valor == 3) {
			skeletonAnimation.state.SetAnimation (0, "anim2Loop", true);
			valor = -1;
		}


	}
	
	void anima(int v){
		valor = v;
	}
}
