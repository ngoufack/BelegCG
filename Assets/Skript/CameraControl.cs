using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour 
{
	//SerializeField: Force Unity to serialize a private field.

	//When Unity serializes your scripts, it will only serialize public fields. If in addition to that you also want Unity to serialize one of your private fields you can add the SerializeField attribute to the field.

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offsetPosi;

	[SerializeField]
	private Space offsetPosiSpace = Space.Self;

	[SerializeField]
	private bool lkAt = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		aktualisiert ();
	}
	public void aktualisiert(){
		if(target == null)
		{
			Debug.LogWarning("fehlt Target ref !", this);

			return;
		}
		if(offsetPosiSpace == Space.Self)
		{
			transform.position = target.TransformPoint(offsetPosi);
		}
		else
		{
			transform.position = target.position + offsetPosi;
		}
		//Rotation von Camera, bei Verfolge von Target(Auto)
		if(lkAt)
		{
			transform.LookAt(target);
		}
		else
		{    // Rotation der Camera mit meinem Target Objekt(Auto)
			transform.rotation = target.rotation;
		}
	}
}
