using UnityEngine;
using System.Collections;

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
		return isTalking;
	}
}
