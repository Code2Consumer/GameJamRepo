using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour {

	// Use this for initialization
	public void START_THE_GAME(){
		Application.LoadLevel ("FirstLevel");

		//Debug.Log ("COUCOU");

	}


	public void Update()
	{
		if (Input.GetButton ("StartButton")) {
			Application.LoadLevel ("Intro");

		}

		if (Input.GetButton ("ButtonSelect")) {
			Application.LoadLevel ("Credits");

		}
	}

}
