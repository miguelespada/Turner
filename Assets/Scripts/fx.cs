using UnityEngine;
using System.Collections;
using Spine;
using System;

public class fx : MonoBehaviour {
	
	public GameObject red_c;
	public GameObject green_c;
	public GameObject sparks;
	public GameObject fireworks;
	int valor = -1;
	void Start () {
	}

	void Update () {
		if (Input.GetKeyDown ("1") || valor == 0) {

			print("level:0");
			red_c.SetActive(false);
			green_c.SetActive(false);
			sparks.SetActive(false);
			fireworks.SetActive(false);
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			print("level:1");
			red_c.SetActive(true);
			green_c.SetActive(false);
			sparks.SetActive(false);
			fireworks.SetActive(false);
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(false);
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(false);
		}
		
		if (Input.GetKeyDown ("5") || valor == 4) {
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(true);
		}
	}

	void anima(int v){
		valor = v;
	}
}
