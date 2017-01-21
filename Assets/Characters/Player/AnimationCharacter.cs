using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {

	public float speed = 0.0f;

	public float jumpForce = 800;

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






		if (Input.GetKey (KeyCode.RightArrow) == true || Input.GetKey (KeyCode.LeftArrow)) {
			animationOBJ.SetTime (1);
			animationOBJ.Play ("PlayerWALKanim");

			if (Input.GetKey (KeyCode.RightArrow) == true) {
				if (LookRight == false) {
					Flip ();
					LookRight = true;
				}

				transform.Translate (Vector3.right * (1/ speed));

			}else if( Input.GetKey (KeyCode.LeftArrow)) {
				if (LookRight == true) {
					Flip ();
					LookRight = false;
				}


				transform.Translate (Vector3.left * ( 1/ speed));
			}



		} else if (Input.GetKey (KeyCode.RightArrow) == false && Input.GetKey (KeyCode.LeftArrow) == false) {
			animationOBJ.Play ("PlayerIDLEanim");

		}

		if (Input.GetKey (KeyCode.UpArrow) == true && isOnGround == true) {
			animationOBJ.Play ("PlayerJUMPanim");
			m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			isOnGround = false;
		}


	}






	void Flip()
	{
		

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
