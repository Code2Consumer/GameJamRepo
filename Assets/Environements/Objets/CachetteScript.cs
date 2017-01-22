using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachetteScript : MonoBehaviour {

	public GameObject Cachette; 
	public bool PeuSeCacher; 
	public bool EstCachee; 
	public Component[] aSources; 

	// Use this for initialization
	void Start () {
		PeuSeCacher = true ;
		EstCachee = false ;

		aSources = GetComponents<AudioSource>(); 
		Component audio1 = aSources[0]; 
		Component audio2 = aSources[1]; 
		Component audio3 = aSources[2];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && EstCachee) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true ;
			Cachette.GetComponent<SpriteRenderer>().enabled = true;
			EstCachee = false;
			//Play Sound Ouvrir 
		}
		if(Input.GetKeyDown("f") && PeuSeCacher && !EstCachee){
			gameObject.GetComponent<SpriteRenderer>().enabled = false ;
			Cachette.GetComponent<SpriteRenderer>().enabled = false;
			EstCachee = true;
			//Play Sound fermer
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "Casier 01 Ouvert" || col.gameObject.name == "Casier 02 Ouvert"){
			//Casier 02 Ouvert
			PeuSeCacher = true;
			Cachette = col.gameObject;
		}
    }
	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.name == "Casier 01 Ouvert" || col.gameObject.name == "Casier 02 Ouvert"){
			PeuSeCacher = false;
			Cachette = null ;
		}
    }
}
