using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Choice1Script : MonoBehaviour {

	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;
	private string connectionString;

	private List<HighScore> highScores = new List<HighScore>();

	public GameObject scorePrefab;
	public Transform scoreParent;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				connectionString = "URI=file:" + Application.dataPath + "/testingdb.sqlite";
				ShowScores();
			}
		}

	}
		
	public void PointerEnter(){
		//Debug.Log ("Pointer Enter");
		gazedAt=true;
	}
	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAt=false;
	}
	private void GetScores()
	{

		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = "SELECT * FROM HighScores";

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
		Debug.Log ("PUMASOK KABA ULI GAGO?s");

		GameObject tmpObjec = Instantiate (scorePrefab);

		HighScore tmpScore = highScores[1];
		tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name,tmpScore.Choice1,tmpScore.Choice2, "#" + tmpScore.ID.ToString());
		tmpObjec.transform.SetParent (scoreParent);

	}
}
