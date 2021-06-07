namespace TheMostGames_Task1.Models
{

	internal interface ITableResult
	{
		string Test { get; set; }
		uint CountWords { get; set; }
		uint CountVowelLetters { get; set; }
	}

}
