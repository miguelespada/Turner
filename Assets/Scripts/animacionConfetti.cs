using UnityEngine;
using System.Collections;
using Spine;
using System;

public class animacionConfetti : MonoBehaviour {

	int valor;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1") || valor == 0) {
			particleSystem.emissionRate = 0;
			valor = -1;
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			particleSystem.emissionRate = 00;
			valor = -1;
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			particleSystem.emissionRate = 100;
			valor = -1;
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			particleSystem.emissionRate = 1000;
			valor = -1;
		}
	}

	
	void anima(int v){
		valor = v;
	}
}
