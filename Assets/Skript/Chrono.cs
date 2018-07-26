using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour {
	public float zeit;
	public float zeitInter = 10;
	public float tick;


	// come before the start method
	void Awake () {
		zeit = (int)Time.time;
		tick = zeitInter;
	}
	
	// Update is called once per frame
	//Mathf.Floor git die größte Zeit aus
	void Update () {
		GetComponent<Text> ().text = string.Format("{0:0}:{1:00}", Mathf.Floor(zeit/60), zeit % 60);
		zeit = (int)Time.time;

		if (zeit == tick) {

			tick = zeit + zeitInter;
			zeige ();
		
		}
	}
	void zeige(){
		Debug.Log ("Vorsicht!!!");
	}
}

