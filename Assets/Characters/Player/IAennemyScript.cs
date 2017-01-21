using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAennemyScript : MonoBehaviour {

	public float maxRight;
	public float maxLeft;

	public float SpeedMovement;

	private bool animStart;
	public bool isChasing;
	public bool isAttacking;
	private bool goLeft;
	private bool goRight;


	private Vector3 lastPositionJoueur;

	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		animStart = true;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking == false && isChasing == false) {
			routine ();
		} else if (isChasing == true && isAttacking == false) {
			Chase ();
		}

		
	}

	void Chase(){
		lastPositionJoueur = transform.Find ("/Perso").position;
		if (transform.position.x != lastPositionJoueur.x) {
			transform.Translate (lastPositionJoueur * Time.deltaTime * SpeedMovement);
		}
		//transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);

	}

	void routine()
	{
		if (animStart == true) {
			transform.Translate (Vector3.left * ( Time.deltaTime * SpeedMovement));
		}

		if (transform.position.x >= startPosition.x + maxRight) {
			goRight = false;
			goLeft = true;
			//transform.Translate (Vector3.left * ( Time.deltaTime * SpeedMovement));
		} else if (transform.position.x <= startPosition.x - maxLeft) {
			animStart = false;
			goRight = true;
			goLeft = false;

		}

		if (goRight == true) {
			transform.Translate (Vector3.right * ( Time.deltaTime * SpeedMovement));
		}else if(goLeft == true){
			transform.Translate (Vector3.left * ( Time.deltaTime * SpeedMovement));
		}
	}



}
