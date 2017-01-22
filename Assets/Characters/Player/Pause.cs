using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {


	private int isLock ;

	//boolean ( 1 ou 0 ) pour savoir si GUI est afficher ou non
	public bool showGUI = false;

	//GameObject que j'ai appeler canvas parce qu'il va recuperer le canvas
	public GameObject canvas;

	public void Start(){


		isLock = 1;
		//Des que le joueur a la main on recupere l'objet Canvas dans la variable qui va bien
		canvas = GameObject.Find ("Canvas");
	}

	//Cette fonction est appelé enboucle permet de prendre en compte des modification
	public void Update(){

		//Si le joueur appuie sur Echape
		if (Input.GetButton ("StartButton")) {
			//On inverse la valeur de showGUI c'est a dire que si il est en jeu cela met pause et si il est en pause cela revien sur le jeu
			// le ! permet de dire l'inverse
			if (isLock == 1) {
				showGUI = !showGUI;
				isLock = 0;
			}

		} else {
			isLock = 1;
		}

		//Si showGUI a été mis a 1 dans la ligne du dessus
		if (showGUI == true) {
			//On l'active et on arrete le temp
			canvas.SetActive (true);
			Time.timeScale = 0;
		} else {
			//Sinon si il a été mis a 0 on l'arrete et on relance le temp en normal ( 1 )
			canvas.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//Des qu'on charge le niveau 
	public void OnLevelWasLoaded(){
		//on recupere l'objet Canvas dans la variable qui va bien
		canvas = GameObject.Find ("Canvas");
	}

	public void onResume(){
		showGUI = false;
	}

	public void onQuit(){
		Application.LoadLevel ("Menu");
	}

	//Il faut bien reperer qu'il y'a deux fois la recuparation du Canvas
	//Car si le joueur vien d'une autre scene son code sera deja executé
	//La fonction OnLevelWasLoaded permet de rectifié sa 
}
