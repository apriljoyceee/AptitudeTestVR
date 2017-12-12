using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.EnterpriseServices;
using System.Security;
using System.Configuration;
using System.IO;

public class HighScoreManager : MonoBehaviour {

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
		connectionString = Application.streamingAssetsPath + "/testingdb.sqlite";
		string filepath = Application.streamingAssetsPath + "/testingdb.sqlite";

		if (Application.platform == RuntimePlatform.Android)
		{
			WWW reader = new WWW(filepath);
			while ( ! reader.isDone) {}

			string realPath = Application.persistentDataPath + "/db";
			System.IO.File.WriteAllBytes(realPath, reader.bytes);
			connectionString = realPath;
		}
	}

	private void GetScores()
	{

		using (IDbConnection dbConnection = new SqliteConnection("URI=file:" + connectionString))
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
					dbConnection.Close();
					reader.Close();
				}
			}
		}

	}

	private void ShowScores()
	{
		GetScores ();
//		Debug.Log ("PUMASOK KABA GAGO?");

			GameObject tmpObjec = Instantiate (scorePrefab);

			HighScore tmpScore = highScores[0];
		tmpObjec.GetComponent<HighScoreScript> ().SetScore ("Alin ang ngalan ng tao?","Babae", "Lilybeth", "#1");
		tmpObjec.transform.SetParent (scoreParent);

	}
}
