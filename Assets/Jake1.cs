using UnityEngine;
using System.Collections;
using Spine;
using System;

public class Jake1 : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	public int times;
	public GameObject Fx;

	void Start () {

		skeletonAnimation = GetComponent<SkeletonAnimation>();
		times = 0;
	}


	void Update () {

		if(times > 1){

			times = 0;
		}
					
		 
		if (Input.GetButtonDown ("Jump") && times <= 1) {
		
			times ++;
			Debug.Log(times);
			Fx = Instantiate(Fx, Fx.transform.position, Fx.transform.rotation) as GameObject;
			skeletonAnimation.state.SetAnimation (0, "jump", false);
			skeletonAnimation.state.AddAnimation (0, "idle", true, 0);

		}

		if (Input.GetButtonDown ("Jump") && times > 1) {

			times ++;
			Debug.Log(times);
			//Invoke ("Send", 0.8F) ;
			skeletonAnimation.state.SetAnimation (0, "catch", false);
			skeletonAnimation.state.AddAnimation (0, "idleC", true, 0);

		}
	}


	void Send (){

		//spawnEf.InstantiateEf() ;
	}
}
