using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MostLeastCategory : MonoBehaviour {

	MostAndLeastLearned scoreManager;

	public GameObject playerScoreEntryPrefab;

	public Text most1;
	public Text most2;
	public Text most3;
	public Text most4;

	public Text least1;
	public Text least2;
	public Text least3;
	public Text least4;

	public static string mostlearned1;
	public static string mostlearned2;
	public static string mostlearned3;
	public static string mostlearned4;

	public static string leastlearned1;
	public static string leastlearned2;
	public static string leastlearned3;
	public static string leastlearned4;


	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<MostAndLeastLearned>();

		lastChangeCounter = scoreManager.GetChangeCounter();
		scoreManager.DEBUG_INITIAL_SETUP ();

	}

	// Update is called once per frame
	void Update () {
		if(scoreManager == null) {
			Debug.LogError("You forgot to add the score manager component to a game object!");
			return;
		}

		if(scoreManager.GetChangeCounter() == lastChangeCounter) {
			// No change since last update!
			return;
		}

		lastChangeCounter = scoreManager.GetChangeCounter();
		/*
		while(this.transform.childCount > 0) {
			Transform c = this.transform.GetChild(0);
			c.SetParent(null);  // Become Batman
			Destroy (c.gameObject);
		}*/

		string[] names = scoreManager.GetPlayerNames("categoryscore");
		mostlearned1 = names [0];
		mostlearned2 = names [1];
		mostlearned3 = names [2];
		mostlearned4 = names [3];

		leastlearned1 = names [8];
		leastlearned2 = names [7];
		leastlearned3 = names [6];
		leastlearned4 = names [5];


		most1.text = mostlearned1;
		most2.text = mostlearned2;
		most3.text = mostlearned3;
		most4.text = mostlearned4;

		least1.text = leastlearned1;
		least2.text = leastlearned2;
		least3.text = leastlearned3;
		least4.text = leastlearned4;
		//foreach(string name in names) {
		//	GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
		//	go.transform.SetParent(this.transform);
		//	go.transform.Find ("most").GetComponent<Text>().text = name;
			//go.transform.Find ("Kills").GetComponent<Text>().text = scoreManager.GetScore(name, "kills").ToString();
		//}
	}
}
