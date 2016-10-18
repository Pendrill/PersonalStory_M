using UnityEngine;
using System.Collections;


//This script is just a bunch of getters and setters that get accessed to get/set
//What the current action the player character is currently performing.

public class PlayerAction : MonoBehaviour {
	public bool isLooking;
	public bool isTalking;
	public bool isTouching;

	public void setLook(bool areTheyCurrentlyLooking){
		if (areTheyCurrentlyLooking) {
			isLooking = true;
		} else {
			isLooking = false;
		}
	}

	public void setTalk( bool areTheyCurrentlyTalking){
		if (areTheyCurrentlyTalking) {
			isTalking = true;
		} else {
			isTalking = false;
		}
	}

	public void setTouch( bool areTheyCurrentlyTouching){
		if (areTheyCurrentlyTouching) {
			isTouching = true;
		} else {
			isTouching = false;
		}
	}

	public bool getLook(){
		return isLooking;
	}

	public bool getTalk(){
		return isTalking;
	}

	public bool getTouch(){
		return isTouching;
	}
}
