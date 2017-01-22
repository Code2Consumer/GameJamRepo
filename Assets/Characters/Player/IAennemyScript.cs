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


	private int isFlip ;
	private bool LookRight;

	private Rigidbody2D m_Rigidbody2D;
	private Animator animatorEnnemy;


	private Vector3 lastPositionJoueur;

	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		animStart = true;
		startPosition = transform.position;
		isFlip = 1;
		LookRight = false;
		animatorEnnemy = GetComponentInChildren<Animator> ();
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
			Attack ();
		}

		
	}

	void Chase(){
		animatorEnnemy.Play ("WalkEnnemy");
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
		animatorEnnemy.Play ("WalkEnnemy");
		if (animStart == true) {
			m_Rigidbody2D.velocity = new Vector2 (-SpeedMovement, m_Rigidbody2D.velocity.y);
		}

		if (transform.position.x >= startPosition.x + maxRight) {
			goRight = false;
			goLeft = true;
			if (isFlip == 0) {
				isFlip = 1;
				Flip ();
			}


			//transform.Translate (Vector3.left * ( Time.deltaTime * SpeedMovement));
		} else if (transform.position.x <= startPosition.x - maxLeft) {
			animStart = false;
			goRight = true;
			goLeft = false;
			if (isFlip == 1) {
				isFlip = 0;
				Flip ();
			}



		}

	

		if (goRight == true) {
			if (LookRight == false) {
				Flip ();
			}
			
			m_Rigidbody2D.velocity = new Vector2 (SpeedMovement, m_Rigidbody2D.velocity.y);
		}else if(goLeft == true){
			if (LookRight == true) {
				Flip ();
			}
			
			m_Rigidbody2D.velocity = new Vector2 (-SpeedMovement, m_Rigidbody2D.velocity.y);
		}
	}


	void Attack()
	{
		animatorEnnemy.Play ("AttackEnnemy");
		if (transform.Find ("/Perso").position.x > transform.position.x && LookRight == false) {
			Flip ();
		} else if (transform.Find ("/Perso").position.x < transform.position.x && LookRight == true) {
			Flip ();
		}
	}

	void Flip()
	{
		LookRight = !LookRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
