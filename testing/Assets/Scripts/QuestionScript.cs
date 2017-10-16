using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour {
	
	public GameObject Questions;
	public GameObject Answer;


	public void SetScore(string Sample, string Answer)
	{
		this.Questions.GetComponent<Text> ().text = Sample;
		this.Answer.GetComponent<Text> ().text = Answer;
	}
}
