using UnityEngine;
using System.Collections;
using Spine;
using System;

public class fx : MonoBehaviour {
	
	int valor = -1;
	private GlowEffect glow;
	public GameObject fondo_red;
	public GameObject fondo_green;
	public GameObject Audio_2;
	public GameObject Audio_3;
	public GameObject Audio_4;
	
	public GameObject red_c;
	public GameObject green_c;
	public GameObject sparks;
	public GameObject fireworks;
	
	void Start () {
		glow = GetComponent<GlowEffect>();
	}
	
	void Update () {
		if ( valor == 0 ) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = true; 
			Audio_3.audio.mute = true; 
			Audio_4.audio.mute = true; 
			red_c.SetActive(false);
			green_c.SetActive(false);
			sparks.SetActive(false);
			fireworks.SetActive(false);
		}
		if ( valor == 1 ) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = true; 
			Audio_4.audio.mute = true; 
			
			red_c.SetActive(true);
			green_c.SetActive(false);
			sparks.SetActive(false);
			fireworks.SetActive(false);
		}
		if ( valor == 2 ) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = true;			
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(false);
		}
		if ( valor == 3 ) {
			glow.enabled = false;
			fondo_red.SetActive(false);
			fondo_green.SetActive(true);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = true;		
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(false);
		}
		
		if ( valor == 4 ) {
			glow.enabled = true;
			fondo_red.SetActive(true);
			fondo_green.SetActive(false);
			Audio_2.audio.mute = false; 
			Audio_3.audio.mute = false; 
			Audio_4.audio.mute = false;
			red_c.SetActive(true);
			green_c.SetActive(true);
			sparks.SetActive(true);
			fireworks.SetActive(true);
		}
		
		if(valor >= 0) valor = -1; 
		
		float v = UnityEngine.Random.Range(0.2f, 0.3f);
		glow.glowTint = new Color(v,v,v,1);
	}
	
	void anima(int v){
		valor = v;
	}
}
