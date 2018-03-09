﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour {

	/*input fields*/

	public GameObject Nickname;
	public GameObject Email;
	public GameObject Password;
	public GameObject ConfPass;
	public GameObject Firstname;
	public GameObject LastName; //lastname object
	public Dropdown Gender;    
	public GameObject Age;
	public Dropdown Major;      
	public Dropdown SchoolYear;
	public Dropdown School;


	private string nickname;
	private string email;
	private string password;
	private string confPass;
	private string firstname;
	private string lastname;   //lastname
	private string age;
	private string selectedGender; 
	private string selectedMajor;
	private string selectedSchoolyear;
	private string selectedSchool;


	//flags
	private  bool isGenderValid = false; 
	private  bool isSchoolYearValid = false; 
	private bool isMajorValid = false;
	private bool isSchoolValid = false;

	/*Dropdown object lists*/

	List<string> genderList = new List<string>(){"Gender", "Male", "Female", "Other"};
	List<string> schoolYearList = new List<string>(){"School Level", "Freshman", "Sophmore", "Junior", "Senior"};
	List<string> majorList = new List<string>(){"Major", "Aerospace Engineering",
		"Applied Analytics",
		"Applied Mathematics",
		"Applied Physics",
		"Architecture",
		"Architectural Engineering",
		"Astrophysics",
		"Behavioral Health and Wellness",
		"Bioanalytical Chemistry",
		"Biochemistry",
		"Bioinformatics",
		"Biology",
		"Biology and Psychology",
		"Biomedical Engineering",
		"Business Administration",
		"Chemical Engineering",
		"Chemistry",
		"Civil Engineering",
		"Communication",
		"Computer Engineering",
		"Computer Information Systems",
		"Computer Science",
		"Digital Humanities",
		"Electrical Engineering",
		"Engineering Management",
		"Environmental Chemistry",
		"Forensic Chemistry",
		"Global Studies",
		"Humanities",
		"Information Technology and Management",
		"Industrial Technology and Management",
		"Materials Science and Engineering",
		"Mechanical Engineering",
		"Medicinal Chemistry",
		"Molecular Biochemistry and Biophysics",
		"Physics",
		"Psychological Science",
		"Social and Economic Development Policy",
		"Undecided Engineering",
		"Undecided Human Science",
		"Undecided Science"

	};
	List<string> schoolList = new List<string>(){"School","Broward College (Davie)", "Florida Atlantic University (Boca Raton)",
		"Florida Gulf Coast University (Ft. Myers)",
		"Florida International University (Miami)",
		"Florida Polytechnic University (Lakeland)",
		"Florida State University (Tallahassee)" ,
		"Miami Dade College (Miami)",
		"New College of Florida (Sarasota)",
		"North Florida Community College (Madison)",
		"University of Central Florida (Orlando)",
		"University of Florida (Gainesville)",
		"University of North Florida (Jacksonville)",
		"University of South Florida (Tampa)",
		"University of West Florida (Pensacola)"

	};

	//Error messages objects
	public Text firstnameError;
	public Text lastnameError;       //lastnameError object
	public Text passError; 
	public Text confPassError ;
	public Text emError;
	public Text ageError; 
	public Text genderError;
	public Text majorError;
	public Text schoolError;
	public Text schoolYearError;


	void Start(){

		/*initilizing each dropdown with lists */

		Gender.AddOptions (genderList);
		SchoolYear.AddOptions (schoolYearList);
		Major.AddOptions (majorList);
		School.AddOptions (schoolList);


	}



	/* Get options in dropdonw lists */

	public void genderOptions(int i){

		selectedGender = genderList[i];
		print ("Option selected : " + selectedGender);
		if (selectedGender != genderList [0]) {
			isGenderValid = true;
		} else {
			isGenderValid = false;
		}

	}

	public void schoolYearOptions(int i){

		selectedSchoolyear = schoolYearList[i];
		print ("Option selected : " + selectedSchoolyear);
		if (selectedSchoolyear != schoolYearList [0]) {
			isSchoolYearValid = true;
		} else {
			isSchoolYearValid = false;
		}
	}

	public void majorOptions(int i){

		selectedMajor = majorList[i];
		print ("Option selected : " + selectedMajor);
		if (selectedMajor != majorList [0]) {
			isMajorValid = true;
		} else {
			isMajorValid = false;
		}
	}

	public void schoolOptions(int i){

		selectedSchool = schoolList[i];
		print ("Option selected : " + selectedSchool);
		if (selectedSchool != schoolList [0]) {
			isSchoolValid = true;
		} else {
			isSchoolValid = false;
		}
	}

	/*   Loading next scene  for a valid player. 
	 * Is used by "Create account" object in the scene*/

	public void LoadingScene(){

		bool isNameValid = Validation.validateName(firstname);
		bool isEmailValid = Validation.validateEmail(email);
		bool isPasswordValid = Validation.validatePassword(password);
		bool isPasswordConf = Validation.confirmPassword(password, confPass);
		bool isAgeValid = Validation.validateAge (age);
		/*bool isLastnameValid = Validation.validateLastname(lastname);*/

		if (isNameValid && isEmailValid && isPasswordValid && isPasswordConf && isGenderValid 
			&& isSchoolYearValid && isMajorValid  && isSchoolValid /* && isLastnameValid */ ) {

			RegisterPlayer.RegisterPlayerBttn (nickname, password, "Level_01");

		}else {
			print ("invalid player");

			//***just missing the validation for last name***

			if (!isNameValid) {
				errorMessages.nameError (firstnameError, isNameValid);
			} else {
				errorMessages.nameError (firstnameError , isNameValid);
			}

			if (!isEmailValid) {
				errorMessages.emailError (emError, isEmailValid);
			} else {
				errorMessages.emailError (emError, isEmailValid);
			}

			if (!isPasswordValid) {
				errorMessages.passwordError (passError, isPasswordValid);
			} else {
				errorMessages.passwordError (passError, isPasswordValid);
			}

			if (!isPasswordConf) {
				errorMessages.confPasswordError (confPassError, isPasswordConf);
			} else {
				errorMessages.confPasswordError (confPassError, isPasswordConf);
			}

			if (!isAgeValid) {
				errorMessages.AgeError (ageError, isAgeValid);
			} else {
				errorMessages.AgeError (ageError, isAgeValid);
			}

			if (!isGenderValid) {                         // first option (nothing selected)
				errorMessages.GenderError (genderError, isGenderValid);
			}else{
				errorMessages.GenderError (genderError, isGenderValid);
			}

			if (!isMajorValid) {                         // first option (nothing selected)
				errorMessages.MajorError (majorError, isMajorValid);
			}else{
				errorMessages.MajorError (majorError, isMajorValid);
			}

			if (!isSchoolValid) {                         // first option (nothing selected)
				errorMessages.SchoolError (schoolError, isSchoolValid);
			}else{
				errorMessages.SchoolError (schoolError, isSchoolValid);
			}

			if (!isSchoolYearValid) {                         // first option (nothing selected)
				errorMessages.SchoolYearError (schoolYearError, isSchoolYearValid);
			}else{
				errorMessages.SchoolYearError (schoolYearError, isSchoolYearValid);
			} 

			/* if (!isLastnameValid) {                        
				errorMessages.lastNameError (lastnameError, isLastnameValid);
			}else{
				errorMessages.lastNameError (lastnameError, isLastnameValid);
			} */


		}


	}


	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)){
			if (Nickname.GetComponent<InputField> ().isFocused) {
				Email.GetComponent<InputField> ().Select ();
			}
			if (Email.GetComponent<InputField> ().isFocused) {
				Password.GetComponent<InputField> ().Select ();
			}
			if (Password.GetComponent<InputField> ().isFocused) {
				ConfPass.GetComponent<InputField> ().Select ();
			}
			if (ConfPass.GetComponent<InputField> ().isFocused) {
				Firstname.GetComponent<InputField> ().Select ();
			}
			if (Firstname.GetComponent<InputField> ().isFocused) {
				LastName.GetComponent<InputField> ().Select ();
			}
			if (LastName.GetComponent<InputField> ().isFocused) {
				Age.GetComponent<InputField> ().Select ();
			}


		}

		//filling string variabls with game objects

		nickname = Nickname.GetComponent<InputField> ().text;
		email = Email.GetComponent<InputField> ().text;
		password = Password.GetComponent<InputField> ().text;
		confPass = ConfPass.GetComponent<InputField> ().text;
		firstname = Firstname.GetComponent<InputField> ().text;
		lastname = LastName.GetComponent<InputField> ().text;
		age = Age.GetComponent<InputField> ().text;


		//Loading next scence if hit return for a valid player

		if(Input.GetKeyDown(KeyCode.Return) ){ 

			LoadingScene ();
		}
	}




}
