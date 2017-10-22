using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject impressum;

	public void startGame(){
		SceneManager.LoadScene("main");
	}

	public void showImpressum(){
		mainMenu.SetActive (false);
		impressum.SetActive (true);
	}

	public void hideImpressum(){
		mainMenu.SetActive (true);
		impressum.SetActive (false);
	}

	public void exitGame(){
		Application.Quit ();
	}
}
