using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.Data;

public class QuestionsManager : MonoBehaviour {

	private string connectionString;

	private List<Questionss> quesTions = new List<Questionss>();

	public GameObject scorePrefab;

	public Transform scoreParent;
	// Use this for initializations
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/testingdb.sqlite";
		//InsertScore ("Saan, saan, saan ang naiba","hulaan mo");
		ShowScores();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void InsertScore(string sample, string answer)
	{
		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = String.Format("INSERT INTO questionsdb(qsample,qanswer)	VALUES(\"{0}\",\"{1}\")",sample,answer);

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();

			}
		}
	}
	private void GetQuestions()
	{
		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
				dbConnection.Open();

				using (IDbCommand dbCmd = dbConnection.CreateCommand())
				{
					string sqlQuery = "SELECT * FROM questionsdb";

					dbCmd.CommandText = sqlQuery;

					using (IDataReader reader = dbCmd.ExecuteReader())
					{
						while (reader.Read())
						{
						//Debug.Log(reader.GetString(1)+ " - "+ reader.GetString(2));
						}
						//dbConnection.Close();
						//reader.Close();
					}
				}
		}

	}

	public void ShowScores()
	{
		GetQuestions ();

		for (int i = 0; i < quesTions.Count; i++) {
			 
			GameObject tmpObjec = Instantiate (scorePrefab);

			Questionss tmpScore = quesTions [i];

			tmpObjec.GetComponent<QuestionScript> ().SetScore (tmpScore.Question, tmpScore.Answer);

			tmpObjec.transform.SetParent (scoreParent);
		}

	}


}
