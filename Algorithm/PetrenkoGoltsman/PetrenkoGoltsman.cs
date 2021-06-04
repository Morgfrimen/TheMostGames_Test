using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using TheMostGamesTask3.Properties;

namespace TheMostGamesTask3.Algorithm.PetrenkoGoltsman
{
	//"...для строки равен сумме индексов составляющих её БУКВ.." - цифры не учитываются 
	internal sealed class PetrenkoGoltsman : BaseAlgorithm
	{
		private const float FirstIndex = 0.5f;
		private const RegexOptions CommonRegexOptions = RegexOptions.Compiled & RegexOptions.IgnoreCase;
		private const string PatternReplaceRu = @"[^\d|\w]";
		private const string PatternReplaceEn = @"[^\d|\w|\|]";
		internal PetrenkoGoltsman(IList<string> stringArrayInput) : base(stringArrayInput) { }

		private readonly ConcurrentBag<string> _ruStrings = new();
		private readonly ConcurrentBag<string> _enStrings = new();
		private readonly List<float> _ruResultIndex = new List<float>();
		private readonly List<float> _enResultIndex = new List<float>();

		#region Overrides of BaseAlgorithm

		internal override async Task<IEnumerable<string>> RunAsync(CancellationToken cancellationToken)
		{
			await SortToLanguageAsync();
			await PetrenkoGoltsman();

			return Result;


			async Task SortToLanguageAsync()
			{
				
				await Parallel.ForEachAsync(StringArrayInput, cancellationToken, (input, token) =>
				{
					if (Regex.IsMatch(input, "[А-я]", CommonRegexOptions))
						_ruStrings.Add(input);
					else if (Regex.IsMatch(input, "[A-z]", CommonRegexOptions))
						_enStrings.Add(input);
					return ValueTask.CompletedTask;
				});
			}

			async Task PetrenkoGoltsman()
			{
				await Task.Run
				(
					() =>
					{
						Task ruLanguagePetrenkoGoltsman = Task.Run(() => FindIndex(PatternReplaceRu, _ruStrings, _ruResultIndex), cancellationToken);
						Task enLanguagePetrenkoGoltsman = Task.Run(() => FindIndex(PatternReplaceEn, _enStrings, _enResultIndex,true), cancellationToken);

						Task[] tasks = {
							ruLanguagePetrenkoGoltsman, enLanguagePetrenkoGoltsman
						};
						Task.WaitAll(tasks, cancellationToken);
					}, cancellationToken
				);

				void FindIndex(string pattern, IProducerConsumerCollection<string> collection,IList<float> result,bool isEn = false)
				{
					if (cancellationToken.IsCancellationRequested)
						return;
					string resultString = string.Empty;
					string[] inputCommon = default;
					foreach (string input in collection)
					{
						float resultIndex = FirstIndex;
						float resultIndexComment = FirstIndex;

						try
						{
							if (isEn)
							{
								inputCommon = Regex.Replace(input, pattern, "", CommonRegexOptions).Split('|');
								resultString = inputCommon[0];
							}
							else
								resultString = Regex.Replace(input, pattern, "", CommonRegexOptions);

							int length = resultString.Length;
							resultIndex = GetIndex(ref resultIndex, in length).Sum() * length;
							result.Add(resultIndex);
							if (isEn)
							{
								string comment = inputCommon[1];
								int lengthComment = comment.Length;
								resultIndexComment = GetIndex(ref resultIndexComment, in lengthComment).Sum() * lengthComment;
								result[^1] += resultIndexComment;
							}
						}
						catch (IndexOutOfRangeException)
						{
							Console.WriteLine(Resources.EnExceptionStringInput);
						}
					}

					IList<float> GetIndex(ref float resultIndex,in int length)
					{
						IList<float> sumIndex = new List<float>();
						for (int index = 0; index < length; index++)
						{
							sumIndex.Add(resultIndex);
							resultIndex += 1;
						}

						return sumIndex;
					}
				}
			}
		}

#endregion
	}

}
