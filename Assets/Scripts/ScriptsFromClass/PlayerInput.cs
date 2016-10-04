using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	CharacterController charControl;
	float speed = 200f;
	// Use this for initialization
	void Start () {
		charControl = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		charControl.SimpleMove( transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime + 
			transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

	}
}
