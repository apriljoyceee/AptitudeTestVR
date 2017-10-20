using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public GameObject mark;

	public void SetMark(string mark)
	{
		this.mark.GetComponent<Text> ().text = mark;
	}

}
