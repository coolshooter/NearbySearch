using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearbySearch
{
	public class Engine2
	{
		public static string Run(List<string> filenames, List<string> sourceWords,
			bool ignoreCase, int linesRadius)
		{
			Dictionary<string, List<string>> sourceWordToLines = new Dictionary<string, List<string>>();
			Dictionary<string, List<string>> sourceWordToResultWords = new Dictionary<string, List<string>>();

			sourceWords.ForEach(w =>
			{
				sourceWordToLines[w] = new List<string>();
				sourceWordToResultWords[w] = new List<string>();
			});

			foreach (var filename in filenames)
			{
				List<string> lines = FileHelper.ReadLines(filename);
				Dictionary<string, List<int>> sourceWordToCenterLineIndexes = new Dictionary<string, List<int>>();

				sourceWords.ForEach(w => 
					{
						sourceWordToCenterLineIndexes[w] = new List<int>();
					});

				for (int i = 0; i < lines.Count; i++)
				{
					var lineRes = lines[i].ContainsAnyWords(sourceWords, ignoreCase);

					if (lineRes.FoundAnything)
					{
						foreach (var fw in lineRes.FoundWords)
						{
							sourceWordToCenterLineIndexes[fw].Add(i);
						}
					}
				}

				foreach (var sword in sourceWords)
				{
					foreach (int ci in sourceWordToCenterLineIndexes[sword])
					{
						var nearbyLines = lines
							.Skip(Math.Max(ci - linesRadius, 0))
							.Take(linesRadius * 2 + 1);

						sourceWordToLines[sword].AddRange(nearbyLines);
					}

					sourceWordToResultWords[sword] = GetWords(sourceWordToLines[sword]);
				}
			}

			List<string> resultIntersection = null;

			foreach (string sword in sourceWords)
			{
				if (resultIntersection == null)
				{
					resultIntersection = new List<string>();
					resultIntersection.AddRange(sourceWordToResultWords[sword]);
				}
				else
				{
					resultIntersection = resultIntersection.Intersect(
						sourceWordToResultWords[sword]).ToList();
				}
			}

			string result = string.Join("\n", resultIntersection);

			return result;
		}

		public static List<string> GetWords(List<string> lines)
		{
			List<string> resultWords = new List<string>();

			lines.ForEach(rl =>
				resultWords.AddRange(rl.SplitToWords()));

			resultWords = resultWords.Distinct().ToList();

			resultWords.Remove("new");
			resultWords.Remove("is");
			resultWords.Remove("for");
			resultWords.Remove("public");
			resultWords.Remove("private");
			resultWords.Remove("foreach");
			resultWords.Remove("switch");
			resultWords.Remove("break");
			resultWords.Remove("case");
			resultWords.Remove("var");
			resultWords.Remove("static");
			resultWords.Remove("return");

			resultWords.Remove("System");
			resultWords.Remove("object");
			resultWords.Remove("List");
			resultWords.Remove("string");
			resultWords.Remove("int");
			resultWords.Remove("bool");
			resultWords.Remove("char");

			resultWords.Remove("StringSplitOptions");
			resultWords.Remove("true");
			resultWords.Remove("false");
			resultWords.Remove("null");
			resultWords.Remove("0");
			resultWords.Remove("1");

			resultWords.Remove("Add");
			resultWords.Remove("Where");
			resultWords.Remove("First");
			resultWords.Remove("FirstOrDefault");

			//double dval;

			//resultWords = resultWords.Where(w =>
			//	w.Length > 2 && !double.TryParse(w, out dval))
			//	.ToList();

			return resultWords;
		}
	}
}
