using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {

	public float speed = 0.0f;

	public float jumpForce = 15;

	public bool isOnGround;

	public bool isScreaming;

	public bool isRamassing;

	public bool isThrowing;

	public bool isGetting;

	private bool isRunning;  

	private Animator animationOBJ;
	private Rigidbody2D m_Rigidbody2D;

	private bool hasPlayed = false;


	private bool LookRight;

	// Use this for initialization
	void Start () {

		animationOBJ = GetComponentInChildren<Animator> ();
		isOnGround = true;
		LookRight = true;
		isScreaming = false;
		isThrowing = false;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		isRamassing = false;
		animationOBJ.SetTime (1);



	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			//Destroy(other.gameObject);
			isOnGround = true;
			isRunning = false;
			Debug.Log ("DESTROY");
		}

	}

	
	// Update is called once per frame
	void Update () {

		if (isRamassing == false && isThrowing == false) {
			




			if (Input.GetKey (KeyCode.RightArrow) == true || Input.GetKey (KeyCode.LeftArrow)) {
				
				GetComponent<AnimationCharacter> ().isScreaming = false;
				isRunning = false;
				if (isOnGround == true && Input.GetKey (KeyCode.UpArrow) == false) {
					animationOBJ.Play ("PlayerWALKanim");
					isRunning = true;
					if (hasPlayed == false) {
						Debug.Log ("Detected");
						GetComponent<AudioSource> ().Play ();
						hasPlayed = true;
					}


					if (!GetComponent<AudioSource> ().isPlaying) {
						hasPlayed = false;
					}
					//	this.GetComponent<Rigidbody2D> ().isKinematic = false;

				}


				if (Input.GetKey (KeyCode.RightArrow) == true) {
					if (LookRight == false) {
						Flip ();
						LookRight = true;
					}

					m_Rigidbody2D.velocity = new Vector2 (speed, m_Rigidbody2D.velocity.y);

				} else if (Input.GetKey (KeyCode.LeftArrow)) {
					if (LookRight == true) {
						Flip ();
						LookRight = false;
					}


					m_Rigidbody2D.velocity = new Vector2 (-speed, m_Rigidbody2D.velocity.y);
				}



			} else if (Input.GetKey (KeyCode.RightArrow) == false && Input.GetKey (KeyCode.LeftArrow) == false && isScreaming == false && isOnGround == true && Input.GetKey (KeyCode.UpArrow) == false ) {
				animationOBJ.Play ("PlayerIDLEanim");
				isRunning = false;
				m_Rigidbody2D.velocity = new Vector2 (0, m_Rigidbody2D.velocity.y);

			}

			if (Input.GetKey (KeyCode.UpArrow) == true && isOnGround == true) {
				animationOBJ.Play ("PlayerJUMPanim");
				isRunning = false;
				//m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));

				isOnGround = false;

				m_Rigidbody2D.velocity = new Vector2 (0, jumpForce);
				//transform.Translate (Vector3.up * ( Time.deltaTime * jumpForce));

			}

		}


	}

	public Animator getAnimator()
	{
		return animationOBJ;
	}

	public bool getLookRight()
	{
		return LookRight;
	}

	public bool getIsOnGround()
	{
		return isOnGround;
	}
	public bool getIsRunning()
	{
		return isRunning;
	}


	void Flip()
	{
		

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}


