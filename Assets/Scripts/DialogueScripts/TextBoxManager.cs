using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
	//This is the script that takes care of most of the dialogue stuff

	//This is the variable which contains the textbox panel.
	public GameObject textBox;
	//This is the actual text UI object.
	public Text dialogueText;
	//Check which line we are currently looking at in the array.
	public int currentLine;
	//looks at what the last line in the array that we want to look at.
	public int endAtLine;

	//This is where the actual txt. file will be stored.
	public TextAsset textFile;
	//This is the arry that will store every individual lines from within the txt file
	public string[] textLines;

	//boolean to keep track is the text panel is active
	public bool isTextBoxActive;

	//checks if the text is currently getting displayed on the screen (letter by letter)
	private bool isTyping=false;
	//checks if the typing process needs to be skipped (display the whole text)
	private bool cancelTyping = false;
	//How fast is the text scrolling on the screen
	public float typeSpeed;

	// Use this for initialization
	void Start () {
		//We check if there is a txt file to import
		if (textFile != null) {
			//We split each line into a new index within the array
			textLines = (textFile.text.Split ('\n'));
		}

		//We check to if the end line is at 0, meaning that no text is displayed
		if (endAtLine == 0) {
			//we set the endAtLine to the last element within the array
			endAtLine = textLines.Length - 1;
		}

		//We check to see if the text box should be active when the scene starts
		if (isTextBoxActive) {
			enableTextBox ();
		} else {
			disableTextBox ();
		}
	}

	// Update is called once per frame
	void Update () {
		//We check if the panel is displayed on the screen
		if (!isTextBoxActive) {
			//if not then there is no reason for the text to print. Return stops the update.
			return;
		}
		//dialogueText.text = textLines [currentLine];
		//We press Space to navigate through the dialogue.
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Look at if there is no text getting typed on the screen currently
			if (!isTyping) {							
				//We move to the next line
				currentLine += 1;
				//We check if we have gone through every line of text.
				if (currentLine > endAtLine) {
					//there is no more text to display, so we disable the textBox
					disableTextBox ();
				} else {
					//If there is still more text to print, start the coroutine to have the text scroll on the screen.
					StartCoroutine (textScroll (textLines [currentLine]));
				}
			//If Space is pressed and dialogue is still scrolling, have the whole line be displayed immediately
			} else if (isTyping && !cancelTyping) {
				cancelTyping = true;
			}			
		}
	}

	/// <summary>
	/// This coroutine will go through each letter in the text line and display them on the screen proceduraly.
	/// </summary>
	/// <returns>The scroll.</returns>
	/// <param name="lineOfText">Line of text.</param>
	private IEnumerator textScroll ( string lineOfText){
		//keeps track of which letter we are currently out
		int letter = 0;
		//this is the text that is printed on the screen
		dialogueText.text ="";
		//checks if the text is currently being scrolled onto the screen (true)
		isTyping = true;
		//checks whether the player pressed space while text is typing (false)
		cancelTyping = false;

		//while loop will keep going until all the letters on the line have been displayed
		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1)){
			//display the letters one at a time
			dialogueText.text += lineOfText [letter];
			//increase the letter we are now looking at
			letter += 1;
			//wait a certain amount of time before displaying the letter
			yield return new WaitForSeconds (typeSpeed * Time.deltaTime);

		}
		//Once the while loop is done, display the whole line on the screen
		dialogueText.text = lineOfText;
		//while loop is done so there are no more letters scrolling on the screen
		isTyping = false;
		//The whole line is now displayed so the scrolling cannot be cancelled.
		cancelTyping = false;

	}

	/// <summary>
	/// Enables the text box.
	/// </summary>
	public void enableTextBox(){
		//set the textbox to active
		textBox.SetActive (true);
		//the texbox is now active
		isTextBoxActive = true;
		//Start the coroutine to display the correspondding letters.
		StartCoroutine (textScroll (textLines [currentLine]));
	}

	/// <summary>
	/// Disables the text box.
	/// </summary>
	public void disableTextBox (){
		//set the textBox to inactive
		textBox.SetActive (false);
		//the textBox is no longer active
		isTextBoxActive = false;
	}

	/// <summary>
	/// Reloads a new script with a new set of dialogue for the object.
	/// </summary>
	/// <param name="newTextFile">New text file.</param>
	public void reloadScript(TextAsset newTextFile){
		//We check that there is actually a new text file to load
		if (newTextFile != null) {
			//We split the new lines into the wiped array.
			textLines = new string[1];
			textLines = (newTextFile.text.Split ('\n'));
			//currentLine = 0;
			endAtLine = textLines.Length - 1;
		}
	}

	public int getEndLine(){
		return endAtLine;
	}
}