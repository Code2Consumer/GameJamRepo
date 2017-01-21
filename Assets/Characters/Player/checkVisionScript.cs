using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkVisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("In");
			GetComponentInParent<IAennemyScript> ().isChasing = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("Out");
			GetComponentInParent<IAennemyScript> ().isChasing = false;
		}
	}
}


