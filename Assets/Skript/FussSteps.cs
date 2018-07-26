using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FussSteps : MonoBehaviour {
	
	private CharacterController c; // CharakterController von Spieler

	// Use this for initialization
	void Start () {
		c= GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		//hier wird meine AudioSource mit meinem CharakterController (Laufen) zusammen eingesetzt.
		if(c.isGrounded && c.velocity.magnitude > 1f &&GetComponent<AudioSource>().isPlaying==false && !Input.GetKey(KeyCode.L))
			
			//isGrounded: Indicates whether the wheel currently collides with something (Read Only).
		{
			//die Volume der AudioClip, wenn meiner Spieler läuft.
			GetComponent<AudioSource>().volume =Random.Range(0.6f, 1f);
			GetComponent<AudioSource>().pitch = Random.Range(1.21f, 1.25f);
			GetComponent<AudioSource>().Play();
		}
		if(c.isGrounded && c.velocity.magnitude > 1f &&GetComponent<AudioSource>().isPlaying==false && Input.GetKey(KeyCode.L))
		{
			GetComponent<AudioSource>().volume =  Random.Range(0.8f, 1f);
			GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);
			GetComponent<AudioSource>().Play();
		}
	}
}
