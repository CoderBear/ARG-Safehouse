using UnityEngine;
using System.Collections;

public class GotoRegister : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public void StartRegistration() {
		Application.LoadLevel ("RegisterMenu");
	}
}