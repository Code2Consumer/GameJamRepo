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
			if(ToTheRight){
				transform.position += new Vector3(0.4F,0,0);
			}else{
				transform.position -= new Vector3(0.4F,0,0);
			}
		}
	}

	void OnCollisionEnter(Collision col)
    {
   		Debug.Log("colision canette");
   	}

	void OnTriggerEnter2D(Collider2D other)
    {
   		Debug.Log("trigger canette");
   	}
}
