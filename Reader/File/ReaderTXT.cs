using System;
using System.Collections.Generic;

namespace TheMostGamesTask3.Reader.File
{

	internal sealed class ReaderTXT : IReader
	{
#region Implementation of IReader

		public IList<string> StringsArray { get; }
		public void GetInputStringArray() => throw new NotImplementedException();

#endregion
	}

}
