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

	public bool isRamping;

	private bool CanRamping;

	private Animator animationOBJ;
	private Rigidbody2D m_Rigidbody2D;

	private bool hasPlayed = false;
	private bool LookRight;

	public float lastStep = 0;
	public float stepDuration = 0.2F;
	public float DefaultStepPower ;

	void PlayWaves(){
		if(lastStep==0){
			lastStep = Time.time;
		}
		if(Time.time-lastStep >= stepDuration){
			Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
			
			Transform bruitClone = Instantiate(gameObject.GetComponent<CrierScript>().Bruit,  SpawnPosition, transform.rotation);
			bruitClone
				.GetComponent<BruitScript>()
				.setPower(DefaultStepPower);
				
				bruitClone
				.GetComponent<BruitScript>()
				.isStep();
				//Destroy(bruitClone.FindChild("Onde2"));
				//Destroy(bruitClone.FindChild("Onde3"));

			Transform bruitLightClone = Instantiate(gameObject.GetComponent<CrierScript>().BruitLight,  SpawnPosition, transform.rotation);
			bruitLightClone
				.GetComponent<BruitLightScript>()
				.Puissance = DefaultStepPower;
			lastStep=Time.time;
		}
	}

	// Use this for initialization
	void Start () {



		if(DefaultStepPower==0){
			DefaultStepPower = 7;
		}
		animationOBJ = GetComponentInChildren<Animator> ();
		isOnGround = true;
		LookRight = true;
		isScreaming = false;
		isThrowing = false;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		isRamassing = false;
		animationOBJ.SetTime (1);
		isRamping = false;



	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			//Destroy(other.gameObject);
			isOnGround = true;
			isRunning = false;
			Debug.Log ("DESTROY");
		}
		if (other.gameObject.tag == "TriggerRampe" && isRamping == false) {
			CanRamping = true;
		}




	}


	void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject.tag == "TriggerRampe" && isRamping == true) {
			isRamping = false;
			CanRamping = false;

		}
	}


	
	// Update is called once per frame
	void Update () {

		if (CanRamping == true &&  Input.GetButton("ButtonY")) {
			isRamping = true;
		}
		if (isRamping == false) {

		
			if (isRamassing == false && isThrowing == false) {
				
				if (Input.GetAxis("Horizontal") > 0.04f || Input.GetAxis("Horizontal") < -0.04f ) {
					
					GetComponent<AnimationCharacter> ().isScreaming = false;
					isRunning = false;
					if (isOnGround == true &&  Input.GetButton("ButtonA") == false ) {
						animationOBJ.Play ("PlayerWALKanim");
						//Walking
						PlayWaves ();
						isRunning = true;
						if (hasPlayed == false) {
							Debug.Log ("Detected");
							GetComponent<AudioSource> ().Play ();

						//	AudioSource aido = (AudioSource)GameObject.Find ("BodyfallHuman_forest");
							//aido.Play ();
							hasPlayed = true;
						}

						if (!GetComponent<AudioSource> ().isPlaying) {
							hasPlayed = false;
						}
						//	this.GetComponent<Rigidbody2D> ().isKinematic = false;

					}


					if (Input.GetAxis("Horizontal") > 0.04f ) {
						if (LookRight == false) {
							Flip ();
							LookRight = true;
						}

						m_Rigidbody2D.velocity = new Vector2 (speed, m_Rigidbody2D.velocity.y);

					} else if (Input.GetAxis("Horizontal") < -0.04f) {
						if (LookRight == true) {
							Flip ();
							LookRight = false;
						}


						m_Rigidbody2D.velocity = new Vector2 (-speed, m_Rigidbody2D.velocity.y);
					}



				} else if (Input.GetAxis("Horizontal") > -0.04f && Input.GetAxis("Horizontal") < 0.04f && isScreaming == false && isOnGround == true && Input.GetButton("ButtonA") == false) {
					animationOBJ.Play ("PlayerIDLEanim");
					isRunning = false;
					m_Rigidbody2D.velocity = new Vector2 (0, m_Rigidbody2D.velocity.y);

				}

				if ((Input.GetKey (KeyCode.UpArrow) || Input.GetButton("ButtonA")) == true && isOnGround == true) {
					animationOBJ.Play ("PlayerJUMPanim");
					isRunning = false;
					//m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));

					isOnGround = false;

					m_Rigidbody2D.velocity = new Vector2 (0, jumpForce);
					//transform.Translate (Vector3.up * ( Time.deltaTime * jumpForce));

				}

			}
		} else {


			animationOBJ.Play ("PlayerRAMPanim");
			GetComponent<BoxCollider2D> ().size.Set (0.5f, 0.5f);
			if (LookRight == true) {
				m_Rigidbody2D.velocity = new Vector2 (speed, m_Rigidbody2D.velocity.y);
			} else {
				m_Rigidbody2D.velocity = new Vector2 (-speed, m_Rigidbody2D.velocity.y);
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


