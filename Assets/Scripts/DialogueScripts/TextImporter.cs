using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {

	// IMPORTANT: This script is no longer used in the Game.
	// It's purpose was to try and import text from a txt file 
	// and to divide each line into one spot of the array

	//If you want to see where this code is being implemented/used 
	//Please look at the TextBoxManager Script



	//This will be the txt File that needs to be writen
	public TextAsset textFile;
	//array that will take each line from the txt file
	public string[] textLines;

	// Use this for initialization
	void Start () {
		//We check that there is in fact a text file to import
		if (textFile != null) {
			//We split the text file every time a new line starts; and is then puts it in each slot of the array
			textLines = (textFile.text.Split ('\n'));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
			}
}
