using System.Collections.Generic;
using System.Linq;

using TheMostGamesTask3.Properties;

namespace TheMostGamesTask3.Writer.Console
{

	public sealed class WriteConsole : IWriter
	{
#region Implementation of IWriter

		public void WriteResult(IEnumerable<string> resultArray)
		{
			if(resultArray.Count() is 0)
			{
				System.Console.WriteLine(Resources.CountZeroResult);
				return;
			}

			System.Console.WriteLine(Resources.DefaultResult);
			foreach (string s in resultArray)
				System.Console.WriteLine(s);
		}

#endregion
	}

}
