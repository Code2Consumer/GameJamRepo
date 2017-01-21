using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitLightScript : MonoBehaviour {

	public float Puissance; //Force du paralax
	public Transform Parent; //Force du paralax
	public bool go;
	public bool back;

	
	// Use this for initialization
	void Start () {
		go = true ;
		back = false ;
		transform.GetComponent<Light>().range = Puissance*4;
	}
	
	// Update is called once per frame
	void Update () {
		if(Parent!=null){
			transform.GetComponent<Light>().range = Puissance*4;
		}
		if(go){
			transform.position -= new Vector3(0,0,0.34F);
			if(transform.position.z <= -Puissance){
				go 		= false;
				back 	= true;
				//Destroy(gameObject);
			}
		}
		if(back){
			transform.position += new Vector3(0,0,0.34F);
			if(transform.position.z >= 0){
				Destroy(gameObject);
			}
		}
	}

	public void setPower(float power){
		Puissance = power;
	}

}
