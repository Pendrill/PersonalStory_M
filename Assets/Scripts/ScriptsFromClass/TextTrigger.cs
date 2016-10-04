using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

	int triggerCount = 0;
	public string[] goodByeStrings;


	void OnTriggerEnter(Collider player){
		Debug.Log("Hey I am walking here!");
		triggerCount += 1;
		if (triggerCount == 1) {
			Debug.Log ("You bumped into this person " + triggerCount.ToString () + " time");
		} else {
			Debug.Log ("You bumped into this person " + triggerCount.ToString () + " times");
		}

		player.transform.localScale *= 1.1f;
	}
	void OnTriggerExit(Collider player){
		Debug.Log (goodByeStrings [Random.Range (0, goodByeStrings.Length)]);
	}

}
