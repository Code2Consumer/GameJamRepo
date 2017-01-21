using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanetteScript : MonoBehaviour {

	public bool Avance; //Force du paralax
	public bool ToTheRight; //Force du paralax

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Avance){
			transform.position += new Vector3(0.4F,0,0);
		}
	}
}
