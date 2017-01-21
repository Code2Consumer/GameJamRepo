using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitLightScript : MonoBehaviour {

	public float Puissance; //Force du paralax
	public Transform Parent; //Force du paralax
	
	// Use this for initialization
	void Start () {
		transform.GetComponent<Light>().range = Puissance*2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Parent!=null){
			transform.GetComponent<Light>().range = Puissance*2;
		}
		transform.position -= new Vector3(0,0,0.12F);
		if(transform.position.z <= -20.0F){
			Destroy(gameObject);
		}
	}

	public void setPower(float power){
		Puissance = power;
	}

}
