using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchalterCar : MonoBehaviour {
	private bool b_car =false; 
	//public Text info;
	public GameObject spieler; // Spieler 
	public GameObject car; // Auto


	void EintrittInTrigger (Collider one) {
		if(one.tag== "Player")
		{ // Info Anzeige aktivieren
			//info.enabled= true;
			
		}
	}
	void AusgangInTrigger (Collider one) {
		if(one.tag== "Player")
		{ 
			// Info Anzeige desaktvivieren
			//info.enabled= false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			b_car = !b_car;
			if (b_car) {
				//info.enabled = false;
				spieler.SetActive (false);
				car.GetComponent<Control> ().enabled = true; // Aktivation von meinem Car Controller
				car.GetComponent<AudioSource> ().enabled = true; // Aktivation der AudioSource
				car.GetComponent<Rigidbody> ().isKinematic = false; // Deaktivation der isKinematic von Auto

			} 
			else 
			{    //wenn meine Geschwindigkeit (speed) kleine als 0.5 ist, dann kann der Spieler einfach austeigen
				if (car.GetComponent<Control> ().speed < 0.5) {
					spieler.SetActive (true);
					//meiner Spieler befindet sich an der gleicher Position mit meinem Auto, aber in der rechten Seite mit 5.75 float wert...
					spieler.transform.position = car.transform.position - (Vector3.right * 5.75f);
					car.GetComponent<Control> ().enabled = false;
					car.GetComponent<AudioSource> ().enabled = false;
					car.GetComponent<Rigidbody> ().isKinematic = true;
					
				}
				//info.enabled = true;

			}
		}
		
	}
}
