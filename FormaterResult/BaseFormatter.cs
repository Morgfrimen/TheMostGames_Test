using System.Collections.Generic;

namespace TheMostGamesTask3.FormaterResult
{

	internal abstract class BaseFormatter
	{
		protected BaseFormatter(IList<string> algorithm) => ResultStringArray = algorithm;
		protected IList<string> ResultStringArray { get; }

		internal virtual void FormatResult() { }
	}

}
