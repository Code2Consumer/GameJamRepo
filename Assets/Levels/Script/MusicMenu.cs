using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour {

	//public Object[] MusicAmbianceMenu;
	// Use this for initialization

	void Awake(){
		//GetComponent<AudioSource> ().Play ();
	}
	void Start () {
		GetComponent<AudioSource> ().Play ();

	}

	// Update is called once per frame
	void Update () {
		/*if (!GetComponent<AudioSource> ().isPlaying) {
			playRandomMusic ();

		}*/
	}

	void playRandomMusic(){
		//GetComponent<AudioSource> ().clip = MusicAmbianceMenu [Random.Range (0, MusicAmbianceMenu.Length)] as AudioClip;
	}
}
