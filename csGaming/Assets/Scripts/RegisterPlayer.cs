using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterPlayer : MonoBehaviour {

	public static void RegisterPlayerBttn(string displayName, string password, string scene)
	{
		Debug.Log ("Registering Player...");
		new GameSparks.Api.Requests.RegistrationRequest ()
			.SetDisplayName (displayName)
			.SetUserName (displayName)
			.SetPassword (password)
			.Send ((response) => {
					if(!response.HasErrors)
					{
						Debug.Log("Player Registered \n User Name: " + response.DisplayName);
						SceneManager.LoadScene(scene);
						
					}
					else
					{
						Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
					}
		});
	}
}
