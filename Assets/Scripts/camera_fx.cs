using UnityEngine;
using System.Collections;
using Spine;
using System;

public class camera_fx : MonoBehaviour {

	int valor = -1;
	private GlowEffect glow;
	public GameObject fondo_red;
	public GameObject fondo_green;
	public GameObject Audio_2;
	public GameObject Audio_3;
	public GameObject Audio_4;

	void Start () {
		glow = GetComponent<GlowEffect>();
	}

	void Update () {
		if (Input.GetKeyDown ("1") || valor == 0) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = true; 
			Audio_3.audio.mute = true; 
			Audio_4.audio.mute = true; 
		}
		if (Input.GetKeyDown ("2") || valor == 1) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = true; 
			Audio_4.audio.mute = true; 
		}
		if (Input.GetKeyDown ("3") || valor == 2) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = true; 
		}
		if (Input.GetKeyDown ("4") || valor == 3) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = true; 
		}
		
		if (Input.GetKeyDown ("5") || valor == 4) {
			glow.enabled = true;
			fondo_red.SetActive(true);
			fondo_green.SetActive(false);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = false; 
		}

		float v = UnityEngine.Random.Range(0.2f, 0.3f);
		glow.glowTint = new Color(v,v,v,1);
		if(valor >= 0) valor = -1; 
	}

	void anima(int v){
		valor = v;
	}
}
