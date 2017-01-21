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

	private Rigidbody2D m_Rigidbody2D;


	private Vector3 lastPositionJoueur;

	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		animStart = true;
		startPosition = transform.position;

		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking == false && isChasing == false) {
			routine ();
		} else if (isChasing == true && isAttacking == false) {
			Chase ();
		} else if (isChasing == true & isAttacking == true) {
			m_Rigidbody2D.velocity = new Vector2 (0, m_Rigidbody2D.velocity.y);
		}

		
	}

	void Chase(){
		lastPositionJoueur = transform.Find ("/Perso").position;
		if (transform.position.x > lastPositionJoueur.x) {


			m_Rigidbody2D.velocity = new Vector2 (-SpeedMovement, m_Rigidbody2D.velocity.y);
		} else {
			m_Rigidbody2D.velocity = new Vector2 (SpeedMovement, m_Rigidbody2D.velocity.y);
		}
		//transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);

	}

	void routine()
	{
		if (animStart == true) {
			m_Rigidbody2D.velocity = new Vector2 (-SpeedMovement, m_Rigidbody2D.velocity.y);
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
			m_Rigidbody2D.velocity = new Vector2 (SpeedMovement, m_Rigidbody2D.velocity.y);
		}else if(goLeft == true){
			m_Rigidbody2D.velocity = new Vector2 (-SpeedMovement, m_Rigidbody2D.velocity.y);
		}
	}



}
