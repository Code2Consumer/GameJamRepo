using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitScript : MonoBehaviour {

	public float Puissance; //Force du paralax

	// Use this for initialization
	void Start () {
		if(Puissance==null){
			Puissance = 5.0F;
		}
		transform.localScale += new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x <= Puissance/10 ){
			transform.localScale += new Vector3(0.01F, 0.01F, 0);
		}else{
			Destroy(gameObject);
		}
	}

	//    GetComponent(MeshRenderer).enabled = false;

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("ee");
		
		col.GetComponent<SpriteRenderer>().enabled = true;
    }

}
