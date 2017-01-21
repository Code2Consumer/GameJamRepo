using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitScript : MonoBehaviour {

	public float Puissance; //Force du paralax
	public Transform BruitLight; //Force du paralax
	public bool LightSpawned; //Force du paralax

	// Use this for initialization
	void Start () {
		LightSpawned = false ;
		if(Puissance==null){
			Puissance = 5.0F;
		}
		transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.localScale.x <= Puissance/10 ){
			transform.localScale += new Vector3(0.01F, 0.01F, 0);
		}else{
			//GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Destroy(gameObject);
		}
	}

	public void setPower(float power){
		Puissance = power;
	}
	//    GetComponent(MeshRenderer).enabled = false;
	void OnTriggerEnter2D(Collider2D col) {
		col.GetComponent<SpriteRenderer>().enabled = true;
    }

}
