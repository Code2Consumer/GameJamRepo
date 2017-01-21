using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrierScript : MonoBehaviour {

	private float StartPressingShout; //Force du paralax
	private float ShoutPower; //Force du paralax

	// Use this for initialization
	void Start () {
		
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
				Debug.Log("shout: "+ShoutPower);
				// Shout
				// Spawn Shout at Player
			}
			StartPressingShout = 0;
		}

	}
}
