using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.EnterpriseServices;
using System.Security;
using System.Configuration;
using System.IO;


public class Activate : MonoBehaviour {
	public Text code;
	public static string studnum;
	public static string studnum_db;
	public static string studname;
	public static string gender;
	public static int age;
	private Boolean gazedAt;
	private float timer = 0f;
	private string connectionString;
	public AudioSource beepaudio;
	public AudioSource wrongaudio;
	// Use this for initialization
	void Start () {
		//enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

		}
		if (timer >=1.5f) {
			ConnectionDB ();
			StartCoroutine ("LogIn");
		}

	}

	public void Resetinator(){
		timer = 0f;
	}
	/*IEnumerator updateOff(){
		yield return new WaitForSeconds (5.0f);
		updateOn = false;
	}*/


	public void PointerEnter(){
		gazedAt=true;
	//	Debug.Log ("Pointer Enter");
	}

	public void PointerExit(){
		gazedAt=false;
		//Debug.Log ("Pointer Exit");
	}


	public void ConnectionDB()
	{
		connectionString = Application.streamingAssetsPath + "/students.db";
		string filepath = Application.streamingAssetsPath + "/students.db";

		if (Application.platform == RuntimePlatform.Android)
		{
			WWW reader = new WWW(filepath);
			while ( ! reader.isDone) {}

			string realPath = Application.persistentDataPath + "/db";
			System.IO.File.WriteAllBytes(realPath, reader.bytes);
			connectionString = realPath;
		}
	}

	IEnumerator LogIn()
	{
		studnum = code.text;
		if (String.IsNullOrEmpty (studnum)) {
			Debug.Log ("Empty");
		}
		else{
			using (IDbConnection dbConnection = new SqliteConnection ("URI=file:" + connectionString)) {
				dbConnection.Open ();

				using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				
					string sqlQuery = String.Format ("SELECT * FROM studinfo WHERE studnum= " + studnum);

					dbCmd.CommandText = sqlQuery;

					using (IDataReader reader = dbCmd.ExecuteReader ()) {
						while (reader.Read ()) {
							studnum_db = reader.GetString (0);
							gender = reader.GetString (4);
							age = reader.GetInt32 (5);
							studname = ""+ reader.GetString(1) + ", " + reader.GetString(2) + " "+reader.GetString(3) + ".";
 							//Debug.Log ("" + studnum_db + ", " + reader.GetString (2) + " " + reader.GetString (3) + "-" + reader.GetString (4) + "-" + reader.GetInt32 (5));
							Debug.Log(studname);
						}
						if (String.IsNullOrEmpty(studnum_db)) {
							wrongaudio.Play();
							code.text = "NO RESULT";
							//errorlg ();
						} else {
							dbConnection.Close ();
							reader.Close ();
							enabled = false;
							beepaudio.Play();
							SceneManager.LoadScene("Persistent");
							yield return null;
						}
					}




				}
			}
		}
		enabled = true;

	}
		

}
