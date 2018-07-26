using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//diese Skript dient für die Suspension von Reifen
public class suspensionMesh : MonoBehaviour {
	public WheelCollider wheelC;// hier wird jede Reife in Unity Drag and drop
	public Vector3 wheelZ;// Mitte der Reife
	private RaycastHit hit;// Structure used to get information back from a raycas

	// Update is called once per frame
	void Update () {
		// man kiegt hier die Mitte der Wheelcollider
		//transform.TransformPoint: transform position from the local space to world space
		wheelZ = wheelC.transform.TransformPoint (wheelC.center);

		                              //Untern von Collidern         die Höhe der Suspension 
		if (Physics.Raycast(wheelZ, -wheelC.transform.up, out hit, wheelC.suspensionDistance + wheelC.radius)) {
			      // point d'impact du rayon + transform UP WheelC *radius WheelC
			transform.position = hit.point + (wheelC.transform.up * wheelC.radius);
		}
		                               // transform WheelC * Suspension Distance
		transform.position = wheelZ - (wheelC.transform.up * wheelC.suspensionDistance);
	}
}
