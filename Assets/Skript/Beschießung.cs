using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beschießung : MonoBehaviour {

	public GameObject pro; // Kugel Projektile
	public int kugel_kraft = 50;
	public AudioClip beschiess_sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Wenn ich mich in Playmode befinde und auf die Task T drucke, dann kriege ich eine Beschießung Sound...
		if (Input.GetKeyDown (KeyCode.T)) 
		{
			// Quaternion clone the original object and returns the clone..
			GetComponent<AudioSource> ().PlayOneShot (beschiess_sound);	
			GameObject kugel = Instantiate (pro, transform.position, Quaternion.identity)as GameObject;
			kugel.GetComponent<Rigidbody> ().velocity = transform.forward * kugel_kraft; 

			//nach 3 Sekunden wird mein Kugel verschwinden, wenn es genau eine Collision mit einnem GameObject eingetreten ist.. 
			Destroy (kugel, 3f);
		}
	}
}
