using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour {

	public GameObject Name;
	public GameObject Nickname;
	public GameObject Email;
	public GameObject Major;
	public GameObject Gender;
	public GameObject Age;
	public GameObject Password;
	public GameObject ConfPass;

	private string name;
	private string nickname;
	private string email;
	private string major;
	private string gender;
	private string age;
	private string password;
	private string confPass;



	private bool EmailValid = false;



	// Use this for initialization
	void Start () {

	}


	/*method used with the same puspuse but for the clicling action */

	public void Loading(string name){

		if (name != "" && nickname != "" && email != "" && major != "" && gender != "" && age != "" 
			     && password != "" && confPass != "") { 

			if ((email.Contains ("@")) == true) {
				SceneManager.LoadScene (name);
				print ("Scene Loaded");
				EmailValid = true;

			} else {
				print ("Invalid Email. Missing @");
			}
		} else {
			print ("Missing Fields");
		}

	}





	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)){
			if (Name.GetComponent<InputField> ().isFocused) {
				Nickname.GetComponent<InputField> ().Select ();
			}
			if (Nickname.GetComponent<InputField> ().isFocused) {
				Email.GetComponent<InputField> ().Select ();
			}
			if (Email.GetComponent<InputField> ().isFocused) {
				Major.GetComponent<InputField> ().Select ();
			}
			if (Major.GetComponent<InputField> ().isFocused) {
				Gender.GetComponent<InputField> ().Select ();
			}
			if (Gender.GetComponent<InputField> ().isFocused) {
				Age.GetComponent<InputField> ().Select ();
			}
			if (Age.GetComponent<InputField> ().isFocused) {
				Password.GetComponent<InputField> ().Select ();
			}
			if (Password.GetComponent<InputField> ().isFocused) {
				ConfPass.GetComponent<InputField> ().Select ();
			}
		}

		//filling string variabls with game objects
		name = Name.GetComponent<InputField> ().text;
		nickname = Nickname.GetComponent<InputField> ().text;
		email = Email.GetComponent<InputField> ().text;
		major = Major.GetComponent<InputField> ().text;
		gender = Gender.GetComponent<InputField> ().text;
		age = Age.GetComponent<InputField> ().text;
		password = Password.GetComponent<InputField> ().text;
		confPass = ConfPass.GetComponent<InputField> ().text;


		if(Input.GetKeyDown(KeyCode.Return)){ 
			//if all fileds are filled
			if (name != "" && nickname != "" && email != "" && major != "" 
				&& gender != "" && age != "" && password != "" && confPass != "") { 

				//valid email form
				if ((email.Contains ("@")) == true) {
					SceneManager.LoadScene ("Level_01");
					print ("Scene Loaded");
					EmailValid = true;

				} else {
					print ("Invalid Email. Missing @");
				}

		      } else {
				print ("Missing Fields");
			}
		}



	}

}

