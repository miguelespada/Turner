using UnityEngine;
using System.Collections;

public class logic : MonoBehaviour {

	// Use this for initialization
	public int state = 0;
	public GameObject cup;
	public GameObject balon;
	public GameObject camiseta;

	public void nextState(){
		state += 1;
		if(state == 1){
			cup.SetActive(true);
		}
		if(state == 2){
			camiseta.SetActive(true);
		}
	}
}
