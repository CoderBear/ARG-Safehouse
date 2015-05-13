using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VerifyUserName : MonoBehaviour {
	private string verifyURL = "http://salsabearstudios.com/tp_argz/nameverify.php";
	private const string verifyDB = "&dbuser=codebear_coder&dbpass=J29kMMX&dbtable=codebear_argz";
	public InputField Username, Useremail;
	public Text DebugField, Problem, VerifyStatus;
	
	public Button RegisterButton;
	public Toggle VerifyToggle;
	
	public void VerifyUserInfo ()
	{
		StartCoroutine (handleVerify (Username.text, Useremail.text));
	}
	
	IEnumerator handleVerify (string userName, string mail)
	{
		Problem.text = "Checking if username is available";
		string verify_URL = verifyURL + "?username=" + userName + "&email=" + mail + verifyDB;

		WWW verifyReader = new WWW (verify_URL);
		yield return verifyReader;
		
		if (verifyReader.error != null) {
			Problem.text = "Could not locate page";
		} else {
			Problem.text = "Displaying Results";
#if UNITY_EDITOR
			DebugField.text = verifyReader.text;
#endif
			if (verifyReader.text == "available") {
				VerifyToggle.isOn = true;
				VerifyStatus.text = "Available";
				RegisterButton.gameObject.SetActive(true);
			} else {
				VerifyStatus.text = "Unavailable";
			}
		}
	}
}