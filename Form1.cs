using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NearbySearch.Properties;

/// Историческая справка: 
/// первая версия программы была написана за 21 минуту, она сразу стала рабочей
/// (выдала верный результат).
/// сумма всех написанных строк 1 версии = 74,
/// размер каждой не превышает примерно 55 символов.
namespace NearbySearch
{
	public partial class Form1 : Form
	{
		bool _isClosing = false;
		List<Control> _textBoxesLinkedWithSettings = new List<Control>();
		readonly int _maxFilesCountInResult = 20;

		public Form1()
		{
			InitializeComponent();

			//DateTime dt1 = new DateTime(2014, 4, 25, 18, 0, 0);
			//DateTime dt2 = new DateTime(2015, 10, 24);
			//var span = (dt2 - dt1);
			//var days = span.TotalDays;
			//var hrs = span.TotalHours;
			//var mins = span.TotalMinutes;

			//var dt3 = dt1 + TimeSpan.FromMinutes(777777);

			string[] args = Environment.GetCommandLineArgs();

			//if (args.Length > 1)
			//{
			//	string argsStr = "";
			//	args.ToList().ForEach(a => argsStr += a + ";");
			//	MessageBox.Show(argsStr);
			//	//$(SolutionDir)
			//}

			txtRootDir.Text = Settings.Default.RootDir;
			txtWords.Text = Settings.Default.Words;
			txtExtensions.Text = Settings.Default.Extensions;
			txtFileProcess.Text = Settings.Default.FileProcess;
			txtFileProcessArg.Text = Settings.Default.FileProcessArg;
			txtDistance.Text = Settings.Default.Distance;
			chbOpenFiles.Checked = Settings.Default.OpenFiles;
			chbFilenameSearch.Checked = Settings.Default.FilenameSearch;
			chbFilenameOnly.Checked = Settings.Default.FilenameSearchOnly;
			chbSearchInPath.Checked = Settings.Default.SearchInPath;
			chbSearchInPathOnly.Checked = Settings.Default.SearchInPathOnly;
			chbCaseSensitive.Checked = Settings.Default.CaseSensitive;

			if (string.IsNullOrWhiteSpace(txtExtensions.Text))
			{
				GetDefaultExtensions().ForEach(
					ext => txtExtensions.Text += ext + "\n");
			}

			_textBoxesLinkedWithSettings.Add(txtRootDir);
			_textBoxesLinkedWithSettings.Add(txtWords);
			_textBoxesLinkedWithSettings.Add(txtExtensions);
			_textBoxesLinkedWithSettings.Add(txtFileProcess);
			_textBoxesLinkedWithSettings.Add(txtFileProcessArg);
			_textBoxesLinkedWithSettings.Add(txtDistance);

			_textBoxesLinkedWithSettings.ForEach(txt =>
				{
					txt.TextChanged += (s, e) => SaveSettings();
					txt.LostFocus += (s, e) => SaveSettings();
				});

			chbOpenFiles.CheckedChanged += (s, e) => SaveSettings();
			chbOpenFiles.CheckedChanged += (s, e) => SaveSettings();
			chbFilenameSearch.CheckedChanged += (s, e) => SaveSettings();
			chbFilenameOnly.CheckedChanged += (s, e) => SaveSettings();
			chbSearchInPath.CheckedChanged += (s, e) => SaveSettings();
			chbSearchInPathOnly.CheckedChanged += (s, e) => SaveSettings();
			chbCaseSensitive.CheckedChanged += (s, e) => SaveSettings();

			FormClosing += Form1_FormClosing;
		}

		/// <summary>
		/// В каждом файле находит максимум по 1 результату.
		/// </summary>
		private void btnRun_Click(object sender, EventArgs e)
		{
			txtResult.Text = "";

			try
			{
				/// макс. расстояние между строками, в которых
				/// встретилось хотя бы 1 слово
				int maxDistance = int.Parse(txtDistance.Text);

				List<string> filters = new List<string>(
					txtExtensions.Text.Split(
						new char[] { '\n' }, 
						StringSplitOptions.RemoveEmptyEntries)
					.Where(ext => !string.IsNullOrWhiteSpace(ext))
					.Select(ext => "*." + ext));

				List<string> words = txtWords.Text.Split(
					new char[] { '\n' },
					StringSplitOptions.RemoveEmptyEntries)
					//.Select(w => w.Trim())
					.ToList();

				if (words.Any())
				{
					List<string> files = new List<string>();

					foreach (var ext in filters)
					{
						files.AddRange(
							Directory.GetFiles(
							txtRootDir.Text, ext,
							SearchOption.AllDirectories));
					}

					files = files.Distinct().ToList();

					//txtResult.Text += "\n" + 
					//	Engine2.Run(files, words, !chbCaseSensitive.Checked, maxDistance);

					//return;

					bool found = false;
					int foundInFiles = 0;

					foreach (var fileName in files)
					{
						if (foundInFiles >= _maxFilesCountInResult)
							break;

						SearchResultItem res = null;

						List<string> tempWords = new List<string>(words);
						bool searchInFile = true;

						ProcessSearchInFileOrPath(words, tempWords, 
							ref found, fileName, ref res, ref searchInFile);

						List<string> wordsLeftToFind = null;
						int startLineIndex = -1;
						int lastFoundWordLineIndex = -1;
						List<string> lines;

						//var sss = File.ReadAllText(fileName).GetRareWords();

						if (searchInFile)
							lines = FileHelper.ReadLines(fileName);
						else
							lines = new List<string>();

						Search(maxDistance, ref found, fileName, ref res, tempWords, 
							searchInFile, ref wordsLeftToFind, ref startLineIndex, 
							ref lastFoundWordLineIndex, lines, chbCaseSensitive.Checked);

						if (res != null)
						{
							foundInFiles++;

							if (chbOpenFiles.Checked)
							{
								System.Diagnostics.Process.Start(
									txtFileProcess.Text,
									txtFileProcessArg.Text + " " + res.FileName);
							}

							txtResult.Text += res.ToString() + "\n\n";
						}
					}

					if (!found)
						txtResult.Text = "Ничего не найдено.\n";
					else
					{
						if (foundInFiles >= _maxFilesCountInResult)
							txtResult.Text += "После первых " + _maxFilesCountInResult +
								" находок поиск прекратился во избежание слишком объемного результата.\n";

						if (!chbFilenameSearch.Checked && !chbFilenameOnly.Checked)
							txtResult.Text += "В каждом файле поиск велся до первой находки.\n";
					}
				}
				else
					txtResult.Text = "Введите, пожалуйста, тексты для поиска";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private static void Search(int maxDistance, ref bool found, string fileName, 
			ref SearchResultItem res, List<string> tempWords, bool searchInFile, 
			ref List<string> wordsLeftToFind, ref int startLineIndex, 
			ref int lastFoundWordLineIndex, List<string> lines,
			bool caseSensitive)
		{
			bool stopSearchInFile = false;

			for (int i = 0; i < lines.Count &&
				!stopSearchInFile && searchInFile; i++)
			{
				if (lastFoundWordLineIndex == -1 ||
					i - lastFoundWordLineIndex > maxDistance)
				{
					wordsLeftToFind = new List<string>(tempWords);
				}

				foreach (string word in tempWords)
				{
					if (lines[i].Contains(word, !caseSensitive))
					{
						if (wordsLeftToFind.Count == tempWords.Count)
							startLineIndex = i;

						wordsLeftToFind.Remove(word);
						lastFoundWordLineIndex = i;
					}

					if (wordsLeftToFind.Count == 0)
						break;
				}

				if (wordsLeftToFind.Count == 0)
				{
					//stopSearch = true;

					string relevantText = "";
					bool isTextStartCoutOut = false;

					if (lastFoundWordLineIndex - startLineIndex <= 5)
					{
						lines.Skip(startLineIndex)
								.Take(lastFoundWordLineIndex - startLineIndex + 1)
								.ToList()
								.ForEach(ln => relevantText += 
									ln.WiseTrimTabsAtStart() + "\n");
					}
					else
					{
						lines.Skip(lastFoundWordLineIndex - 5)
								.Take(6)
								.ToList()
								.ForEach(ln => relevantText +=
									ln.WiseTrimTabsAtStart() + "\n");

						isTextStartCoutOut = true;
					}

					res = new SearchResultItem()
					{
						FileName = fileName,
						StartLineIndex = startLineIndex,
						EndLineIndex = lastFoundWordLineIndex,
						RelevantText = relevantText,
						IsTextStartCutOut = isTextStartCoutOut
					};

					found = true;
					stopSearchInFile = true;
				}
			}
		}

		private void ProcessSearchInFileOrPath(List<string> words, List<string> tempWords, 
			ref bool found, string fileName, ref SearchResultItem res, 
			ref bool searchInFile)
		{
			if (chbFilenameSearch.Checked)
			{
				string fn = Path.GetFileName(fileName);

				foreach (string word in words)
				{
					if (fn.Contains(word, !chbCaseSensitive.Checked))
					{
						tempWords.Remove(word);
					}
				}

				if (chbFilenameOnly.Checked)
				{
					/// в этом случае поиск по файлу не интересует пользователя
					searchInFile = false;
				}
				else
				{
					/// хотя бы что-то должно найтись в названии файла,
					/// иначе файл пропускаем
					searchInFile = tempWords.Count < words.Count;
				}

				if (tempWords.Count == 0)
				{
					found = true;
					res = new SearchResultItem()
					{
						FileName = fileName,
						StartLineIndex = -1,
						EndLineIndex = -1,
						RelevantText = ""
					};
				}
			}
			else if (chbSearchInPath.Checked)
			{
				/// поиск по пути, включая расширение файла
				string fn = fileName;

				foreach (string word in words)
				{
					if (fn.Contains(word, !chbCaseSensitive.Checked))
					{
						tempWords.Remove(word);
					}
				}

				if (chbSearchInPathOnly.Checked)
				{
					/// в этом случае поиск по файлу не интересует пользователя
					searchInFile = false;
				}
				else
				{
					/// хотя бы что-то должно найтись в названии файла,
					/// иначе файл пропускаем
					searchInFile = tempWords.Count < words.Count;
				}

				if (tempWords.Count == 0)
				{
					found = true;
					res = new SearchResultItem()
					{
						FileName = fileName,
						StartLineIndex = -1,
						EndLineIndex = -1,
						RelevantText = ""
					};
				}
			}
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_isClosing = true;
		}

		void SaveSettings()
		{
			if (!_isClosing)
			{
				Settings.Default.RootDir = txtRootDir.Text;
				Settings.Default.Words = txtWords.Text;
				Settings.Default.Extensions = txtExtensions.Text;
				Settings.Default.FileProcess = txtFileProcess.Text;
				Settings.Default.FileProcessArg = txtFileProcessArg.Text;
				Settings.Default.Distance = txtDistance.Text;
				Settings.Default.OpenFiles = chbOpenFiles.Checked;
				Settings.Default.FilenameSearch = chbFilenameSearch.Checked;
				Settings.Default.FilenameSearchOnly = chbFilenameOnly.Checked;
				Settings.Default.SearchInPath = chbSearchInPath.Checked;
				Settings.Default.SearchInPathOnly = chbSearchInPathOnly.Checked;
				Settings.Default.Save();
			}
		}

		List<string> GetDefaultExtensions()
		{
			return new List<string>()
			{
				"cs", "aspx", "ascx", "js", "xml", "master"
			};
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog d = new FolderBrowserDialog();

			if (Directory.Exists(txtRootDir.Text))
				d.SelectedPath = txtRootDir.Text;

			var res = d.ShowDialog();

			if (res == System.Windows.Forms.DialogResult.OK)
			{
				txtRootDir.Text = d.SelectedPath;
				SaveSettings();
			}
		}
	}
}
