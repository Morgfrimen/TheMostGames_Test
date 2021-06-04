using System;
using System.Threading;
using System.Threading.Tasks;

using TheMostGamesTask3.Algorithm;
using TheMostGamesTask3.Algorithm.PetrenkoGoltsman;
using TheMostGamesTask3.Reader;
using TheMostGamesTask3.Reader.Console;
using TheMostGamesTask3.Reader.File;
using TheMostGamesTask3.SettingApp;
using TheMostGamesTask3.Writer;
using TheMostGamesTask3.Writer.Console;

namespace TheMostGamesTask3.Factory
{

	internal sealed class Factory
	{
		internal Factory(ReaderSettings readerSettings, AlgorithmSettings algorithm, WriterSettings writerSettings)
		{
			_reader = readerSettings switch
			{
				ReaderSettings.ConsoleReader => new ReaderConsole(), 
				ReaderSettings.TxtReader => new ReaderTXT(), 
				_ => throw new NotImplementedException($"Такого {nameof(IReader)} не существует")
			};
			_algorithm = algorithm switch
			{
				AlgorithmSettings.PetrenkoGoltsman => new PetrenkoGoltsman(_reader.StringsArray),
				_ => throw new NotImplementedException($"Алгоритм не найден ({nameof(BaseAlgorithm)})")
			};
			_writer = writerSettings switch
			{
				WriterSettings.WriteConsole => new WriteConsole(), 
				_ => throw new NotImplementedException($"Такого {nameof(IWriter)} не реализованно")
			};
		}

		private readonly BaseAlgorithm _algorithm;

		private readonly IReader _reader;
		private readonly IWriter _writer;

		internal async Task RunTryAsync(CancellationToken token)
		{
			try
			{
				_reader.GetInputStringArray();
				_writer.WriteResult(await _algorithm.RunAsync(token));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		
	}

}
