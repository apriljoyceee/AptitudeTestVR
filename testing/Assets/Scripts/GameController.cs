using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

using System.Linq;

public class GameController : MonoBehaviour {

	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;
	//public SimpleObjectPool answerButtonObjectPool;
	//public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;

	public GameObject q1;
	public GameObject q2;
	public GameObject q3;
	public GameObject q4;
	public GameObject q5;
	public GameObject q6;

	public GameObject q1c1;
	public GameObject q1c2;
	public GameObject q1c3;
	public GameObject q1c4;
	public GameObject q1c5;
	public GameObject q2c1;
	public GameObject q2c2;
	public GameObject q2c3;
	public GameObject q2c4;
	public GameObject q2c5;
	public GameObject q2c6;
	public GameObject q3c1;
	public GameObject q3c2;
	public GameObject q4c1;
	public GameObject q4c2;
	public GameObject q4c3;
	public GameObject q5c1;
	public GameObject q5c2;
	public GameObject q5c3;
	public GameObject q5c4;
	public GameObject q6c1;
	public GameObject q6c2;
	public GameObject q6c3;
	public GameObject q6c4;

	private DataController dataContoller;
	public static RoundData currentRoundData;
	public static QuestionData[] questionPool;

	//for user's thumbnail
	public Text stud_nametext;
	public Text stud_numtext;
	public Text stud_agetext;
	public Text stud_gendertext;
	public GameObject boyheader;
	public GameObject girlheader;

	private static int lastRandomNumber;
	public static int min = 1;
	public static int max = 6;
	private bool isRoundActive;
	private float timeRemaining;
	public int questionIndex;
	public int[] questionIndexx = new int[30] ;
	public static int playerScore;
	public int[] theArray = new int[30];
	public static int category1;
	public static int category2;
	public static int category3;
	public static int category4;
	public static int category5;
	public static int category6;
	public static int category7;
	public static int category8;
	public static int category9;
	private List<GameObject> answerButtonGameObjects = new List<GameObject> ();

	public static string timeStarted;
	public static string timeEnded;
	private int hours;
	private int minutes;
	private int seconds;

	// Use this for initialization
	void Start () {
		timeStarted = System.DateTime.Now.ToShortTimeString ();
		Debug.Log (timeStarted);
		thumbnail ();

		q1.SetActive (false);
		q2.SetActive (false);
		q3.SetActive (false);
		q4.SetActive (false);
		q5.SetActive (false);
		q6.SetActive (false);

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
		//Randomm ();
		//generateRandomNumber(min,max);
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
	private void Randomm()
	{

		System.Random r = new System.Random();
		for(int i= 0; i<6;i++)
		{
			theArray[i] = i+1;
		}
		for(int i = 0; i< 6; i++)
		{
			int a = r.Next(6);
			int b = r.Next(6);
			int tmp = theArray[a];
			theArray[a] = theArray[b];
			theArray[b] = tmp;

			tmp = theArray [i];
			Debug.Log (tmp);
		}
	

	}

	public static int generateRandomNumber(int min, int max){
		int result = Random.Range (min, max);

		if (result == lastRandomNumber) {
			return generateRandomNumber (min, max);
		}

		lastRandomNumber = result;
		//Debug.Log (result);
		return result;
	}

	private void ShowQuestion()
	{
		//RemoveAnswerButtons ();
		Thread.Sleep(1000);

		QuestionData questionData = questionPool [questionIndex];
			questionDisplayText.text = questionData.questionText;

		if (questionIndex == 0) {
				q1.SetActive (true);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 1) {
				q1.SetActive (false);
				q2.SetActive (true);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 2) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (true);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 3) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (true);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 4) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (true);
				q6.SetActive (false);
			}
		if (questionIndex == 5) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (true);
			}
		if (questionIndex == 6) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 7) {
				q1.SetActive (false);
				q2.SetActive (false);
				q3.SetActive (false);
				q4.SetActive (false);
				q5.SetActive (false);
				q6.SetActive (false);
			}
		if (questionIndex == 8) {
				q1.SetActive (true);
				q2.SetActive (false);
			}
		if (questionIndex == 9) {
				q1.SetActive (false);
				q2.SetActive (true);
			}
	}

	private void RemoveAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0) {
			//answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void IsCorrect()
	{
			
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
		AnswerButtonPool ();
	}
	public void AnswerButtonPool()
	{
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
		q1.SetActive (false);
		q2.SetActive (false);
		q3.SetActive (false);
		q4.SetActive (false);
		q5.SetActive (false);
		q6.SetActive (false);
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
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {
			
				Tama ();	
		}
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

	public void Tama()
	{
		playerScore += currentRoundData.pointsAddedForCorrectAnswer;
		IsCorrect();
		gazedAt=false;
		timer = 0f;
	}
	public void Mali()
	{
		AnswerButtonPool ();
		gazedAt=false;
		timer = 0f;
	}
	public void PointerEnter(){

		gazedAt=true;
	}
	public void Resetinator(){
		timer = 0f;
	}
	public void PointerExit(){

		gazedAt=false;
	}
}
