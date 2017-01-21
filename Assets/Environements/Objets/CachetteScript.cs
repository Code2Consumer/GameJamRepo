using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachetteScript : MonoBehaviour {

	public GameObject Cachette; //Force du paralax
	public bool PeuSeCacher; //Force du paralax
	public bool EstCachee; //Force du paralax

	// Use this for initialization
	void Start () {
		PeuSeCacher = true ;
		EstCachee = false ;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && EstCachee) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true ;
			EstCachee = false;
		}
		if(Input.GetKeyDown("f") && PeuSeCacher && !EstCachee){
			gameObject.GetComponent<SpriteRenderer>().enabled = false ;
			EstCachee = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "Cachette"){
			PeuSeCacher = true;
			Cachette = col.gameObject;
		}
    }
	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.name == "Cachette"){
			PeuSeCacher = false;
		}
    }
}
