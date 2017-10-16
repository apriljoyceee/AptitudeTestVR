using System.Text;

class Questionss
{
	//public int ID { get;set;}
	public string Question {get;set;}
	public string Answer {get;set;}

	public Questionss(string qsample, string qanswer)//,int id)
	{
	//	this.ID = id;
		this.Question = qsample;
		this.Answer = qanswer;
	}
}
