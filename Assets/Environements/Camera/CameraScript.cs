using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform Player;
	public float height;
	public float width;
	public float speed;

	// Use this for initialization
	void Start () {
		 RenderSettings.ambientLight = Color.black;
		// GameObject thePlayer = GameObject.Find("/Player").transform;
		// Player = thePlayer.Transform;
		height = Camera.main.orthographicSize *2f;
        width = height / (float)Screen.height * (float)Screen.width;
        speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		height = Camera.main.orthographicSize *2f;
        width = height / (float)Screen.height * (float)Screen.width;

        float step = speed * Time.deltaTime;
		if(Player.GetComponent<AnimationCharacter>().getLookRight()){
			// gameObject.transform.Translate(new Vector3(Player.position.x+(width*0.4f), Player.position.y, gameObject.transform.position.z).forward );
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x+(width*0.4f), Player.position.y, gameObject.transform.position.z), step);
		}else{
			// gameObject.transform.Translate(new Vector3(Player.position.x+(width*-0.4f), Player.position.y, gameObject.transform.position.z).forward );
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, Player.position.y, gameObject.transform.position.z), step);
		}
	}
}
