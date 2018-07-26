using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// Diese Methode dient nur für die Zerstörung von Kugeln,.... 
	void kugelCollision(Collision col)
	{
		Destroy (gameObject);
	}
}
