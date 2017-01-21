using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRat : MonoBehaviour {

	private Transform Rat;

	// Use this for initialization
	void Start () {
		Rat = transform.Find ("/Rat");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Rat = transform.Find ("/Rat");
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			
			Rat.GetComponent<RatIA> ().isAnim = true;
		}

	}
}
