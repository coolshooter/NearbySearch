using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NearbySearch
{
	public static class TextHelper
	{
		public static string WiseTrimTabsAtStart(this string s)
		{
			int tabsCount = s.TakeWhile(c => c == '\t').Count();
			s = s.TrimStart('\t');

			for (int i = 0; i < tabsCount; i++)
				s = ' ' + s;

			return s;
		}

		public static bool Contains(this string s1, string s2, bool ignoreCase)
		{
			if (!ignoreCase)
				return s1.Contains(s2);
			else
				return s1.ToLower().Contains(s2.ToLower());
		}

		public static ContainsResult ContainsAny(this string s1, 
			List<string> anyOfThese, bool ignoreCase)
		{
			ContainsResult res = new ContainsResult();

			foreach (string word in anyOfThese)
			{
				if (s1.Contains(word, ignoreCase))
				{
					res.FoundWords.Add(word);
				}
			}

			return res;
		}

		public static ContainsResult ContainsAnyWords(this string s1,
			List<string> anyOfThese, bool ignoreCase)
		{
			ContainsResult res = new ContainsResult();
			string[] s1Words = s1.SplitToWords();

			if (ignoreCase)
				s1Words = s1Words.Select(w => w.ToLower()).ToArray();

			List<string> anyOfTheseAdapted;

			if (ignoreCase)
				anyOfTheseAdapted = anyOfThese.Select(w => w.ToLower()).ToList();
			else
				anyOfTheseAdapted = anyOfThese;

			foreach (string word in anyOfTheseAdapted)
			{
				if (s1Words.Contains(word))
				{
					res.FoundWords.Add(word);
				}
			}

			return res;
		}

		public static string[] SplitToWords(this string text)
		{
			return text.Split(
					new char[]
						{ '.', ' ', '\t', '\n', '|', '/', '\\', '+', '-', '=',
						'?', '>', '<', ',', '%', '$', '#', '@', '!', '(', ')',
						'&', '*', ';', ':', '[', ']', '{', '}', '\'', '"' },
					StringSplitOptions.RemoveEmptyEntries);
        }

		/// <summary>
		/// Пример применения: File.ReadAllText(fileName).GetRareWords().
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static List<string> GetRareWords(this string text)
		{
			List<string> words = text.SplitToWords()
				.Where(w => w.Length > 2 && w.IsEnglish())
				.ToList();
			Dictionary<string, int> wordToCount = new Dictionary<string, int>();

			foreach (string word in words)
			{
				if (!wordToCount.ContainsKey(word))
					wordToCount[word] = 0;

				wordToCount[word] = wordToCount[word] + 1;
			}

			/// top 20% самых редких
			var results = wordToCount.OrderBy(p => p.Value).Select(p => p.Key)
				.Take(wordToCount.Count / 5).ToList();

			return results;
		}

		public static bool IsEnglish(this string inputstring)
		{
			Regex regex = new Regex(@"[A-Za-z0-9_]");
			MatchCollection matches = regex.Matches(inputstring);

			if (matches.Count.Equals(inputstring.Length))
				return true;
			else
				return false;
		}
	}

	public class ContainsResult
	{
		public bool FoundAnything { get { return FoundWords.Count > 0; } }
		public List<string> FoundWords { get; set; }

		public ContainsResult()
		{
			FoundWords = new List<string>();
		}
	}
}
