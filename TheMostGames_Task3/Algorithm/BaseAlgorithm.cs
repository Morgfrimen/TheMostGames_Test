using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TheMostGamesTask3.Algorithm
{

	internal abstract class BaseAlgorithm
	{
		protected BaseAlgorithm(IList<string> stringArrayInput) => StringArrayInput = stringArrayInput;
		protected IList<string> StringArrayInput { get; }
		protected IProducerConsumerCollection<string> Result { get; } = new ConcurrentBag<string>();

		internal abstract Task<IEnumerable<string>> RunAsync(CancellationToken token );
	}

}
