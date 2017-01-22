using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurbrillanceScript : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Bruit" || other.gameObject.name == "Bruit(Clone)" ) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true ;	
		}
	}

}
