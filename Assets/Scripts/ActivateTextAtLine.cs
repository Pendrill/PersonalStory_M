using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {
	 
	public TextAsset theText;
	public int startLine;
	public int endLine;
	public TextBoxManager theTextBoxManager;
	public bool destroyWhenActivated;

	public bool requireButtonPress;
	bool waitForPress;

	// Use this for initialization
	void Start () {
		theTextBoxManager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForPress && Input.GetKeyDown (KeyCode.Mouse0)) {
			theTextBoxManager.reloadScript (theText);
			theTextBoxManager.currentLine = startLine;
			theTextBoxManager.endAtLine = endLine;
			theTextBoxManager.enableTextBox ();
			if (destroyWhenActivated) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {

			if (requireButtonPress) {
				waitForPress = true;
				return;
			}
			theTextBoxManager.reloadScript (theText);
			theTextBoxManager.currentLine = startLine;
			theTextBoxManager.endAtLine = endLine;
			theTextBoxManager.enableTextBox ();
			if (destroyWhenActivated) {
				Destroy (gameObject);
			}
		}
	}

	void onTriggerExit (Collider other){
		if (other.name == "Player") {
			waitForPress = false;
		}
	}
}
