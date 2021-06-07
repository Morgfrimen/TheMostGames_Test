using System.Collections.Generic;

namespace TheMostGamesTask3.Writer
{

	internal interface IWriter
	{
		void WriteResult(IEnumerable<string> resultArray);
	}

}
