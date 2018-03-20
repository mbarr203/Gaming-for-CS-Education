using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterPlayer : MonoBehaviour {

	public static void RegisterPlayerBttn(string displayName, string password, string scene,
										  string email, string fname, string lname, int age,
										  string gender, string school, string major,
										  string schoolYear)
	{
		new GameSparks.Api.Requests.RegistrationRequest ()
			.SetDisplayName (displayName)
			.SetUserName (displayName)
			.SetPassword (password)
			.Send ((response) => {
					if(!response.HasErrors)
					{
						Debug.Log("Player Registered \n User Name: " + response.DisplayName);

						SavePlayerData.SaveData (email, fname, lname, age, gender,
												 school, major, schoolYear);
					
						SceneManager.LoadScene(scene);
						
					}
					else
					{
						/**Samira help!**/
						Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
					}
		});
	}
}
