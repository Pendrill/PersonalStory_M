using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {
	public GameObject visionCone;

	// Use this for initialization
	void Start () {
		//The box collider used to check if we are close enough to an object to interact with it
		//Will no longer also collide with the walls and such, which was limiting the players movement.
		Physics.IgnoreCollision (visionCone.GetComponent<Collider> (), GetComponent<Collider> ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
