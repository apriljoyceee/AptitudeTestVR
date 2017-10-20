using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HighScore
{
	public string Choice1 { get; set; }

	public string Name { get; set; }

	public string Choice2 { get; set; }

	public int ID { get; set; }

	public HighScore(int id, string choice1, string name, string choice2)
	{
		this.Choice1 = choice1;
		this.Name = name;
		this.ID = id;
		this.Choice2 = choice2;
	}
}
