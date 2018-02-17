using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour {


	public GameObject Nickname;
	public GameObject Password;

	private string nickname;
	private string password;

	private string from;




	void Start () {

	}


	/*method used with the same puspuse but for the clicling action */

	public void Loading(string name){

		if ( nickname != ""  && password != "" ) { //add functuonality to email

			SceneManager.LoadScene (name);
			print ("Scene Loaded");
		} else {
			print ("Missing Fields");
		}

	}

		

	void Update () {

		 /*allows users to press <tab> to change field*/

		if(Input.GetKeyDown(KeyCode.Tab)){
			if (Nickname.GetComponent<InputField> ().isFocused) {
				Password.GetComponent<InputField> ().Select ();
			}
		}

         /*filling string variabls with game objects*/

		nickname = Nickname.GetComponent<InputField> ().text;
		password = Password.GetComponent<InputField> ().text;

	   /*loads next scene by pressing <Return>*/

		if(Input.GetKeyDown(KeyCode.Return)){ 
			//if all fields full
			if ( nickname != ""  && password != "" ) { 
				SceneManager.LoadScene ("Level_01");
				print ("Scene Loaded");
			} else {
				print ("Missing Fields");
			}
		}



	}

}

