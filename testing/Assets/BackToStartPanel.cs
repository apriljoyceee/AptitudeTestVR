using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStartPanel : MonoBehaviour {
	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;
//	public GameObject SettingsPanel;
	//public GameObject lowtg;
//	public GameObject medtg;
//	public GameObject hightg;
//	public GameObject bckbtn;
	//public GameObject sldr;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void PointerEnter(){
		//Debug.Log ("Pointer Enter");
		gazedAt=true;
		Debug.Log ("Pointer Enter");
		//SettingsPanel.transform.localScale = new Vector3(0, 0, 0);
		//lowtg.transform.localScale = new Vector3(0, 0, 0);
	//	medtg.transform.localScale = new Vector3(0, 0, 0);
	//	hightg.transform.localScale = new Vector3(0, 0, 0);
		////bckbtn.transform.localScale = new Vector3(0, 0, 0);
		//sldr.transform.localScale = new Vector3(0, 0, 0);
	}

	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAt=false;
	}
}
