using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	CharacterController cController;
	int playerVision_MaxY = -25;
	int playerVision_MinY = 50;
	//float cameraPositionX;
	Vector3 euler;

	// Use this for initialization
	void Start () {
		cController = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Screen.lockCursor = true;
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		//Vector3 currentPositionInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		cController.SimpleMove (transform.forward * inputY * 5f);

		Camera.main.transform.localEulerAngles = euler;
		//euler.y += mouseY;
		euler.x -= mouseY;
		if (euler.x >= playerVision_MinY) {
			euler.x = playerVision_MinY;
		}
		if (euler.x <= playerVision_MaxY) {
			euler.x = playerVision_MaxY;
		}




		//mouseY = Mathf.Clamp (mouseY, playerVision_MaxY, playerVision_MinY);

		//if (Camera.main.transform.rotation.x > 25) {

		//}
		//cameraPositionX = Camera.main.transform.rotation.x;
		//cameraPositionX = Mathf.Clamp (cameraPositionX, playerVision_MaxY, playerVision_MinY);
		Camera.main.transform.Rotate(-mouseY,0f,0f);
		transform.Rotate (0f, mouseX, 0f);
		//	Camera.main.transform.rotation.x = cameraPositionX;
		//mouseY = Mathf.Clamp (mouseY, playerVision_MaxY, playerVision_MinY);
	}
}
