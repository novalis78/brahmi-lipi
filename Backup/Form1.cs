///
///
/// Copyright (C) 2005  Michael Davies <novalis78@gmx.net> 
/// All Rights Reserved.
///
/// This program is free software; you can redistribute it and/or
/// modify it under the terms of the GNU General Public License as
/// published by the Free Software Foundation; either version 2 of the
/// License, or (at your option) any later version.
/// 
/// This program is distributed in the hope that it will be useful, but
/// WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
/// General Public License for more details.
/// 
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA
/// 02111-1307, USA.
/// 
///
 
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BrahmiLipi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RichTextBox BrahmiBox;
		private System.Windows.Forms.RichTextBox InputBox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button ClearBtn;
		private System.Windows.Forms.Button ConvertBtn;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button KeyHelpBtn;
		private String textPuffer = "";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			InputBox.Focus();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			if(args.Length <= 0)
				Application.Run(new MainForm());
			else
				batchConverter();
		}

		//convert all unicode files in this directory into
		//brahmi-font viewable files
		public static void batchConverter()
		{
			Console.WriteLine("... Brahmi Lipi - batch mode...");
			Console.ReadLine();
		}
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.ConvertBtn = new System.Windows.Forms.Button();
			this.ClearBtn = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.KeyHelpBtn = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.InputBox = new System.Windows.Forms.RichTextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.BrahmiBox = new System.Windows.Forms.RichTextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ConvertBtn);
			this.panel1.Controls.Add(this.ClearBtn);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.KeyHelpBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(496, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(112, 462);
			this.panel1.TabIndex = 1;
			// 
			// ConvertBtn
			// 
			this.ConvertBtn.Location = new System.Drawing.Point(16, 408);
			this.ConvertBtn.Name = "ConvertBtn";
			this.ConvertBtn.Size = new System.Drawing.Size(75, 40);
			this.ConvertBtn.TabIndex = 4;
			this.ConvertBtn.Text = "Convert File";
			this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.Location = new System.Drawing.Point(19, 211);
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(75, 40);
			this.ClearBtn.TabIndex = 3;
			this.ClearBtn.Text = "Clear";
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(19, 120);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 40);
			this.button3.TabIndex = 2;
			this.button3.Text = "Save to File";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(19, 64);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 40);
			this.button2.TabIndex = 1;
			this.button2.Text = "Print";
			// 
			// KeyHelpBtn
			// 
			this.KeyHelpBtn.Location = new System.Drawing.Point(16, 8);
			this.KeyHelpBtn.Name = "KeyHelpBtn";
			this.KeyHelpBtn.Size = new System.Drawing.Size(75, 40);
			this.KeyHelpBtn.TabIndex = 0;
			this.KeyHelpBtn.Text = "Key Help";
			this.KeyHelpBtn.Click += new System.EventHandler(this.KeyHelpBtn_Click);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(493, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 462);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.InputBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 230);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(493, 232);
			this.panel2.TabIndex = 3;
			// 
			// InputBox
			// 
			this.InputBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.InputBox.Location = new System.Drawing.Point(0, 0);
			this.InputBox.Name = "InputBox";
			this.InputBox.Size = new System.Drawing.Size(493, 232);
			this.InputBox.TabIndex = 0;
			this.InputBox.Text = "";
			this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
			this.InputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
			this.InputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyUp);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 227);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(493, 3);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.BrahmiBox);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(493, 227);
			this.panel3.TabIndex = 5;
			// 
			// BrahmiBox
			// 
			this.BrahmiBox.BackColor = System.Drawing.Color.Linen;
			this.BrahmiBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrahmiBox.Font = new System.Drawing.Font("Imperial Brahmi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BrahmiBox.Location = new System.Drawing.Point(0, 0);
			this.BrahmiBox.Name = "BrahmiBox";
			this.BrahmiBox.Size = new System.Drawing.Size(493, 227);
			this.BrahmiBox.TabIndex = 0;
			this.BrahmiBox.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(608, 462);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "BrahmiLipi - your Imperial Brahmi Editor";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		void InputBoxKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//textPuffer += InputBox.Text.Substring(InputBox.Text.Length-1,1);
			
		}

		private void InputBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			textPuffer += e.KeyChar.ToString();
			BrahmiBox.Text = replace(textPuffer);
			
		}

		private string replace(string a)
		{
			string b = "";
			b = this.resolveUnicodeLetters(a);
			b = this.replaceDoubleConsonants(b);
			b = this.replaceKMedials(b);
			b = this.replaceKHMedials(b);
			b = this.replaceGMedials(b);
			b = this.replaceGHMedials(b);
			b = this.replaceCMedials(b);
			b = this.replaceCHMedials(b);
			b = this.replaceJMedials(b);
			b = this.replaceJHMedials(b);
			b = this.replaceNYMedials(b);
			b = this.replaceWMedials(b);
			b = this.replaceWHMedials(b);
			b = this.replaceFMedials(b);
			b = this.replaceFHMedials(b);
			b = this.replacePNMedials(b); // .n
			b = this.replaceTMedials(b);
			b = this.replaceTHMedials(b);
			b = this.replaceDMedials(b);
			b = this.replaceDHMedials(b);

			b = this.replaceNMedials(b);
			b = this.replaceMMedials(b);
			b = this.replacePMedials(b);
			b = this.replacePHMedials(b);
			b = this.replaceBMedials(b);
			b = this.replaceBHMedials(b);
			b = this.replaceYMedials(b);
			b = this.replaceRMedials(b);
			b = this.replaceLMedials(b);
			b = this.replaceVMedials(b);
			b = this.replaceSMedials(b);
			b = this.replaceHMedials(b);

			b = this.replaceConsonantA(b);
			
			return b;
		}

		private string replaceKMedials(string b)
		{
			b = b.Replace("kA", '\x0421'.ToString());
			b = b.Replace("ke", '\x0422'.ToString());
			b = b.Replace("ko", '\x0423'.ToString());
			b = b.Replace("ki", '\x0424'.ToString());
			b = b.Replace("kI", '\x0425'.ToString());
			b = b.Replace("ku", '\x0426'.ToString());
			b = b.Replace("kU", '\x0427'.ToString());
			return b;
		}
		//fertig 1A
		private string replaceKHMedials(string b)
		{
			b = b.Replace("khA", '\x043D'.ToString());
			b = b.Replace("khe", '\x043E'.ToString());
			b = b.Replace("kho", '\x043F'.ToString());
			b = b.Replace("khi", '\x0440'.ToString());
			b = b.Replace("khI", '\x0441'.ToString());
			b = b.Replace("khu", '\x0442'.ToString());
			b = b.Replace("khU", '\x0443'.ToString());
			return b;
		}
		//fertig 1A
		private string replaceGMedials(string b)
		{
			b = b.Replace("gA", '\x0428'.ToString());
			b = b.Replace("ge", '\x0429'.ToString());
			b = b.Replace("go", '\x042A'.ToString());
			b = b.Replace("gi", '\x042B'.ToString());
			b = b.Replace("gI", '\x042C'.ToString());
			b = b.Replace("gu", '\x042D'.ToString());
			b = b.Replace("gU", '\x042E'.ToString());
			return b;
		}
		private string replaceGHMedials(string b)
		{
			b = b.Replace("ghA", '\x2022'.ToString());
			b = b.Replace("ghe", '\x2013'.ToString());
			b = b.Replace("gho", '\x2014'.ToString());
			b = b.Replace("ghi", '\x02DC'.ToString());
			b = b.Replace("ghI", '\x2122'.ToString());
			b = b.Replace("ghu", '\x0161'.ToString());
			b = b.Replace("ghU", '\x203A'.ToString());
			return b;
		}
		//fertig
		private string replaceCMedials(string b)
		{
			b = b.Replace("cA", '\x042F'.ToString());
			b = b.Replace("ce", '\x0430'.ToString());
			b = b.Replace("co", '\x0431'.ToString());
			b = b.Replace("ci", '\x0432'.ToString());
			b = b.Replace("cI", '\x0433'.ToString());
			b = b.Replace("cu", '\x0434'.ToString());
			b = b.Replace("cU", '\x0435'.ToString());
			return b;
		}
		//fertig 1A
		private string replaceCHMedials(string b)
		{
			b = b.Replace("chA", '\x00A3'.ToString());
			b = b.Replace("che", '\x00A4'.ToString());
			b = b.Replace("cho", '\x00A5'.ToString());
			b = b.Replace("chi", '\x00A6'.ToString());
			b = b.Replace("chI", '\x00A7'.ToString());
			b = b.Replace("chu", '\x00A8'.ToString());
			b = b.Replace("chU", '\x00A9'.ToString());
			return b;
		}
		//fertig 1A
		private string replaceJMedials(string b)
		{
			b = b.Replace("jA", '\x00AA'.ToString());
			b = b.Replace("je", '\x00AC'.ToString());
			b = b.Replace("jo", '\x00AB'.ToString());
			b = b.Replace("ji", '\x00B0'.ToString());
			b = b.Replace("jI", '\x0444'.ToString());
			b = b.Replace("ju", '\x00AE'.ToString());
			b = b.Replace("jU", '\x00AF'.ToString());
			return b;
		}
		private string replaceJHMedials(string b)
		{
			b = b.Replace("jhA", '\x00B1'.ToString());
			b = b.Replace("jhe", '\x00B5'.ToString());
			b = b.Replace("jho", '\x00B6'.ToString());
			b = b.Replace("jhi", '\x00B7'.ToString());
			b = b.Replace("jhI", '\x00B2'.ToString());
			b = b.Replace("jhu", '\x00B3'.ToString());
			b = b.Replace("jhU", '\x00B4'.ToString());
			return b;
		}
		private string replaceNYMedials(string b)
		{
			b = b.Replace("zA", '\x00BB'.ToString());
			b = b.Replace("ze", '\x00BD'.ToString());
			b = b.Replace("zo", '\x00BC'.ToString());
			b = b.Replace("zi", '\x00B8'.ToString());
			b = b.Replace("zI", '\x00B9'.ToString());
			b = b.Replace("zu", '\x00BA'.ToString());
			b = b.Replace("zU", '\x00BE'.ToString());
			return b;
		}
		private string replaceWMedials(string b)
		{
			b = b.Replace("wA", '\x00C1'.ToString());
			b = b.Replace("we", '\x00C0'.ToString());
			b = b.Replace("wo", '\x00C5'.ToString());
			b = b.Replace("wi", '\x00BF'.ToString());
			b = b.Replace("wI", '\x00C2'.ToString());
			b = b.Replace("wu", '\x00C4'.ToString());
			b = b.Replace("wU", '\x00C3'.ToString());
			return b;
		}
		private string replaceWHMedials(string b)
		{
			b = b.Replace("whA", '\x00CC'.ToString());
			b = b.Replace("whe", '\x00C7'.ToString());
			b = b.Replace("who", '\x00C8'.ToString());
			b = b.Replace("whi", '\x00C6'.ToString());
			b = b.Replace("whI", '\x00C9'.ToString());
			b = b.Replace("whu", '\x00CA'.ToString());
			b = b.Replace("whU", '\x00CB'.ToString());
			return b;
		}
		private string replaceFMedials(string b)
		{
			b = b.Replace("fA", '\x00CD'.ToString());
			b = b.Replace("fe", '\x00D2'.ToString());
			b = b.Replace("fo", '\x00D0'.ToString());
			b = b.Replace("fi", '\x00D1'.ToString());
			b = b.Replace("fI", '\x00D3'.ToString());
			b = b.Replace("fu", '\x00CF'.ToString());
			b = b.Replace("fU", '\x00CE'.ToString());
			return b;
		}
		private string replaceFHMedials(string b)
		{
			b = b.Replace("fhA", '\x00D4'.ToString());
			b = b.Replace("fhe", '\x00D5'.ToString());
			b = b.Replace("fho", '\x00D6'.ToString());
			b = b.Replace("fhi", '\x00D7'.ToString());
			b = b.Replace("fhI", '\x00D8'.ToString());
			b = b.Replace("fhu", '\x00D9'.ToString());
			b = b.Replace("fhU", '\x00DA'.ToString());
			return b;
		}
		private string replacePNMedials(string b)
		{
			b = b.Replace("NA", '\x00DB'.ToString());
			b = b.Replace("Ne", '\x00DC'.ToString());
			b = b.Replace("No", '\x00DD'.ToString());
			b = b.Replace("Ni", '\x00DE'.ToString());
			b = b.Replace("NI", '\x00DF'.ToString());
			b = b.Replace("Nu", '\x00E0'.ToString());
			b = b.Replace("NU", '\x00E1'.ToString());
			return b;
		}
		private string replaceTMedials(string b)
		{
			b = b.Replace("tA", '\x00E2'.ToString());
			b = b.Replace("te", '\x00E8'.ToString());
			b = b.Replace("to", '\x00E4'.ToString());
			b = b.Replace("ti", '\x00E6'.ToString());
			b = b.Replace("tI", '\x00E3'.ToString());
			b = b.Replace("tu", '\x00E7'.ToString());
			b = b.Replace("tU", '\x00E5'.ToString());
			return b;
		}
		private string replaceTHMedials(string b)
		{
			b = b.Replace("thA", '\x00EA'.ToString());
			b = b.Replace("the", '\x00EB'.ToString());
			b = b.Replace("tho", '\x00EC'.ToString());
			b = b.Replace("thi", '\x00E9'.ToString());
			b = b.Replace("thI", '\x00EE'.ToString());
			b = b.Replace("thu", '\x00EF'.ToString());
			b = b.Replace("thU", '\x00ED'.ToString());
			return b;
		}
		private string replaceDMedials(string b)
		{
			b = b.Replace("dA", '\x00F1'.ToString());
			b = b.Replace("de", '\x00F2'.ToString());
			b = b.Replace("do", '\x00F0'.ToString());
			b = b.Replace("di", '\x00F3'.ToString());
			b = b.Replace("dI", '\x00F5'.ToString());
			b = b.Replace("du", '\x00F6'.ToString());
			b = b.Replace("dU", '\x00F4'.ToString());
			return b;
		}
		private string replaceDHMedials(string b)
		{
			b = b.Replace("dhA", '\x0451'.ToString());
			b = b.Replace("dhe", '\x00F8'.ToString());
			b = b.Replace("dho", '\x00F9'.ToString());
			b = b.Replace("dhi", '\x00FC'.ToString());
			b = b.Replace("dhI", '\x00FB'.ToString());
			b = b.Replace("dhu", '\x00FA'.ToString());
			b = b.Replace("dhU", '\x00F7'.ToString());
			return b;
		}
		private string replaceNMedials(string b)
		{
			b = b.Replace("nA", '\x0388'.ToString());
			b = b.Replace("ne", '\x0389'.ToString());
			b = b.Replace("no", '\x00FD'.ToString());
			b = b.Replace("ni", '\x00FE'.ToString());
			b = b.Replace("nI", '\x038A'.ToString());
			b = b.Replace("nu", '\x00F6'.ToString());
			b = b.Replace("nU", '\x0387'.ToString());
			return b;
		}
		private string replacePMedials(string b)
		{
			b = b.Replace("pA", '\x038C'.ToString());
			b = b.Replace("pe", '\x0390'.ToString());
			b = b.Replace("po", '\x038E'.ToString());
			b = b.Replace("pi", '\x0391'.ToString());
			b = b.Replace("pI", '\x038F'.ToString());
			b = b.Replace("pu", '\x0392'.ToString());
			b = b.Replace("pU", '\x0393'.ToString());
			return b;
		}
		private string replacePHMedials(string b)
		{
			b = b.Replace("phA", '\x0399'.ToString());
			b = b.Replace("phe", '\x0396'.ToString());
			b = b.Replace("pho", '\x0394'.ToString());
			b = b.Replace("phi", '\x0395'.ToString());
			b = b.Replace("phI", '\x0397'.ToString());
			b = b.Replace("phu", '\x039A'.ToString());
			b = b.Replace("phU", '\x0398'.ToString());
			return b;
		}
		private string replaceBMedials(string b)
		{
			b = b.Replace("bA", '\x03A1'.ToString());
			b = b.Replace("be", '\x039C'.ToString());
			b = b.Replace("bo", '\x039D'.ToString());
			b = b.Replace("bi", '\x039E'.ToString());
			b = b.Replace("bI", '\x039F'.ToString());
			b = b.Replace("bu", '\x03A0'.ToString());
			b = b.Replace("bU", '\x039B'.ToString());
			return b;
		}
		private string replaceBHMedials(string b)
		{
			b = b.Replace("bhA", '\x03A6'.ToString());
			b = b.Replace("bhe", '\x03A7'.ToString());
			b = b.Replace("bho", '\x03A8'.ToString());
			b = b.Replace("bhi", '\x03A9'.ToString());
			b = b.Replace("bhI", '\x03A3'.ToString());
			b = b.Replace("bhu", '\x03A4'.ToString());
			b = b.Replace("bhU", '\x03A5'.ToString());
			return b;
		}
		private string replaceMMedials(string b)
		{
			b = b.Replace("mA", '\x03AA'.ToString());
			b = b.Replace("me", '\x03AB'.ToString());
			b = b.Replace("mo", '\x03AC'.ToString());
			b = b.Replace("mi", '\x03AD'.ToString());
			b = b.Replace("mI", '\x03AE'.ToString());
			b = b.Replace("mu", '\x03AF'.ToString());
			b = b.Replace("mU", '\x03B0'.ToString());
			return b;
		}
		private string replaceYMedials(string b)
		{
			b = b.Replace("yA", '\x03B1'.ToString());
			b = b.Replace("ye", '\x03B2'.ToString());
			b = b.Replace("yo", '\x03B3'.ToString());
			b = b.Replace("yi", '\x03B4'.ToString());
			b = b.Replace("yI", '\x03B5'.ToString());
			b = b.Replace("yu", '\x03B6'.ToString());
			b = b.Replace("yU", '\x03B7'.ToString());
			return b;
		}
		private string replaceRMedials(string b)
		{
			b = b.Replace("rA", '\x03B8'.ToString());
			b = b.Replace("re", '\x03B9'.ToString());
			b = b.Replace("ro", '\x03BA'.ToString());
			b = b.Replace("ri", '\x03BB'.ToString());
			b = b.Replace("rI", '\x03BC'.ToString());
			b = b.Replace("ru", '\x03BD'.ToString());
			b = b.Replace("rU", '\x03BE'.ToString());
			return b;
		}
		private string replaceLMedials(string b)
		{
			b = b.Replace("lA", '\x03BF'.ToString());
			b = b.Replace("le", '\x03C0'.ToString());
			b = b.Replace("lo", '\x03C1'.ToString());
			b = b.Replace("li", '\x03C2'.ToString());
			b = b.Replace("lI", '\x03C3'.ToString());
			b = b.Replace("lu", '\x03C4'.ToString());
			b = b.Replace("lU", '\x03C5'.ToString());
			return b;
		}
		private string replaceVMedials(string b)
		{
			b = b.Replace("vA", '\x03C6'.ToString());
			b = b.Replace("ve", '\x03C7'.ToString());
			b = b.Replace("vo", '\x03C8'.ToString());
			b = b.Replace("vi", '\x03C9'.ToString());
			b = b.Replace("vI", '\x03CA'.ToString());
			b = b.Replace("vu", '\x03CB'.ToString());
			b = b.Replace("vU", '\x03CC'.ToString());
			return b;
		}
		private string replaceSMedials(string b)
		{
			b = b.Replace("sA", '\x040E'.ToString());
			b = b.Replace("se", '\x040F'.ToString());
			b = b.Replace("so", '\x0410'.ToString());
			b = b.Replace("si", '\x0411'.ToString());
			b = b.Replace("sI", '\x0412'.ToString());
			b = b.Replace("su", '\x0413'.ToString());
			b = b.Replace("sU", '\x0414'.ToString());
			return b;
		}
		private string replaceHMedials(string b)
		{
			b = b.Replace("hA", '\x0415'.ToString());
			b = b.Replace("he", '\x0416'.ToString());
			b = b.Replace("ho", '\x0417'.ToString());
			b = b.Replace("hi", '\x0418'.ToString());
			b = b.Replace("hI", '\x0419'.ToString());
			b = b.Replace("hu", '\x041A'.ToString());
			b = b.Replace("hU", '\x041B'.ToString());
			return b;
		}
		private string replaceConsonantA(string b)
		{	
			b = b.Replace("ba", "b");b = b.Replace("bha", "B");b = b.Replace("bh", "B");
			b = b.Replace("ca", "c");b = b.Replace("cha", "C");b = b.Replace("ch", "C");
			b = b.Replace("da", "d");b = b.Replace("dha", "D");b = b.Replace("dh", "D");
			b = b.Replace("fa", "f");b = b.Replace("fha", "F");b = b.Replace("fh", "F");
			b = b.Replace("ga", "g");b = b.Replace("gha", "G");b = b.Replace("gh", "G");
			b = b.Replace("ha", "h");
			b = b.Replace("ja", "j");b = b.Replace("jha", "J");b = b.Replace("jh", "J");
			b = b.Replace("ka", "k");b = b.Replace("kha", "K");b = b.Replace("kh", "K");
			b = b.Replace("la", "l");
			b = b.Replace("ma", "m");b = b.Replace("Ma", "M");
			b = b.Replace("na", "n");b = b.Replace("Na", "N");
			b = b.Replace("pa", "p");b = b.Replace("pha", "P");b = b.Replace("ph", "P");
			b = b.Replace("qa", "q");
			b = b.Replace("ra", "r");b = b.Replace("Ra", "R");
			b = b.Replace("sa", "s");
			b = b.Replace("ta", "t");b = b.Replace("tha", "T");b = b.Replace("th", "T");
			b = b.Replace("va", "v");
			b = b.Replace("wa", "w");b = b.Replace("Wa", "W");
			b = b.Replace("xa", "x");
			b = b.Replace("ya", "y");
			b = b.Replace("za", "z");
			return b;
		}
		

		//makes for the asokan magadhi touch
		//if used, start as first replacement...
		private string replaceDoubleConsonants(string dd)
		{
			dd = dd.Replace("ss", "s");
			dd = dd.Replace("cc", "c");
			dd = dd.Replace("dd", "d");
			dd = dd.Replace("mm", "Mm");
			dd = dd.Replace("nn", "Mn");
			dd = dd.Replace("zz", "Mz");
			dd = dd.Replace("NN", "MN");
			dd = dd.Replace("mb", "Mb");
			dd = dd.Replace("mB", "MB");
			dd = dd.Replace("mp", "Mp");
			dd = dd.Replace("mP", "MP");
			dd = dd.Replace("nt", "Mt");
			dd = dd.Replace("zc", "Mc");
			dd = dd.Replace("zj", "Mj");
			return dd;
		}

		private string resolveUnicodeLetters(string b)
		{
			b = b.Replace("ṃ", "M");
			b = b.Replace("ā", "A");
			b = b.Replace("ī", "I");
			b = b.Replace("ū", "U");
			b = b.Replace("ḍ", "f");
			b = b.Replace("ṭ", "w");
			b = b.Replace("ḷ", "l");//no letter!
			b = b.Replace("ṅ", "M");
			b = b.Replace("ṇ", "N");
			b = b.Replace("ñ", "y");
			return b;
		}

		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
		
		}

		private void InputBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		     /*if( ( e.KeyCode == Keys.M ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ṃ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.A ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ā";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.I ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ī";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.U ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ū";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.D ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ḍ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.T ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ṭ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.L ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ḷ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.G ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ṅ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.N ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ṇ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}
			else if( ( e.KeyCode == Keys.J ) && ( e.Modifiers == Keys.Alt ) )
			{
				InputBox.Text += "ñ";
				string cmd = "{RIGHT " + InputBox.Text.Length.ToString() + "}";
				SendKeys.Send(cmd);
			}*/
			if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
			{
			//		BrahmiBox.Text += this.replace(InputBox.Text);
			}
			if(e.KeyValue == 8)
			{
				string newBrahmi = "";
				if(InputBox.Text.Length > 0)
					newBrahmi = InputBox.Text.Substring(0,InputBox.Text.Length-1);
				BrahmiBox.Text = "";
				textPuffer = "";
				textPuffer = this.replace(newBrahmi);
				BrahmiBox.Text  = this.replace(newBrahmi);
			}
		}

		private void ClearBtn_Click(object sender, System.EventArgs e)
		{
			textPuffer = "";
			InputBox.Text = "";
			BrahmiBox.Text = "";
		}

		private void ConvertBtn_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.OK == openFileDialog1.ShowDialog())
			{
				convert(openFileDialog1.FileName);
			}
		}

		private void convert(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader sr = new StreamReader(fs, System.Text.Encoding.Unicode);
			string source = sr.ReadToEnd();
			string destination = replace(source.ToLower());
			fs.Close();
			sr.Close();
			FileStream fss = new FileStream(path + ".bl.txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(fss, System.Text.Encoding.Unicode);
			sw.Write(destination);
		}

		private void KeyHelpBtn_Click(object sender, System.EventArgs e)
		{
			KeyHelp kh = new KeyHelp();
			kh.Show();
		}

		private void InputBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
			{
				BrahmiBox.Text += this.replace(InputBox.Text);
			}
		}
		
	}
}
