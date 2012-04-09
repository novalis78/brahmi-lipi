using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrahmiLipi
{
	/// <summary>
	/// Zusammenfassung für KeyHelp.
	/// </summary>
	public class KeyHelp : System.Windows.Forms.Form
	{
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public KeyHelp()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KeyHelp));
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.SuspendLayout();
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(496, 470);
			this.axWebBrowser1.TabIndex = 0;
			// 
			// KeyHelp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 470);
			this.Controls.Add(this.axWebBrowser1);
			this.Name = "KeyHelp";
			this.Text = "KeyHelp";
			this.Load += new System.EventHandler(this.KeyHelp_Load);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void KeyHelp_Load(object sender, System.EventArgs e)
		{
			object o = null;
			this.axWebBrowser1.Navigate("file:///C:/Documents%20and%20Settings/novalis78/My%20Documents/Visual%20Studio%20Projects/BrahmiLipi/bin/Debug/index.htm", ref o, ref o, ref o, ref o);
		}
	}
}
