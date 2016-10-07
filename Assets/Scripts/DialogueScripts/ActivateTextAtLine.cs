using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {
	 
	//Takes a txt file 
	public TextAsset theText;
	public TextAsset cannotLook, cannotTalk, cannotTouch, LookText, TalkText, TouchText;
	//keep track of which dialogue line we want to start at
	public int startLine;
	//where we want to end at
	public int endLine;
	//object representing our textboxmanager (w/ script)
	public TextBoxManager theTextBoxManager;
	//Do we want to destroy the object once it has been activated
	public bool destroyWhenActivated;
	//do you need to press a button to activate the object
	public bool requireButtonPress;
	//has the button been pressed?
	bool waitForPress;

	public bool canLook, canTalk, canTouch;
	private PlayerAction Act;
	private TextBoxManager lines;
	public GameObject player;

	// Use this for initialization
	void Start () {
		//Get the object with the textboxmanager script on it which is in the scene
		theTextBoxManager = FindObjectOfType<TextBoxManager> ();
		Act = player.GetComponent<PlayerAction> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checks if the player clicked to activate the object
		//Debug.Log (Act.getLook ());
		//
		if (waitForPress && Input.GetKeyDown (KeyCode.Mouse0)) {
			//Debug.Log (Act.getLook ());
			if (Act.getLook()) {
				if (canLook) {
					reloadTheText (LookText, startLine, endLine);
				} else {
					reloadTheText (cannotLook, startLine, endLine);
				}
			} else if (Act.getTalk()) {
				if (canTalk) {
					reloadTheText (TalkText, startLine, endLine);
				} else {
					reloadTheText (cannotTalk, startLine, endLine);
				}
			} else if (Act.getTouch()) {
				if (canTouch) {
					reloadTheText(TouchText, startLine, endLine);
				} else {
					reloadTheText (cannotTouch, startLine, endLine);
				}
			}

		}
	}

	void reloadTheText(TextAsset text, int startLine, int endLine){
		//we load the new text file of the object into our textbox manager
		theTextBoxManager.reloadScript (text);
		startLine = 0;
		endLine = theTextBoxManager.getEndLine();
		//the current line becomes the startline of the object
		theTextBoxManager.currentLine = startLine;
		//the endLine previously used becomes the endline of the object
		theTextBoxManager.endAtLine = endLine;
		//We enable the textBox to show the new dialogue that got activated when clicking
		theTextBoxManager.enableTextBox ();
		//check if the object needs to be destroyed and destroy it if need be.
		if (destroyWhenActivated) {
			Destroy (gameObject);
		}

	}

	//check when the player enter the collider of the specific object
	void OnTriggerEnter(Collider other){
		//checks if it is the player that in fact collided with the object
		if (other.tag == "Player") {
			Debug.Log ("square collides");
			//checks if the object needs a button press to be activated
			if (requireButtonPress) {
				//so then we need to press a button, and cancel the rest of this function
				waitForPress = true;
				return;
			}
			//If there is no need to press a button, then we need to load in the new script of the object.
			theTextBoxManager.reloadScript (theText);
			//the new start and end lines are set for the textBox manager
			theTextBoxManager.currentLine = startLine;
			theTextBoxManager.endAtLine = endLine;
			//we also now need to enable the textbox
			theTextBoxManager.enableTextBox ();
			//Check if the object needs to be destroyed when interacting with it
			if (destroyWhenActivated) {
				//and destroy it if necessary
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerExit (Collider other){
		//If the player exits the collision area then the player should noo longer be able to press a button 
		//and activate the object.
		if (other.name == "Player") {
			waitForPress = false;
		}
	}
}
