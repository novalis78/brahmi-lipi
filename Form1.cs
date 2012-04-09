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
using System.Collections.Generic;
using System.Text;

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
        private Button BatchBtn;
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
		}

		//convert all unicode files in this directory into
		//brahmi-font viewable files
		public void batchConverter()
		{
			Console.WriteLine("... Brahmi Lipi - batch mode...");
			Console.ReadLine();
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            int no = 0;
            string[] files = Directory.GetFiles(startupPath);
            foreach (string file in files)
            {
                if ((!file.EndsWith("txt")))
                    continue;
                string line = "";
                int counting = 0;

                ImperialBrahmi IBrahmi = new ImperialBrahmi();

                List<string> newtext = new List<string>();
                StreamReader fileObject = new System.IO.StreamReader(file, Encoding.Default);
                while ((line = fileObject.ReadLine()) != null)
                {
                    counting++;

                    line = line.ToLower(); //make sure we handle uppercase and lowercase not as diacritics
                    newtext.Add(IBrahmi.Replace(line));
                    //newtext.Add("<h4>" + replace(line) + "</h4>");
                    //newtext.Add(line);
                   
                }
                no++;
                Console.WriteLine("converted " + no + " from " + files.Length);
                fileObject.Close();
                string filename = file + ".converted";
                StreamWriter tt = new StreamWriter(filename, false, Encoding.UTF8);
                foreach (string l in newtext)
                {
                    tt.WriteLine(l);
                }
                tt.Flush();
                tt.Close();

            }
		}

       

		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.BatchBtn = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.BatchBtn);
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
            // BatchBtn
            // 
            this.BatchBtn.Location = new System.Drawing.Point(19, 365);
            this.BatchBtn.Name = "BatchBtn";
            this.BatchBtn.Size = new System.Drawing.Size(72, 29);
            this.BatchBtn.TabIndex = 5;
            this.BatchBtn.Text = "Batch";
            this.BatchBtn.UseVisualStyleBackColor = true;
            this.BatchBtn.Click += new System.EventHandler(this.BatchBtn_Click);
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
            this.InputBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.BrahmiBox.Font = new System.Drawing.Font("Pali Brahmi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrahmiBox.Location = new System.Drawing.Point(0, 0);
            this.BrahmiBox.Name = "BrahmiBox";
            this.BrahmiBox.Size = new System.Drawing.Size(493, 227);
            this.BrahmiBox.TabIndex = 0;
            this.BrahmiBox.Text = "";
            this.BrahmiBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrahmiBox_KeyDown);
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
            this.Load += new System.EventHandler(this.MainForm_Load);
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
            if (e.KeyChar.ToString() == " ")
            {
                string[] words = textPuffer.Split(' ');
                string lastword = words[words.Length - 2];
                XenotypeBrahmi xBrahmi = new XenotypeBrahmi();
                string converted = xBrahmi.ConvertToBrahmi(lastword);
                converted = converted.Replace(" ", "  ");
                BrahmiBox.Text += " " + converted;
                BrahmiBox.SelectAll();
                BrahmiBox.SelectionFont = new System.Drawing.Font("Pali Brahmi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            //ImperialBrahmi IBrahmi = new ImperialBrahmi();
            //BrahmiBox.Text = IBrahmi.Replace(textPuffer);
			
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
                BrahmiBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
                //ImperialBrahmi IBrahmi = new ImperialBrahmi();
                XenotypeBrahmi xBrahmi = new XenotypeBrahmi();
                //BrahmiBox.Text += IBrahmi.Replace(InputBox.Text);
                BrahmiBox.Text += xBrahmi.ConvertToBrahmi(InputBox.Text);
				
                if(InputBox.Text.Length > 0)
					newBrahmi = InputBox.Text.Substring(0,InputBox.Text.Length-1);
				BrahmiBox.Text = "";
				textPuffer = "";
				textPuffer = xBrahmi.ConvertToBrahmi(newBrahmi);
                BrahmiBox.Text = xBrahmi.ConvertToBrahmi(newBrahmi);
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
            ImperialBrahmi IBrahmi = new ImperialBrahmi();
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader sr = new StreamReader(fs, System.Text.Encoding.Unicode);
			string source = sr.ReadToEnd();
			string destination = IBrahmi.Replace(source.ToLower());
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
                //ImperialBrahmi IBrahmi = new ImperialBrahmi();
                BrahmiBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
                XenotypeBrahmi xBrahmi = new XenotypeBrahmi();
                string converted = xBrahmi.ConvertToBrahmi(InputBox.Text);
                converted = converted.Replace(" ", "  ");
                BrahmiBox.Text += " " + converted;
                //BrahmiBox.Text += IBrahmi.Replace(InputBox.Text);
			}
		}

        private void BatchBtn_Click(object sender, EventArgs e)
        {
            batchConverter();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            XenotypeBrahmi xBrahmi = new XenotypeBrahmi();
            BrahmiBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            BrahmiBox.Font = new Font("Pali Brahmi", 16, System.Drawing.FontStyle.Regular);
            BrahmiBox.Text = "Aī";
            string uni = "devānaṁpiye piyadasi lājā hevaṁ āhā ye atikaṁtaṁ \naṁtalaṁ lājāne husa hevaṁ ichisu kathaṁ jane \ndhaṁmavaḍhiyā vāḍheya nocujane anulupāyā dhaṁmavaḍhiyā";
            string converted = xBrahmi.ConvertToBrahmi(uni);
            converted = converted.Replace(" ", "  ");
            BrahmiBox.Text += " " + converted;
            InputBox.Text = uni;
            //this.BrahmiBox.Text = s;
            //this.InputBox.Text = c.ToString();
        }

        private void BrahmiBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.V)
            {
                BrahmiBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
                BrahmiBox.Font = new System.Drawing.Font("Pali Brahmi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                string s = (string)Clipboard.GetDataObject().GetData(DataFormats.UnicodeText);
                BrahmiBox.Text += s;
                e.Handled = true; // disable Ctrl+V
                BrahmiBox.SelectAll();
                BrahmiBox.SelectionFont = new System.Drawing.Font("Pali Brahmi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            }
        }
		
	}
}

//this.BrahmiBox.Font = new System.Drawing.Font("Imperial Brahmi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));