using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAttackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("In");
			GetComponentInParent<IAennemyScript> ().isAttacking = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("Out");
			GetComponentInParent<IAennemyScript> ().isAttacking = false;
		}
	}
}
