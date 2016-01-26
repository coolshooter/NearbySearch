using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace NearbySearch
{
	public class FileHelper
	{
		public static List<string> ReadLines(string filename)
		{
			string ext = Path.GetExtension(filename).TrimStart('.');

			if (ext.ToLower() == "doc" || ext.ToLower() == "docx")
				return ReadAllLinesInMSWord(filename);
			else
				return File.ReadAllLines(filename).ToList();
		}

		static List<string> ReadAllLinesInMSWord(string filename)
		{
			Application word = new Application();
			Document doc = new Document();

			object path = filename;

			// Define an object to pass to the API for missing parameters
			object missing = System.Type.Missing;
			doc = word.Documents.Open(ref path,
					ref missing, ref missing, ref missing, ref missing,
					ref missing, ref missing, ref missing, ref missing,
					ref missing, ref missing, ref missing, ref missing,
					ref missing, ref missing, ref missing);

			List<string> result = new List<string>();
			int i = 0;
			int count = doc.Paragraphs.Count;

			foreach (Paragraph p in doc.Paragraphs)
			{
				string line = p.Range.Text.Trim();

				if (!string.IsNullOrEmpty(line))
					result.Add(line);

				i++;

				/// файл word медленно читается, поэтому ограничиваем 
				/// количество строк
				if (i > 1000)
					break;
			}

			/// файл word очень медленно читается, поэтому ограничиваем 
			/// количество строк
			//for (int i = 0; i < Math.Min(doc.Paragraphs.Count, 100); i++)
			//{
			//	string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
			//	if (temp != string.Empty)
			//		result.Add(temp);
			//}

			((_Document)doc).Close();
			((_Application)word).Quit();

			return result;
		}
	}
}
