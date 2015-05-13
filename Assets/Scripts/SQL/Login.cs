using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour {
	string loginURL = "http://salsabearstudios.com/tp_argz/login.php";
	private const string verifyDB = "&dbuser=codebear_coder&dbpass=J29kMMX&dbtable=codebear_argz";

	public Text Problem;
	public InputField Username, Password;
	
	public void OnClick ()
	{
		StartCoroutine (handleLogin (Username.text, Password.text));
	}
	
	IEnumerator handleLogin (string user, string pass)
	{
		Problem.text = "Checking username and password..";
		string login_URL = loginURL + "?username=" + user + "&password=" + pass + verifyDB;
		Debug.Log (login_URL);
		WWW loginReader = new WWW (login_URL);
		yield return loginReader;
		
		if (loginReader.error != null) {
			Problem.text = "Could not locate page";
		} else {
			if (loginReader.text == "right") {
				Problem.text = "Logged In";
				Application.LoadLevel ("MainMenu");
			} else {
				Problem.text = "invalid user/pass";
			}
		}
	}
}