using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Validation : MonoBehaviour {
	private const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

	private const string MatchNamePattern = @"^([ \u00c0-\u01ffa-zA-Z'\-])+$";
	private const string MatchPasswordPattern = @"^([a-zA-Z0-9@*#]{8,15})$"; // password must be between 8 and 15 characters and contain a numeric value


	public static bool validateEmail(string email) {
		if (email != "")
		{
			return Regex.IsMatch(email, MatchEmailPattern);
		}
		return false;
	}

	public static bool validateName(string name) {
		if (name != "")
		{
			print (Regex.IsMatch(name, MatchNamePattern));
			return Regex.IsMatch(name, MatchNamePattern);
		}
		return false;
	}

	public static bool validatePassword(string password) {
		if (password != "")
		{
			return Regex.IsMatch(password, MatchPasswordPattern);
		}
		return false;
	}

	public static bool confirmPassword(string password, string confPassword) {
		return password.Equals(confPassword);
 	}

}
