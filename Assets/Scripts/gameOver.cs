using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {
	int score = 0;
	public GUIElement gui;
	
	// Use this for initialization
	void Start () {
		//get our score from playerprefs
		score = PlayerPrefs.GetInt ("Score");
		//multiply by 10 as we did on displayed score
		score = score * 10;
	}
	
	void OnGUI(){
		//set our text to our score
		gui.guiText.text = score.ToString ();
		//if retry button is pressed load scene 0 the game
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +50,100,40),"Retry?")){
			Application.LoadLevel(0);
		}
		//and quit button
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +100,100,40),"Quit")){
			Application.Quit();
		}
	}	
}