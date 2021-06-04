using System.Collections.Generic;

namespace TheMostGamesTask3.Reader
{

	internal interface IReader
	{
		IList<string> StringsArray { get; }
		void GetInputStringArray();
	}

}
