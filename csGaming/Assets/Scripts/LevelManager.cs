using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//this method allows flow among scenes 
	public void Loading(string name){
		
			SceneManager.LoadScene (name);
			print ("Scene Loaded");


	}



}