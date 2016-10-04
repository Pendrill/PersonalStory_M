using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public static int sceneChosen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			sceneChosen = 2;	
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			sceneChosen = 1;
		}
	}
}
