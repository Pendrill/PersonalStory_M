using UnityEngine;
using System.Collections;

public class RandomSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Random.ColorHSV ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
