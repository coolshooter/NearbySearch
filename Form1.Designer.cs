namespace NearbySearch
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRun = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWords = new System.Windows.Forms.RichTextBox();
			this.txtResult = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDistance = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chbOpenFiles = new System.Windows.Forms.CheckBox();
			this.txtExtensions = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFileProcess = new System.Windows.Forms.TextBox();
			this.txtFileProcessArg = new System.Windows.Forms.TextBox();
			this.txtRootDir = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.chbFilenameSearch = new System.Windows.Forms.CheckBox();
			this.chbFilenameOnly = new System.Windows.Forms.CheckBox();
			this.chbSearchInPathOnly = new System.Windows.Forms.CheckBox();
			this.chbSearchInPath = new System.Windows.Forms.CheckBox();
			this.chbCaseSensitive = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.Location = new System.Drawing.Point(532, 388);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(100, 52);
			this.btnRun.TabIndex = 1;
			this.btnRun.Text = "Найти";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(311, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Корневая папка, в которой будет идти поиск:";
			// 
			// txtWords
			// 
			this.txtWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtWords.Location = new System.Drawing.Point(22, 81);
			this.txtWords.Name = "txtWords";
			this.txtWords.Size = new System.Drawing.Size(457, 73);
			this.txtWords.TabIndex = 3;
			this.txtWords.Text = "";
			// 
			// txtResult
			// 
			this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResult.Location = new System.Drawing.Point(22, 236);
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(610, 146);
			this.txtResult.TabIndex = 4;
			this.txtResult.Text = "";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(311, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Тексты для поиска, разделенные переносом:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 213);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Результат:";
			// 
			// txtDistance
			// 
			this.txtDistance.Location = new System.Drawing.Point(22, 185);
			this.txtDistance.Name = "txtDistance";
			this.txtDistance.Size = new System.Drawing.Size(81, 22);
			this.txtDistance.TabIndex = 7;
			this.txtDistance.Text = "5";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(247, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Макс. кол-во строк между текстами:";
			// 
			// chbOpenFiles
			// 
			this.chbOpenFiles.AutoSize = true;
			this.chbOpenFiles.Location = new System.Drawing.Point(120, 187);
			this.chbOpenFiles.Name = "chbOpenFiles";
			this.chbOpenFiles.Size = new System.Drawing.Size(151, 21);
			this.chbOpenFiles.TabIndex = 9;
			this.chbOpenFiles.Text = "Открыть файлы в:";
			this.chbOpenFiles.UseVisualStyleBackColor = true;
			// 
			// txtExtensions
			// 
			this.txtExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExtensions.Location = new System.Drawing.Point(496, 81);
			this.txtExtensions.Name = "txtExtensions";
			this.txtExtensions.Size = new System.Drawing.Size(136, 127);
			this.txtExtensions.TabIndex = 10;
			this.txtExtensions.Text = "";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(483, 61);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(149, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "Расширения файлов:";
			// 
			// txtFileProcess
			// 
			this.txtFileProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileProcess.Location = new System.Drawing.Point(273, 186);
			this.txtFileProcess.Name = "txtFileProcess";
			this.txtFileProcess.Size = new System.Drawing.Size(151, 22);
			this.txtFileProcess.TabIndex = 12;
			this.txtFileProcess.Text = "devenv.exe";
			// 
			// txtFileProcessArg
			// 
			this.txtFileProcessArg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileProcessArg.Location = new System.Drawing.Point(430, 187);
			this.txtFileProcessArg.Name = "txtFileProcessArg";
			this.txtFileProcessArg.Size = new System.Drawing.Size(49, 22);
			this.txtFileProcessArg.TabIndex = 13;
			this.txtFileProcessArg.Text = "/edit";
			// 
			// txtRootDir
			// 
			this.txtRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRootDir.Location = new System.Drawing.Point(22, 30);
			this.txtRootDir.Name = "txtRootDir";
			this.txtRootDir.Size = new System.Drawing.Size(521, 22);
			this.txtRootDir.TabIndex = 14;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(549, 25);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(83, 29);
			this.btnBrowse.TabIndex = 15;
			this.btnBrowse.Text = "Обзор...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// chbFilenameSearch
			// 
			this.chbFilenameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chbFilenameSearch.AutoSize = true;
			this.chbFilenameSearch.Location = new System.Drawing.Point(22, 390);
			this.chbFilenameSearch.Name = "chbFilenameSearch";
			this.chbFilenameSearch.Size = new System.Drawing.Size(194, 21);
			this.chbFilenameSearch.TabIndex = 16;
			this.chbFilenameSearch.Text = "Поиск в названии файла";
			this.chbFilenameSearch.UseVisualStyleBackColor = true;
			// 
			// chbFilenameOnly
			// 
			this.chbFilenameOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chbFilenameOnly.AutoSize = true;
			this.chbFilenameOnly.Location = new System.Drawing.Point(243, 390);
			this.chbFilenameOnly.Name = "chbFilenameOnly";
			this.chbFilenameOnly.Size = new System.Drawing.Size(127, 21);
			this.chbFilenameOnly.TabIndex = 17;
			this.chbFilenameOnly.Text = "и только в нем";
			this.chbFilenameOnly.UseVisualStyleBackColor = true;
			// 
			// chbSearchInPathOnly
			// 
			this.chbSearchInPathOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chbSearchInPathOnly.AutoSize = true;
			this.chbSearchInPathOnly.Location = new System.Drawing.Point(243, 417);
			this.chbSearchInPathOnly.Name = "chbSearchInPathOnly";
			this.chbSearchInPathOnly.Size = new System.Drawing.Size(127, 21);
			this.chbSearchInPathOnly.TabIndex = 19;
			this.chbSearchInPathOnly.Text = "и только в нем";
			this.chbSearchInPathOnly.UseVisualStyleBackColor = true;
			// 
			// chbSearchInPath
			// 
			this.chbSearchInPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chbSearchInPath.AutoSize = true;
			this.chbSearchInPath.Location = new System.Drawing.Point(22, 417);
			this.chbSearchInPath.Name = "chbSearchInPath";
			this.chbSearchInPath.Size = new System.Drawing.Size(215, 21);
			this.chbSearchInPath.TabIndex = 18;
			this.chbSearchInPath.Text = "Поиск во всем пути к файлу";
			this.chbSearchInPath.UseVisualStyleBackColor = true;
			// 
			// chbCaseSensitive
			// 
			this.chbCaseSensitive.AutoSize = true;
			this.chbCaseSensitive.Location = new System.Drawing.Point(328, 60);
			this.chbCaseSensitive.Name = "chbCaseSensitive";
			this.chbCaseSensitive.Size = new System.Drawing.Size(151, 21);
			this.chbCaseSensitive.TabIndex = 20;
			this.chbCaseSensitive.Text = "с учетом регистра";
			this.chbCaseSensitive.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(656, 450);
			this.Controls.Add(this.chbCaseSensitive);
			this.Controls.Add(this.chbSearchInPathOnly);
			this.Controls.Add(this.chbSearchInPath);
			this.Controls.Add(this.chbFilenameOnly);
			this.Controls.Add(this.chbFilenameSearch);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtRootDir);
			this.Controls.Add(this.txtFileProcessArg);
			this.Controls.Add(this.txtFileProcess);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtExtensions);
			this.Controls.Add(this.chbOpenFiles);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDistance);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.txtWords);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRun);
			this.MinimumSize = new System.Drawing.Size(674, 432);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Поиск рядом стоящего текста. Автор: Сергей Лютько.";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox txtWords;
		private System.Windows.Forms.RichTextBox txtResult;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDistance;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chbOpenFiles;
		private System.Windows.Forms.RichTextBox txtExtensions;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFileProcess;
		private System.Windows.Forms.TextBox txtFileProcessArg;
		private System.Windows.Forms.TextBox txtRootDir;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.CheckBox chbFilenameSearch;
		private System.Windows.Forms.CheckBox chbFilenameOnly;
		private System.Windows.Forms.CheckBox chbSearchInPathOnly;
		private System.Windows.Forms.CheckBox chbSearchInPath;
		private System.Windows.Forms.CheckBox chbCaseSensitive;
	}
}

