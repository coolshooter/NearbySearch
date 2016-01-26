using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearbySearch
{
	public class SearchResultItem
	{
		public string FileName { get; set; }
		public int StartLineIndex { get; set; }
		public int EndLineIndex { get; set; }

		/// <summary>
		/// Если до 5 (или около того, см. код) строк, то весь релевантный текст,
		/// а если больше, то только последняя с найденным текстом.
		/// </summary>
		public string RelevantText { get; set; }

		public bool IsTextStartCutOut { get; set; }

		public override string ToString()
		{
			if (StartLineIndex >= 0 && EndLineIndex >= 0)
			{
				if (IsTextStartCutOut)
					return string.Format(
						"Файл: {0}\nПервая строка: {1}\nПоследняя: {2}\n" +
						"Завершающий блок найденного текста:\n{3}",
						FileName, StartLineIndex + 1, EndLineIndex + 1,
						RelevantText);
				else
					return string.Format(
						"Файл: {0}\nПервая строка: {1}\nПоследняя: {2}\n" +
						"{3}",
						FileName, StartLineIndex + 1, EndLineIndex + 1,
						RelevantText);
			}
			else
				return string.Format("Файл: {0}",
						FileName);
		}
	}
}
