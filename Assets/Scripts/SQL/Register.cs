using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Register : MonoBehaviour {
	
	string registerURL = "http://salsabearstudios.com/tp_argz/register.php";
	public InputField Username, Password, Firstname, Lastname, Email;
	public Text Problem;
	private const string verifyDB = "&dbuser=codebear_coder&dbpass=J29kMMX&dbtable=codebear_argz";
	
	public void RegisterUser ()
	{
		StartCoroutine (handleRegister (Username.text, Password.text, Firstname.text, Lastname.text, Email.text));
	}
	
	IEnumerator handleRegister (string username, string password, string firstname, string lastname, string email)
	{
		string register_URL = registerURL + "?username=" + username + "&password=" + password + "&firstname=" + firstname + "&lastname=" + lastname + "&email=" + email + verifyDB;
		WWW registerReader = new WWW (register_URL);
		yield return registerReader;
		
		if (registerReader.error != null) {
			Problem.text = "Could not locate page";
		} else {
			if (registerReader.text == "registered") {
				Problem.text = "Registered";
				Application.LoadLevel ("MainMenu");
			} else {
				Problem.text = "Did not register";
			}
		}
	}
}