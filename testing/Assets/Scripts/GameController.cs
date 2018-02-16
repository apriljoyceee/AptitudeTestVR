using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;

	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;

	private DataController dataContoller;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	//for user's thumbnail
	public Text stud_nametext;
	public Text stud_numtext;
	public Text stud_agetext;
	public Text stud_gendertext;
	public GameObject boyheader;
	public GameObject girlheader;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	public static int playerScore;
	public static int category1;
	public static int category2;
	public static int category3;
	public static int category4;
	public static int category5;
	public static int category6;
	public static int category7;
	public static int category8;
	public static int category9;

	public static string timeStarted;
	public static string timeEnded;
	private int hours;
	private int minutes;
	private int seconds;

	private List<GameObject> answerButtonGameObjects = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		timeStarted = System.DateTime.Now.ToShortTimeString ();
		Debug.Log (timeStarted);
		thumbnail ();

		dataContoller = FindObjectOfType<DataController> ();
		currentRoundData = dataContoller.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;
		UpdateTimeRemainingDisplay ();

		playerScore = 0;
		questionIndex = 0;
		category1 = 0;
		category2 = 0;
		category3 = 0;
		category4 = 0;
		category5 = 0;
		category6 = 0;
		category7 = 0;
		category8 = 0;
		category9 = 0;

		ShowQuestion ();
		isRoundActive = true;
	}


	private void thumbnail(){
		stud_nametext.text = Activate.studname;
		stud_numtext.text = "Student Num: "+Activate.studnum;
		stud_agetext.text = ""+Activate.age.ToString ()+" YEARS OLD";
		stud_gendertext.text = Activate.gender;
		if (Activate.gender == "FEMALE") {
			girlheader.SetActive (true);
		} else {
			boyheader.SetActive (true);
		}
	
	}


	private void ShowQuestion()
	{
		RemoveAnswerButtons ();
		QuestionData questionData = questionPool [questionIndex];
		questionDisplayText.text = questionData.questionText;

		for (int i = 0; i < questionData.answers.Length; i++)
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
			answerButtonGameObjects.Add(answerButtonGameObject);
			answerButtonGameObject.transform.SetParent (answerButtonParent);

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup (questionData.answers [i]);
		}
	}

	private void RemoveAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0) {
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect) {
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = playerScore.ToString ();
		
			QuestionData questionData = questionPool [questionIndex];
			if (questionData.category == "1") {
				category1 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "2") {
				category2 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "3") {
				category3 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "4") {
				category4 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "5") {
				category5 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "6") {
				category6 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "7") {
				category7 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "8") {
				category8 += currentRoundData.pointsAddedForCorrectAnswer;
			}
			if (questionData.category == "9") {
				category9 += currentRoundData.pointsAddedForCorrectAnswer;
			}
		}
		if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			ShowQuestion ();
		} else {
			EndRound ();
		}
	}

	public void EndRound()
	{
		isRoundActive = false;

		questionDisplay.SetActive (false);
		roundEndDisplay.SetActive (true);

		timeEnded = System.DateTime.Now.ToShortTimeString ();
		Debug.Log (timeEnded);
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene ("TestScene");
	}

	private void UpdateTimeRemainingDisplay()
	{
		hours = Mathf.FloorToInt (timeRemaining % 1f);
		minutes = Mathf.FloorToInt (timeRemaining / 60f);
		seconds = Mathf.FloorToInt (timeRemaining - minutes * 60);
		timeRemainingDisplayText.text = hours.ToString () + ":" + minutes.ToString () + ":" + seconds.ToString ();
	}
	// Update is called once per frame
	void Update () {
		if (isRoundActive) 
		{
			timeRemaining -= Time.deltaTime;
			UpdateTimeRemainingDisplay ();

			if (timeRemaining < 600f) {
				timeRemainingDisplayText.color = Color.red;
			}
			if (timeRemaining <= 0f) {
				EndRound ();
			}
		}
	}
}
