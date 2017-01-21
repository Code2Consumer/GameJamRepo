using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {

	public float speed = 0.0f;

	public float jumpForce = 15;

	private bool isOnGround;

	private Animator animationOBJ;
	private Rigidbody2D m_Rigidbody2D;


	private bool LookRight;

	// Use this for initialization
	void Start () {

		animationOBJ = GetComponentInChildren<Animator> ();
		isOnGround = true;
		LookRight = true;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();



	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			//Destroy(other.gameObject);
			isOnGround = true;
			Debug.Log ("DESTROY");
		}

	}

	
	// Update is called once per frame
	void Update () {






		if (Input.GetKey (KeyCode.RightArrow) == true || Input.GetKey (KeyCode.LeftArrow) ) {
			animationOBJ.SetTime (1);
			if (isOnGround == true) {
				animationOBJ.Play ("PlayerWALKanim");
			}


			if (Input.GetKey (KeyCode.RightArrow) == true) {
				if (LookRight == false) {
					Flip ();
					LookRight = true;
				}

				m_Rigidbody2D.velocity = new Vector2 (speed, m_Rigidbody2D.velocity.y);

			}else if( Input.GetKey (KeyCode.LeftArrow)) {
				if (LookRight == true) {
					Flip ();
					LookRight = false;
				}


				m_Rigidbody2D.velocity = new Vector2 (-speed, m_Rigidbody2D.velocity.y);
			}



		} else if (Input.GetKey (KeyCode.RightArrow) == false && Input.GetKey (KeyCode.LeftArrow) == false) {
			animationOBJ.Play ("PlayerIDLEanim");
			m_Rigidbody2D.velocity = new Vector2 (0, m_Rigidbody2D.velocity.y);

		}

		if (Input.GetKey (KeyCode.UpArrow) == true && isOnGround == true) {
			animationOBJ.Play ("PlayerJUMPanim");
			//m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			isOnGround = false;

			m_Rigidbody2D.velocity = new Vector2 (0, jumpForce);
			//transform.Translate (Vector3.up * ( Time.deltaTime * jumpForce));

		}


	}



	public bool getLookRight()
	{
		return LookRight;
	}


	void Flip()
	{
		

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
