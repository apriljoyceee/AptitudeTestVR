using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MostAndLeastLearned : MonoBehaviour {

	// Use this for initialization

	// The map we're building is going to look like:
	//
	//	LIST OF USERS -> A User -> LIST OF SCORES for that user
	//

	Dictionary< string, Dictionary<string, int> > playerScores;

	int changeCounter = 0;
	public static string[] users = new string[9];
	public Text studname_text;
	public Text studnum_text;
	public Text studage_text;
	public Text studgender_text;
	public GameObject boythumbnail;
	public GameObject girlthumbnail;
	void Start() {
		//for thumbnail
		studname_text.text = Activate.studname;
		studnum_text.text = "Student Num: " + Activate.studnum;
		studage_text.text = Activate.age.ToString () + " YEARS OLD";
		studgender_text.text = Activate.gender;
		if (Activate.gender == "MALE") {
			boythumbnail.SetActive (true);
		} else {
			girlthumbnail.SetActive (true);
		}
	}

	void Init() {
		if(playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}

	public void Reset() {
		changeCounter++;
		playerScores = null;
	}

	public int GetScore(string username, string scoreType) {
		Init ();

		if(playerScores.ContainsKey(username) == false) {
			// We have no score record at all for this username
			return 0;
		}

		if(playerScores[username].ContainsKey(scoreType) == false) {
			return 0;
		}

		return playerScores[username][scoreType];
	}

	public void SetScore(string username, string scoreType, int value) {
		Init ();

		changeCounter++;

		if(playerScores.ContainsKey(username) == false) {
			playerScores[username] = new Dictionary<string, int>();
		}

		playerScores[username][scoreType] = value;
	}

	public void ChangeScore(string username, string scoreType, int amount) {
		Init ();
		int currScore = GetScore(username, scoreType);
		SetScore(username, scoreType, currScore + amount);
	}

	public string[] GetPlayerNames() {
		Init ();

		users= playerScores.Keys.ToArray();
		return users;
	}

	public string[] GetPlayerNames(string sortingScoreType) {
		Init ();
		users = playerScores.Keys.OrderByDescending( n => GetScore(n, sortingScoreType) ).ToArray();
		return users;
	}

	public int GetChangeCounter() {
		return changeCounter;
	}

	public void DEBUG_ADD_KILL_TO_QUILL() {
		ChangeScore("quill18", "categoryscore", 1);
	}

	public void DEBUG_INITIAL_SETUP() {
		SetScore("Language Development", "categoryscore", GameController.category1);
		SetScore("Numeracy (Mathematics)", "categoryscore", GameController.category2);
		SetScore("Sensory Perceptual", "categoryscore", GameController.category3);
		SetScore("Social Environment", "categoryscore", GameController.category4);
		SetScore("Physical Environment", "categoryscore", GameController.category5);
		SetScore("Fine Motor", "categoryscore", GameController.category6);
		SetScore("Gross Motor", "categoryscore", GameController.category7);
		SetScore("Socio-emotional", "categoryscore", GameController.category8);
		SetScore("Character and Values", "categoryscore", GameController.category9);
	}
}
