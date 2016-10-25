using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimesInteracted : MonoBehaviour {
	public int objectTimes=0;
	public int computerTimes=0;
	public int maxTimesObj=20;
	public int maxTimeComp=30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (objectTimes >= maxTimesObj) {
			SceneManager.LoadScene (2);
	
		}
		if (computerTimes >= maxTimeComp) {
			//go to win screen;
			SceneManager.LoadScene (1);
		}
	}

	public void addObj (int oneMore){
		objectTimes += oneMore;
	}
	public void addComp (int oneMore){
		computerTimes += oneMore;
	}
}
