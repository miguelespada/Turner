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
	private bool hasCamiseta = false;
	void Start ()
	{
		Reset();

	}
	public void Reset(){
		nextCamiseta = Time.time + camisetaRate; 
		hasCamiseta = false;
	}
	public void Update(){
		if(hasCamiseta) return;
		if(Time.time > nextCamiseta){
			item = Instantiate (camiseta	) as GameObject;
			item.transform.position = transform.position;
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
		item.transform.position = transform.position;
		item.layer = gameObject.layer;
	}

	private void deleteObjects(){
		
		foreach (GameObject item in GameObject.FindGameObjectsWithTag("item")) {
			if(item.layer == gameObject.layer)
				Destroy(item);
		}
	}
}
