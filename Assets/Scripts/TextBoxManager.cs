using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {


	public GameObject textBox;
	public Text dialogueText;
	public int currentLine;
	public int endAtLine;

	public TextAsset textFile;
	public string[] textLines;

	public bool isTextBoxActive;

	private bool isTyping=false;
	private bool cancelTyping = false;
	public float typeSpeed;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isTextBoxActive) {
			enableTextBox ();
		} else {
			disableTextBox ();
		}
	}

	// Update is called once per frame
	void Update () {

		if (!isTextBoxActive) {
			return;
		}
		//dialogueText.text = textLines [currentLine];
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isTyping) {

							
				currentLine += 1;
				if (currentLine > endAtLine) {
					disableTextBox ();
				} else {
					StartCoroutine (textScroll (textLines [currentLine]));
				}
			} else if (isTyping && !cancelTyping) {
				cancelTyping = true;
			}
				

			
		}


	}

	private IEnumerator textScroll ( string lineOfText){
		int letter = 0;
		dialogueText.text ="";
		isTyping = true;
		cancelTyping = false;

		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1)){
			dialogueText.text += lineOfText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed * Time.deltaTime);

		}
		dialogueText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;

	}

	public void enableTextBox(){
		textBox.SetActive (true);
		isTextBoxActive = true;
		StartCoroutine (textScroll (textLines [currentLine]));
	}

	public void disableTextBox (){
		textBox.SetActive (false);
		isTextBoxActive = false;
	}

	public void reloadScript(TextAsset newTextFile){
		if (newTextFile != null) {
			textLines = new string[1];
			textLines = (newTextFile.text.Split ('\n'));
		}
	}
}