using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerController : MonoBehaviour {
	
	public int vit =5;
	public Vector3 bewegung = Vector3.zero;
	public CharacterController spieler;
	public int velo; // Die Sensibilität von Maus
	public int spring =4;
	public int gravi = 15; // Die Gravität, die meiner Spieler braucht für einen Sprung
	public int v= 10;  // Run Speed for my Player
	private Animator anim;

	// Use this for initialization
	void Start () {
		spieler = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// GetAxisRaw: Returns the value of the virtual Axis identified by Axisnamewith no smoothing filtering applied.
		bewegung.z= Input.GetAxisRaw("Vertical");
		// braucht man hier keine Y Achse, 
		bewegung.x= Input.GetAxisRaw("Horizontal");
		bewegung = transform.TransformDirection (bewegung);

		//Bewegung: if i press the task R, i active my Player in Run Mode and the Vitesse must change, else  
		if (Input.GetKey(KeyCode.R)) {
			spieler.Move (bewegung * Time.deltaTime * v);
		} else {
			
			spieler.Move (bewegung * Time.deltaTime * vit);
		}
	
		// Hier drehe ich mittels des Maus meiner Spieler auf die X Achsen
		transform.Rotate (0,Input.GetAxisRaw("Mouse X")* velo,0);

		//Sprung des Spielers
		if(Input.GetKeyDown(KeyCode.G) && spieler.isGrounded){
			bewegung.y = spring;
			anim.SetTrigger ("springen");
		}
		//isGrounded: Was the CharacterController touching the Ground during the last move?
		if (!spieler.isGrounded) {
		
			bewegung.y = (-1) * gravi * Time.deltaTime; 
		}
		// Animation des Spielers

		//Wenn meine gedrückte Task L ist, und nicht R, dann könnte meiner Spieler einfach laufen

		if (Input.GetKey(KeyCode.L) & !Input.GetKey(KeyCode.R)){
				 anim.SetBool ("lauf", true);
			     anim.SetBool ("ran", false);
			}
		// wenn ich L und R gleichseitig drucke, dann befindet meiner Spieler in Rennen Mode

		if (Input.GetKey(KeyCode.L) & Input.GetKey(KeyCode.R)){
			anim.SetBool ("lauf", false);
			anim.SetBool ("ran", true);
		}

		//wenn der gedruckte Key nicht L ist, dann macht der Spieler nichts (keine Bewegung)
		if (!Input.GetKey(KeyCode.L)){
			anim.SetBool ("lauf", false);
			anim.SetBool ("ran", false);
		}
     }
}
