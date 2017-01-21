using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrierScript : MonoBehaviour {

	private float StartPressingShout; //Force du paralax
	private float ShoutPower; //Force du paralax
	public Transform Bruit;
	public Transform BruitLight;
	public Transform BruitLightClone;
	public bool PowerSet;
	public float RatioCrie;

	// Use this for initialization
	void Start () {
		PowerSet = false ;
		if(RatioCrie==0){
			RatioCrie = 7;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("space")){
			if(StartPressingShout == 0){
				StartPressingShout = Time.time;
			}
		}else{
			if(StartPressingShout != 0){
				ShoutPower = Time.time - StartPressingShout;
				ShoutPower = ShoutPower * RatioCrie;
				Transform bruitClone = Instantiate(Bruit,  transform.position, transform.rotation);
				bruitClone
					.GetComponent<BruitScript>()
					.setPower(ShoutPower);
				Transform bruitLightClone = Instantiate(BruitLight,  transform.position, transform.rotation);
				bruitLightClone
					.GetComponent<BruitLightScript>()
					.Puissance = ShoutPower;
			//	BruitLight					.GetComponent<BruitLightScript>()					.Parent=bruitClone;
				PowerSet = false ;
			}
			StartPressingShout = 0;
		}

	}
}
