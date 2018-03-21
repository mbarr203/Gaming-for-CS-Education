using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthenticatePlayer : MonoBehaviour {

	public static void AunthenticatePlayerBttn(string username, string password, string scene) {
		new GameSparks.Api.Requests.AuthenticationRequest().
			SetUserName(username).
			SetPassword(password).
			Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
					SceneManager.LoadScene(scene);
				} else {
					/**Samira, add error messages similar to the ones you created
					 * for the signUp scene consider 

					/**Your code goes here**/
					Debug.Log("Error Authenticating Player...");
				}
			});
	}
}
