using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {

	public Text TextSpeed;

	// WheelCollider für die 4 Reifen;
	//Hier sind die 4 Reifen, die mein Auto braucht, um sich zu bewegen
	public WheelCollider vorne_links;
	public WheelCollider vorne_rechts;
	public WheelCollider hintern_links;
	public WheelCollider hintern_rechts;

	// um die Reifen auszurichten

	public Transform vl; // Front left
	public Transform vr; // front right
	public Transform hl; // back left
	public Transform hr;// back right


	// Um den Fahrzeug nach Vorne zu bewegen

	public float dreh; // torque
	public float speed; // Die Geschwindigkeit, die mit 0 anfängt
	public float maxSpeed = 160f; // Die Maximale Geschwindigkeit des Fahrzeugs 
	public int bremsen = 10000; // Bremsen 
	public float koef =8f; // die Koeffizient für die Beschleunigung des Fahrzeugs
	public float angleX= 10f; //Steering angle in degrees, always around the local y-axis.
	public float ass_ausricht =25f; //maximale assistente Ausrichtung, dient für Steuerung der vornen Reifen

	// Beleuchtung von vornen, hinteren Licht 
	public bool brem= false; // für Beleuchtung beim Bremsen
	public bool vorne= true; // Beleuchtung von vornen Lampen, während der Fahr
	public bool vor_un= false; // Aktiviert oder Beleuchtung von vorne_unteren Lampen

	// GameObject für Licht
	public GameObject Hinter_licht; //hineteres Licht Beleuchtung beim Bremsen
	public GameObject vorne_licht;
	public GameObject vorne_unt;



	void start(){
		// mittlere Masse des Fahrzeugs
		//centerOfMass is relative to the transform's position and rotation, but will not reflect the transform's scale!
		//rigidbody.centerOfMass = Vector3 (0, -2, 0);
		GetComponent<Rigidbody>().centerOfMass = new Vector3 (0, -2, 0);
	}

	void Update () {

		float v_pitch =speed/ maxSpeed +1.5f;
		//Musik des Motors während der Fahrt
		//Clamps gibt der Wert zwischen der minimale und maximal float Wert 
		GetComponent<AudioSource>().pitch = Mathf.Clamp(v_pitch,1f, 2.5f);

		//Hier kriegt man die zustandige Geschwindigkeit des Fahrzeugs

		//velocity.magnitude: RigiBody Geschwindigkeit;
		speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f; 
		TextSpeed.text = "V: "+ (int) speed+ " Km/H";

		//Hier ist für die Beschleunigung des Autos
		if(Input.GetKey(KeyCode.UpArrow) && speed< maxSpeed){
			// Mit GetAxis kriegt man die Werte( zwischen -1 und 1) auf die vertikale Axe und 0 per Default, falls man nichts gedruckt hat. 

			//Was passiert, wenn ich nicht bremse?
			if(!brem){
				
				vorne_links.brakeTorque = 0f;
				vorne_rechts.brakeTorque = 0f;
				hintern_links.brakeTorque =0f;
				hintern_rechts.brakeTorque = 0f;

				hintern_links.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
				hintern_rechts.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
				//vorne_links.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
				//vorne_rechts.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
			}

		}
		// Das Langsamerwerden, 
		if(!Input.GetKey(KeyCode.UpArrow) && !brem || speed > maxSpeed){
			// Braketorque bremse die Reife
			if(GetComponent<Rigidbody>().velocity.y > 0){

				hintern_links.motorTorque = 0;
				hintern_rechts.motorTorque = 0f;
			}
			//hintern_links.motorTorque =0f;
			//hintern_rechts.motorTorque = 0f;
			//vorne_links.motorTorque = 0f;
			//vorne_rechts.motorTorque = 0f;
			else{
				hintern_links.brakeTorque = 5000f; // stoppen die hintere Reifen bei Ruckhert 
				hintern_rechts.brakeTorque = 5000f;
				vorne_links.brakeTorque = vorne_rechts.brakeTorque = 0f;
			}
			//hintern_links.brakeTorque = bremsen *koef * Time.deltaTime;
			//hintern_rechts.brakeTorque = bremsen *koef * Time.deltaTime;
			//vorne_links.brakeTorque = bremsen *koef * Time.deltaTime;
			//vorne_rechts.brakeTorque = bremsen *koef * Time.deltaTime;
		}

		// Ausrichtung des Fahrzeugs
		float aa = (((angleX-ass_ausricht)/maxSpeed)*speed) + ass_ausricht;

		vorne_links.steerAngle = Input.GetAxis("Horizontal") * aa; // wird mit aa eingesetzt..
		vorne_rechts.steerAngle = Input.GetAxis("Horizontal") * aa;

		//Debug.Log (aa);

		// Bremsen des Fahrzeuges

		if (Input.GetKey (KeyCode.Space)) {

			brem = true;
			//SetActive: activates/Deactivates the GameObject.
			Hinter_licht.SetActive (true); // beim Bremsen wird das rotes Licht beleuchten
			hintern_links.brakeTorque = Mathf.Infinity; // Das Maximum von Bremsen 
			hintern_rechts.brakeTorque= Mathf.Infinity; // Mathf.Infinity give a representation of positive infinity (Read Only).
			vorne_links.brakeTorque= Mathf.Infinity;
			vorne_rechts.brakeTorque= Mathf.Infinity;

			vorne_rechts.brakeTorque = vorne_links.brakeTorque = 1000f;
			hintern_links.brakeTorque =hintern_rechts.brakeTorque =2000f;
			//hintern_rechts.brakeTorque = 100f;
		} 
		//
		else {
			brem = false; 
			Hinter_licht.SetActive (false);
			vorne_rechts.brakeTorque = vorne_links.brakeTorque = 0f;
			hintern_links.brakeTorque =hintern_rechts.brakeTorque =0f;
		}
			
		// Ruckkehrt
		if(Input.GetKey(KeyCode.DownArrow)){
			vorne_links.brakeTorque = 0f;
			vorne_rechts.brakeTorque = 0f;
			hintern_links.brakeTorque =0f;
			hintern_rechts.brakeTorque = 0f;

			hintern_links.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
			hintern_rechts.motorTorque = Input.GetAxis("Vertical") * dreh * koef *Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.B)) {
			
			vorne = true; 
			vorne_licht.SetActive (true);

			//hintern_links.brakeTorque = Mathf.Infinity; // Das Maximum von Bremsen 
			//hintern_rechts.brakeTorque = Mathf.Infinity;
			//vorne_links.brakeTorque = Mathf.Infinity;
			//vorne_rechts.brakeTorque = Mathf.Infinity;
			//hintern_links.motorTorque = 0;
			//hintern_rechts.motorTorque = 0;
		}
		else {
			vorne= true;
			vorne_licht.SetActive (true);
		}
		// Warnung Beleuchtung auf die Fahrtbahn
		if (Input.GetKey (KeyCode.W)) {
			vor_un = true;
			brem = true;
			vorne = true;
			vorne_unt.SetActive (true);
			vorne_licht.SetActive (true);
			Hinter_licht.SetActive (true);

			vorne_links.brakeTorque = 0f;
			vorne_rechts.brakeTorque = 0f;
			hintern_links.brakeTorque =0f;
			hintern_rechts.brakeTorque = 0f;
		}
		else {
			vor_un = false;
			brem = false;
			vorne = false;
			vorne_unt.SetActive (false);
			vorne_licht.SetActive (true);
			//Hinter_licht.SetActive (false);
		}
		// Rotation der Reifen
		vl.Rotate(vorne_links.rpm/60* 360 * Time.deltaTime, 0, 0); //rpm has a current wheel Rotation Speed, in rotations per Min
		vr.Rotate(vorne_rechts.rpm/60* 360 * Time.deltaTime, 0, 0);
		hl.Rotate(hintern_links.rpm/60* 360 * Time.deltaTime, 0, 0);
		hr.Rotate(hintern_rechts.rpm/60* 360 * Time.deltaTime, 0, 0);

		//SteerAngle Mesh Reifen

		// localEulerAngles: The rotation as Euler angles in degrees relative to the parent transform's rotation, 
		//The x, y, and z angles represent a rotation z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis
		vl.localEulerAngles= new Vector3(vl.localEulerAngles.x, vorne_links.steerAngle-vl.localEulerAngles.z, vl.localEulerAngles.z);
		vr.localEulerAngles= new Vector3(vr.localEulerAngles.x, vorne_rechts.steerAngle-vr.localEulerAngles.z, vr.localEulerAngles.z);
	}


}
