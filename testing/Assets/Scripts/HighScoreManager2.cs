using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
//using Mono.Data.Sqlite;
using Mono.Data.SqliteClient;
using System.EnterpriseServices;
using System.Security;
using System.Configuration;
using System.IO;

public class HighScoreManager2 : MonoBehaviour {

	private string connectionString;

	private List<HighScore> highScores = new List<HighScore>();

	public GameObject scorePrefab;


	public Transform scoreParent;

	// Use this for initialization
	void Start () {
		ConnectionDB();

		ShowScores();
	}

	// Update is called once per frame
	void Update () {

	}

	public void ConnectionDB()
	{
		if (Application.platform != RuntimePlatform.Android) {
			connectionString = "URI=file:" + Application.dataPath + "/testingdb.sqlite";
		}
		else {
			connectionString = Application.persistentDataPath + "/testingdb.sqlite";

			if (!File.Exists (connectionString)) {
				WWW load = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + "testingdb.sqlite");
				while (!load.isDone) {}

				File.WriteAllBytes (connectionString, load.bytes);
			}
		}
	}

	private void GetScores()
	{

		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = String.Format("SELECT * FROM HighScores");

				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
						highScores.Add (new HighScore (reader.GetInt32 (0), reader.GetString (2), reader.GetString (1), reader.GetString (3)));
					}
					//dbConnection.Close();
					//reader.Close();
				}
			}
		}

	}

	private void ShowScores()
	{
		GetScores ();
		//		Debug.Log ("PUMASOK KABA GAGO?");

		GameObject tmpObjec = Instantiate (scorePrefab);

		HighScore tmpScore = highScores[1];
		tmpObjec.GetComponent<HighScoreScript> ().SetScore ("Alin ang hayop na may apat na paa?","Manok","Aso","#2");
		tmpObjec.transform.SetParent (scoreParent);

	}
}
