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

	public Text assk1;
	public Text assk2;


	/* checks length for password */

	private bool passwordCorrectLength(){

		if (password != "") {
			if (password.Length >= 8 && password.Length <= 15) {
				return true;
			}
		}
		return false;

	}

	/* checks if password contains at least one number */

	private bool passwordContainsNumber(){


		if (password != "") {

			for(int i = 0 ; i < password.Length; i++) {
				int val ;
				if (Int32.TryParse (Convert.ToString(password[i]), out val) == true ) {

					return true;
				}
			}
		} 
		return false;

	}



	/*method used to load the scene */

	public void Loading(string name){

		if (nickname != "" && passwordContainsNumber() && passwordCorrectLength() ) { 

			SceneManager.LoadScene (name);
			print ("Scene Loaded");

		} 
		else {
			print ("Not Scene Loaded");

			if (! passwordContainsNumber() || !passwordCorrectLength()) {  
				print ("Incorret Password");
				assk2.text = "x";
				assk2.color = Color.red;
			} else {

				assk2.text = " ";
			}

			if (nickname == "") {
				print ("Missing Nickname");
				assk1.text = "x";
				assk1.color = Color.red;
			} else {
				assk1.text = " ";

			}
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

		if( Input.GetKeyDown(KeyCode.Return) ) { 

			Loading ("Level_01");
		}



	}

}

