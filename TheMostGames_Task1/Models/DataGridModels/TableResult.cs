namespace TheMostGames_Task1.Models.DataGridModels
{

	internal sealed class TableResult : ITableResult
	{
#region Implementation of ITableResult

		public string Test { get; set; }
		public uint CountWords { get; set; }
		public uint CountVowelLetters { get; set; }

#endregion
	}

}
