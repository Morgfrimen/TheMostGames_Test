using System.Collections.Generic;

using TheMostGamesTask3.Properties;

namespace TheMostGamesTask3.Reader.Console
{

	internal sealed class ReaderConsole : IReader
	{
		internal ReaderConsole() => StringsArray = new string[2];

#region Implementation of IReader

		public IList<string> StringsArray { get; }

		public void GetInputStringArray()
		{
			System.Console.WriteLine(Resources.FirstConsoleInputMessage);
			StringsArray[0] = System.Console.ReadLine();
			System.Console.WriteLine(Resources.SecondConsoleInputMessage);
			StringsArray[1] = System.Console.ReadLine();
		}

#endregion
	}

}
