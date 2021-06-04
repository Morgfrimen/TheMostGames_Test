using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TheMostGamesTask3.Properties;
using TheMostGamesTask3.SettingApp;

namespace TheMostGamesTask3
{

	internal class Program
	{
		static Program()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Console.InputEncoding = Encoding.GetEncoding(1251);
			Console.OutputEncoding = Encoding.GetEncoding(1251);
		}

		private static async Task Main(string[] args)
		{
			CancellationTokenSource source = new CancellationTokenSource();
			CancellationToken cancellationToken = source.Token;
			// ReSharper disable once MethodSupportsCancellation
			_ = Task.Run
			(
				() =>
				{
					if (Console.ReadKey().Key == ConsoleKey.Escape)
					{
						source.Cancel();
						Process.GetCurrentProcess().Kill();
					}
				}
			);
			Console.WriteLine(Resources.WriteExitKey);
			Factory.Factory factory = new(ReaderSettings.ConsoleReader, AlgorithmSettings.PetrenkoGoltsman, WriterSettings.WriteConsole);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			await factory.RunTryAsync(cancellationToken);
			stopwatch.Stop();
			Console.WriteLine(Resources.EndTimeApp + stopwatch.Elapsed);

			
		}
	}

}
