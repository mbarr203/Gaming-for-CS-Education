using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterPlayer : MonoBehaviour {

	public static void RegisterPlayerBttn(string displayName, string password, string scene,
										  string email, string fname, string lname, int age,
										  string gender, string school, string major, string schoolYear, Text textError, 
		GameObject panel, GameObject start, GameObject goBack, Text succefullReg )
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
					
				    	

					    // after all is checked a ConfirmationRegistration form is displayed

					    RegistrationConfirmation.Confirmation(panel, start, goBack, succefullReg);
					    textError.text = " ";
						
					}
					else
					{
					    /**it handles when username is not unique**/

						Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
					    textError.text = "Username has been taken";
					    textError.color = Color.red;
					}
		});
	}
}
