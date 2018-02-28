using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
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


		if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)){ 
			//if all fileds are filled
			bool isNameValid = Validation.validateName(name);
			bool isEmailValid = Validation.validateEmail(email);
			bool isPasswordValid = Validation.validatePassword(password);
			bool isPasswordConf = Validation.confirmPassword(password, confPass);

			if (isNameValid && isEmailValid && isPasswordValid && isPasswordConf) {
				RegisterPlayer.RegisterPlayerBttn(nickname, password, "Level_01");
			}
			else
				print("invalid player");
		}
	}
}

