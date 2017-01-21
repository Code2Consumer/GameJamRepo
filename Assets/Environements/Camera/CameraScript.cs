using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {
		 RenderSettings.ambientLight = Color.black;
		// GameObject thePlayer = GameObject.Find("/Player").transform;
		// Player = thePlayer.Transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Player.GetComponent<AnimationCharacter>().getLookRight());
		gameObject.transform.position = new Vector3(Player.position.x+8, Player.position.y, gameObject.transform.position.z);
	}
}
