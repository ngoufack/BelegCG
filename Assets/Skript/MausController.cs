using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Im PlayMode wird mein Maus Cursor sich verstecken
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		// Wenn ich auf die Task V drucke, wird mein Maus wieder erscheinen

		if (Input.GetKey (KeyCode.V))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
