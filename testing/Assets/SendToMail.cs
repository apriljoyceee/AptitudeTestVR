using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System;
public class SendToMail : MonoBehaviour
{
	public static int ave;
	private Boolean gazedAt;
	private float timer = 0f;
    // Use this for initialization
	void Start(){
		
	}
	void Update(){
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {
			Send2Email ();
		}
	}

	public void Send2Email()
    {
		ave = ((GameController.playerScore / 30) * 50 + 50);
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("vraptitudetest1718@gmail.com");
        mail.To.Add("vraptitudetest1718@gmail.com");
		mail.Subject = "Quiz Results of " + Activate.studname;
		mail.Body = "Good Day! \n" +
		"Here are the Quiz Results of " +
		"Student Number: " + Activate.studnum +
		"\nName: " + Activate.studname +
		"\nAge: " + Activate.age.ToString () +
		"\nGender: " + Activate.gender +
		"\n\n" +
		"--------------------------------------------------------------------\n" +
		"Language Development: " + GameController.category1 + " out of 8 items\n" +
		"Numeracy '('Mathematics')': " + GameController.category2 + " out of 8 items\n" +
		"Sensory Perceptual: " + GameController.category3 + " out of 8 items\n" +
		"Social Environment: " + GameController.category4 + " out of 8 items\n" +
		"Physical Environment: " + GameController.category5 + " out of 8 items\n" +
		"Fine Motor: " + GameController.category6 + " out of 8 items\n" +
		"Gross Motor: " + GameController.category7 + " out of 8 items\n" +
		"Socio-emotional Development " + GameController.category8 + " out of 8 items\n" +
		"Character and Values Development: " + GameController.category9 + " out of 8 items\n" +
		"--------------------------------------------------------------------\n" +
		"TOTAL SCORE: " + GameController.playerScore + "/30\n" +
		"Average: " + ave+"%\n"+
		"--------------------------------------------------------------------\n\n" +
		"MOST LEARNED AREAS\n" +
		"1. " + MostLeastCategory.mostlearned1 + "\n" +
		"2. " + MostLeastCategory.mostlearned2 + "\n" +
		"3. " + MostLeastCategory.mostlearned3 + "\n" +
		"4. " + MostLeastCategory.mostlearned4 + "\n\n" +

		"LEAST LEARNED AREAS\n" +
		"1. " + MostLeastCategory.leastlearned1 + "\n" +
		"2. " + MostLeastCategory.leastlearned2 + "\n" +
		"3. " + MostLeastCategory.leastlearned3 + "\n" +
		"4. " + MostLeastCategory.leastlearned4 + "\n";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("vraptitudetest1718@gmail.com", "vraptitudetest20172018") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);

        Debug.Log("success");
		SceneManager.LoadScene ("EMAILSENT");

    }


	public void PointerEnter(){
		gazedAt=true;
		//	Debug.Log ("Pointer Enter");
	}

	public void PointerExit(){
		gazedAt=false;
		//Debug.Log ("Pointer Exit");
	}

	public void Resetinator(){
		timer = 0f;
	}
}
