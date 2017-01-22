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
		if(Input.GetButton("ButtonRB") && PeuLancerCanette && !PeuRamasser){
		//	DoitRamasser = true;
			GetComponentInParent<AnimationCharacter> ().isThrowing = true;
			Debug.Log("e pressed");
			Debug.Log(Canette);
			ThrowCanette();
			GetComponentInParent<AnimationCharacter> ().isThrowing = false;
		}
		if(Input.GetButton("ButtonRB") && PeuRamasser && !PeuLancerCanette){
		//	DoitRamasser = true;
			GetComponentInParent<AnimationCharacter> ().isRamassing = true;
			GetComponentInParent<AnimationCharacter> ().getAnimator().Play("PlayerGETanim");
			Debug.Log("e pressed");
			Debug.Log(Canette);
		


			//GetComponentInParent<AnimationCharacter> ().isRamassing = false;

		}

		if(GetComponentInParent<AnimationCharacter> ().getAnimator().GetCurrentAnimatorStateInfo(0).IsName("PlayerGETanim") && GetComponentInParent<AnimationCharacter> ().getAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
		{
			PickUpObject();
			PeuRamasser = false;
			Debug.Log ("test");
			GetComponentInParent<AnimationCharacter> ().isRamassing = false;
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
			CanetteClone.GetComponent<CanetteScript>().ToTheRight = gameObject.GetComponent<AnimationCharacter>().getLookRight();
    		CanetteClone.GetComponent<CanetteScript>().Avance = true;
    		PeuLancerCanette = false ;
	}
}
