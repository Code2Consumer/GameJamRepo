using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThrowScript : MonoBehaviour {

	public bool PeuRamasser; //Force du paralax
	public bool DoitRamasser; //Force du paralax
	public bool PeuLancerCanette; //Force du paralax
	public GameObject Canette; //Force du paralax
	public GameObject CanetteModel; //Force du paralax
	// Use this for initialization
	void Start () {
		Canette 			= 	null;
		PeuRamasser 		=	false;
		DoitRamasser 		=	false;
		PeuLancerCanette 	= 	false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("e") && PeuLancerCanette && !PeuRamasser){
		//	DoitRamasser = true;
			Debug.Log("e pressed");
			Debug.Log(Canette);
			ThrowCanette();
		}
		if(Input.GetKeyDown("e") && PeuRamasser && !PeuLancerCanette){
		//	DoitRamasser = true;
			Debug.Log("e pressed");
			Debug.Log(Canette);
			PickUpObject();
			PeuRamasser = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "Canette"){
			PeuRamasser = true;
			Canette = col.gameObject;
			Debug.Log(Canette);
		}
    }
	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.name == "Canette"){
			PeuRamasser = false;
		}
    }

    void OnTrigger(Collider2D col) {

    }
    void PickUpObject(){
		PeuLancerCanette = true;
		Destroy(Canette);
		//Canette.transform.position.z = -50;
    }
    void ThrowCanette(){
    		Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
    		//Canette.transform = transform;		
			Transform CanetteClone = Instantiate(CanetteModel.transform,  transform.position, transform.rotation);
    		CanetteClone.GetComponent<CanetteScript>().Avance = true;
    		PeuLancerCanette = false ;
	}
}
