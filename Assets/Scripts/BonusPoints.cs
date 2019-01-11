using UnityEngine;
using System.Collections;

public class BonusPoints : MonoBehaviour {
	//make a container for the heads up display
	pancam hud;
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			hud = GameObject.Find ("Main Camera").GetComponent<pancam>();
			hud.increaseScore(10);
			Destroy (this.gameObject);
		}		
	}
}