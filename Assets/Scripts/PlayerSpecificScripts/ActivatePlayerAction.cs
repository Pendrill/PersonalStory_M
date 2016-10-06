using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivatePlayerAction : MonoBehaviour {
	private PlayerAction Look;
	private PlayerAction Talk;
	private PlayerAction Touch;
	public Text currentAction;
	private string action;


	// Use this for initialization
	void Start () {
		//Having all these variables is unnecessary (memory wise) as they are all accessing the same thing.
		//However it might help with the scripts legibility.
		Look = GetComponent<PlayerAction> ();
		Talk = GetComponent<PlayerAction> ();
		Touch = GetComponent<PlayerAction> ();
		Look.setLook (true);
		action = "Looking";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) && !Look.getLook ()) {
			//Debug.Log ("The 1 key has been pressed");
			//GetComponent<PlayerAction> ().getLook (true);
			Look.setLook (true);
			Talk.setTalk (false);
			Touch.setTouch (false);
			action = "Looking";
			//if (Look.getLook ()) {
			//	Debug.Log ("You are currently looking");
			//}
		} else if (Input.GetKeyDown (KeyCode.Alpha2) && !Talk.getTalk ()) {
			Look.setLook (false);
			Talk.setTalk (true);
			Touch.setTouch (false);
			action = "Talking";
		} else if (Input.GetKeyDown (KeyCode.Alpha3) && !Touch.getTouch ()) {
			Look.setLook (false);
			Talk.setTalk (false);
			Touch.setTouch (true);
			action = "Touching";
		}

		currentAction.text = "You are currently: " + action;
	}
}
