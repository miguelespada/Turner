using UnityEngine;
using System.Collections;

public class logic : MonoBehaviour {

	// Use this for initialization
	GameObject item;
	public GameObject[] items;
	public GameObject camiseta;
	
	public float itemRate = 2F;
	public float nextItem = 0F;
	private float nextCamiseta;
	public float camisetaRate = 10F;
	private bool hasCamiseta = true;
	void Start ()
	{
		Reset();
		hasCamiseta = true;
	}

	public void Reset(){
		nextCamiseta = Time.time + camisetaRate; 
		hasCamiseta = false;
		nextItem = Time.time;
		createItem();
	}

	public void Update(){
		if(hasCamiseta) return;
		if(Time.time > nextCamiseta){
			item = Instantiate (camiseta	) as GameObject;
			item.transform.parent = transform;
			item.layer = gameObject.layer;
			hasCamiseta = true;
			deleteObjects();

		}
		else if(Time.time > nextItem){
			nextItem = Time.time + itemRate;
			createItem();
		}
	}
	private void createItem(){
		item =  Instantiate (items[Random.Range(0, 4)]) as GameObject;
		item.transform.parent = transform;
		item.layer = gameObject.layer;
	}

	private void deleteObjects(){
		
		foreach (GameObject item in GameObject.FindGameObjectsWithTag("item")) {
			if(item.layer == gameObject.layer)
				Destroy(item);
		}
	}
	public void setGameTime(int value){
		camisetaRate = value;
	}
	public void setItemFreq(int value){
		itemRate = value;
	}
}
