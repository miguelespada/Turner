using UnityEngine;
using System.Collections;

public class logic : MonoBehaviour {

	// Use this for initialization
	public int state = 0;
	public GameObject cup;
	public GameObject balon;
	public GameObject camiseta;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void nextState(){
		state += 1;
		if(state == 1){
			balon.active = false;
			cup.active = true;
		}
		if(state == 2){
			cup.active = false;
			camiseta.active = true;
		}
		if(state == 3){
			camiseta.active = false;
		}
	}
}
