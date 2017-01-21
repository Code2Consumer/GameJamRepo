using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatIA : MonoBehaviour {



	public bool isAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if (isAnim == true) {
			transform.Translate (Vector3.left * ( Time.deltaTime * 5));
		}
				
	}
}
