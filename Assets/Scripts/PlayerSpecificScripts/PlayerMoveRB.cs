using UnityEngine;
using System.Collections;

public class PlayerMoveRB : MonoBehaviour {

	public float speed;
	private Rigidbody playerRigidBody;
	private Vector3 localVel;
	int playerVisionMinX = -50;
	int playerVisionMaxX = 65;
	//This value will increase or decrease the mouse sensitivity.
	//To decrease it pick a number between 0-1, to increase it pick any other positive number.
	// Picking 1 will keep the mouse on it's default sensitivity (though picking really big numbers might be bad...).
	float mouse_Sensitivity = 1f;
	//Vector 3 used to keep track of where the character is currently looking
	Vector3 euler;
	bool canMove;
	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canMove) {
			Screen.lockCursor = true;
			localVel = transform.InverseTransformDirection (playerRigidBody.velocity);
			//localVel.z = speed;
			//localVel.x = speed;

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y"); 
			if (Input.GetKey (KeyCode.D)) {
				//playerRigidBody.velocity += new Vector3 (speed * Time.deltaTime, 0, 0);
				localVel.x = speed;
				playerRigidBody.velocity = transform.TransformDirection (localVel);
			}
			if (Input.GetKey (KeyCode.A)) {
				localVel.x = -speed;
				//playerRigidBody.velocity += new Vector3 (-speed * Time.deltaTime, 0, 0);
				playerRigidBody.velocity = transform.TransformDirection (localVel);
			}
			if (Input.GetKey (KeyCode.W)) {
				localVel.z = speed;
				//playerRigidBody.velocity += new Vector3 (0, 0, speed * Time.deltaTime);
				playerRigidBody.velocity = transform.TransformDirection (localVel);
			}
			if (Input.GetKey (KeyCode.S)) {
				localVel.z = -speed;
				//playerRigidBody.velocity += new Vector3 (0, 0, -speed * Time.deltaTime);
				playerRigidBody.velocity = transform.TransformDirection (localVel);
			}
			localVel = new Vector3 (0, 0, 0);
			Camera.main.transform.localEulerAngles = euler;
			euler.x -= mouseY * mouse_Sensitivity;

			//Camera.main.transform.Rotate(-mouseY,0f,0f);
			//Rotates the player object left and right through the use of the mouse (look left and right).
			transform.Rotate (0f, mouseX, 0f);

			//checks if the rotation angle exceeds the max and min allowed
			if (euler.x >= playerVisionMaxX) {
				//If so then the angle is locked between the max and min values.
				euler.x = Mathf.Clamp (euler.x, playerVisionMinX, playerVisionMaxX);
			}
			//The same is done here but for the min values.
			if (euler.x <= playerVisionMinX) {
				euler.x = Mathf.Clamp (euler.x, playerVisionMinX, playerVisionMaxX);
			}
		}
	}

	public bool getCanMove(){
		return canMove;
	}
	public void setCanMove(bool activator){
		canMove = activator;
	}
}
