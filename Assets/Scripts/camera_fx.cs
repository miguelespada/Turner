using UnityEngine;
using System.Collections;
using Spine;
using System;

public class camera_fx : MonoBehaviour {

	int valor = -1;
	private GlowEffect glow;
	void Start () {
		glow = GetComponent<GlowEffect>();
	}

	void Update () {
		if (Input.GetKeyDown ("1") || valor == 0) {
			glow.enabled = false;
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			glow.enabled = false;
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			glow.enabled = false;
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			glow.enabled = false;
		}
		
		if (Input.GetKeyDown ("5") || valor == 4) {
			glow.enabled = true;
		}
			float v = UnityEngine.Random.Range(0.4f, 0.6f);
			glow.glowTint = new Color(v,v,v,1);
	}

	void anima(int v){
		valor = v;
	}
}
