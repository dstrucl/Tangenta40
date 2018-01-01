using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using ECB_ExchangeRates;

namespace ECB_ExchangeRates
{
	/// <summary>
	/// Summary description for ExRate.
	/// </summary>
	public class Form_ECBExchangeRates : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox cmbDate;
		private System.Windows.Forms.ComboBox cmbFromCountry;
		private System.Windows.Forms.ComboBox cmbToCountry;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtBelob;
		private System.Windows.Forms.TextBox txtHowMany;
		private System.Windows.Forms.Button btnCalculat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private RateLoad _kl = new RateLoad();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblRef;
		private ExchangeRate _dsExchangeRate = new ExchangeRate();


		public Form_ECBExchangeRates()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form_ECBExchangeRates));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.cmbDate = new System.Windows.Forms.ComboBox();
			this.cmbFromCountry = new System.Windows.Forms.ComboBox();
			this.cmbToCountry = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBelob = new System.Windows.Forms.TextBox();
			this.txtHowMany = new System.Windows.Forms.TextBox();
			this.btnCalculat = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblRef = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AccessibleDescription = resources.GetString("dataGrid1.AccessibleDescription");
			this.dataGrid1.AccessibleName = resources.GetString("dataGrid1.AccessibleName");
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("dataGrid1.Anchor")));
			this.dataGrid1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dataGrid1.BackgroundImage")));
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dataGrid1.CaptionFont = ((System.Drawing.Font)(resources.GetObject("dataGrid1.CaptionFont")));
			this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.CaptionText = resources.GetString("dataGrid1.CaptionText");
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("dataGrid1.Dock")));
			this.dataGrid1.Enabled = ((bool)(resources.GetObject("dataGrid1.Enabled")));
			this.dataGrid1.Font = ((System.Drawing.Font)(resources.GetObject("dataGrid1.Font")));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dataGrid1.ImeMode")));
			this.dataGrid1.Location = ((System.Drawing.Point)(resources.GetObject("dataGrid1.Location")));
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("dataGrid1.RightToLeft")));
			this.dataGrid1.Size = ((System.Drawing.Size)(resources.GetObject("dataGrid1.Size")));
			this.dataGrid1.TabIndex = ((int)(resources.GetObject("dataGrid1.TabIndex")));
			this.dataGrid1.Visible = ((bool)(resources.GetObject("dataGrid1.Visible")));
			// 
			// cmbDate
			// 
			this.cmbDate.AccessibleDescription = resources.GetString("cmbDate.AccessibleDescription");
			this.cmbDate.AccessibleName = resources.GetString("cmbDate.AccessibleName");
			this.cmbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmbDate.Anchor")));
			this.cmbDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmbDate.BackgroundImage")));
			this.cmbDate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmbDate.Dock")));
			this.cmbDate.Enabled = ((bool)(resources.GetObject("cmbDate.Enabled")));
			this.cmbDate.Font = ((System.Drawing.Font)(resources.GetObject("cmbDate.Font")));
			this.cmbDate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmbDate.ImeMode")));
			this.cmbDate.IntegralHeight = ((bool)(resources.GetObject("cmbDate.IntegralHeight")));
			this.cmbDate.ItemHeight = ((int)(resources.GetObject("cmbDate.ItemHeight")));
			this.cmbDate.Location = ((System.Drawing.Point)(resources.GetObject("cmbDate.Location")));
			this.cmbDate.MaxDropDownItems = ((int)(resources.GetObject("cmbDate.MaxDropDownItems")));
			this.cmbDate.MaxLength = ((int)(resources.GetObject("cmbDate.MaxLength")));
			this.cmbDate.Name = "cmbDate";
			this.cmbDate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmbDate.RightToLeft")));
			this.cmbDate.Size = ((System.Drawing.Size)(resources.GetObject("cmbDate.Size")));
			this.cmbDate.TabIndex = ((int)(resources.GetObject("cmbDate.TabIndex")));
			this.cmbDate.Text = resources.GetString("cmbDate.Text");
			this.cmbDate.Visible = ((bool)(resources.GetObject("cmbDate.Visible")));
			// 
			// cmbFromCountry
			// 
			this.cmbFromCountry.AccessibleDescription = resources.GetString("cmbFromCountry.AccessibleDescription");
			this.cmbFromCountry.AccessibleName = resources.GetString("cmbFromCountry.AccessibleName");
			this.cmbFromCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmbFromCountry.Anchor")));
			this.cmbFromCountry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmbFromCountry.BackgroundImage")));
			this.cmbFromCountry.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmbFromCountry.Dock")));
			this.cmbFromCountry.Enabled = ((bool)(resources.GetObject("cmbFromCountry.Enabled")));
			this.cmbFromCountry.Font = ((System.Drawing.Font)(resources.GetObject("cmbFromCountry.Font")));
			this.cmbFromCountry.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmbFromCountry.ImeMode")));
			this.cmbFromCountry.IntegralHeight = ((bool)(resources.GetObject("cmbFromCountry.IntegralHeight")));
			this.cmbFromCountry.ItemHeight = ((int)(resources.GetObject("cmbFromCountry.ItemHeight")));
			this.cmbFromCountry.Location = ((System.Drawing.Point)(resources.GetObject("cmbFromCountry.Location")));
			this.cmbFromCountry.MaxDropDownItems = ((int)(resources.GetObject("cmbFromCountry.MaxDropDownItems")));
			this.cmbFromCountry.MaxLength = ((int)(resources.GetObject("cmbFromCountry.MaxLength")));
			this.cmbFromCountry.Name = "cmbFromCountry";
			this.cmbFromCountry.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmbFromCountry.RightToLeft")));
			this.cmbFromCountry.Size = ((System.Drawing.Size)(resources.GetObject("cmbFromCountry.Size")));
			this.cmbFromCountry.TabIndex = ((int)(resources.GetObject("cmbFromCountry.TabIndex")));
			this.cmbFromCountry.Text = resources.GetString("cmbFromCountry.Text");
			this.cmbFromCountry.Visible = ((bool)(resources.GetObject("cmbFromCountry.Visible")));
			// 
			// cmbToCountry
			// 
			this.cmbToCountry.AccessibleDescription = resources.GetString("cmbToCountry.AccessibleDescription");
			this.cmbToCountry.AccessibleName = resources.GetString("cmbToCountry.AccessibleName");
			this.cmbToCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmbToCountry.Anchor")));
			this.cmbToCountry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmbToCountry.BackgroundImage")));
			this.cmbToCountry.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmbToCountry.Dock")));
			this.cmbToCountry.Enabled = ((bool)(resources.GetObject("cmbToCountry.Enabled")));
			this.cmbToCountry.Font = ((System.Drawing.Font)(resources.GetObject("cmbToCountry.Font")));
			this.cmbToCountry.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmbToCountry.ImeMode")));
			this.cmbToCountry.IntegralHeight = ((bool)(resources.GetObject("cmbToCountry.IntegralHeight")));
			this.cmbToCountry.ItemHeight = ((int)(resources.GetObject("cmbToCountry.ItemHeight")));
			this.cmbToCountry.Location = ((System.Drawing.Point)(resources.GetObject("cmbToCountry.Location")));
			this.cmbToCountry.MaxDropDownItems = ((int)(resources.GetObject("cmbToCountry.MaxDropDownItems")));
			this.cmbToCountry.MaxLength = ((int)(resources.GetObject("cmbToCountry.MaxLength")));
			this.cmbToCountry.Name = "cmbToCountry";
			this.cmbToCountry.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmbToCountry.RightToLeft")));
			this.cmbToCountry.Size = ((System.Drawing.Size)(resources.GetObject("cmbToCountry.Size")));
			this.cmbToCountry.TabIndex = ((int)(resources.GetObject("cmbToCountry.TabIndex")));
			this.cmbToCountry.Text = resources.GetString("cmbToCountry.Text");
			this.cmbToCountry.Visible = ((bool)(resources.GetObject("cmbToCountry.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// txtBelob
			// 
			this.txtBelob.AccessibleDescription = resources.GetString("txtBelob.AccessibleDescription");
			this.txtBelob.AccessibleName = resources.GetString("txtBelob.AccessibleName");
			this.txtBelob.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtBelob.Anchor")));
			this.txtBelob.AutoSize = ((bool)(resources.GetObject("txtBelob.AutoSize")));
			this.txtBelob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBelob.BackgroundImage")));
			this.txtBelob.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtBelob.Dock")));
			this.txtBelob.Enabled = ((bool)(resources.GetObject("txtBelob.Enabled")));
			this.txtBelob.Font = ((System.Drawing.Font)(resources.GetObject("txtBelob.Font")));
			this.txtBelob.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtBelob.ImeMode")));
			this.txtBelob.Location = ((System.Drawing.Point)(resources.GetObject("txtBelob.Location")));
			this.txtBelob.MaxLength = ((int)(resources.GetObject("txtBelob.MaxLength")));
			this.txtBelob.Multiline = ((bool)(resources.GetObject("txtBelob.Multiline")));
			this.txtBelob.Name = "txtBelob";
			this.txtBelob.PasswordChar = ((char)(resources.GetObject("txtBelob.PasswordChar")));
			this.txtBelob.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtBelob.RightToLeft")));
			this.txtBelob.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtBelob.ScrollBars")));
			this.txtBelob.Size = ((System.Drawing.Size)(resources.GetObject("txtBelob.Size")));
			this.txtBelob.TabIndex = ((int)(resources.GetObject("txtBelob.TabIndex")));
			this.txtBelob.Text = resources.GetString("txtBelob.Text");
			this.txtBelob.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtBelob.TextAlign")));
			this.txtBelob.Visible = ((bool)(resources.GetObject("txtBelob.Visible")));
			this.txtBelob.WordWrap = ((bool)(resources.GetObject("txtBelob.WordWrap")));
			// 
			// txtHowMany
			// 
			this.txtHowMany.AccessibleDescription = resources.GetString("txtHowMany.AccessibleDescription");
			this.txtHowMany.AccessibleName = resources.GetString("txtHowMany.AccessibleName");
			this.txtHowMany.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtHowMany.Anchor")));
			this.txtHowMany.AutoSize = ((bool)(resources.GetObject("txtHowMany.AutoSize")));
			this.txtHowMany.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtHowMany.BackgroundImage")));
			this.txtHowMany.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtHowMany.Dock")));
			this.txtHowMany.Enabled = ((bool)(resources.GetObject("txtHowMany.Enabled")));
			this.txtHowMany.Font = ((System.Drawing.Font)(resources.GetObject("txtHowMany.Font")));
			this.txtHowMany.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtHowMany.ImeMode")));
			this.txtHowMany.Location = ((System.Drawing.Point)(resources.GetObject("txtHowMany.Location")));
			this.txtHowMany.MaxLength = ((int)(resources.GetObject("txtHowMany.MaxLength")));
			this.txtHowMany.Multiline = ((bool)(resources.GetObject("txtHowMany.Multiline")));
			this.txtHowMany.Name = "txtHowMany";
			this.txtHowMany.PasswordChar = ((char)(resources.GetObject("txtHowMany.PasswordChar")));
			this.txtHowMany.ReadOnly = true;
			this.txtHowMany.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtHowMany.RightToLeft")));
			this.txtHowMany.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtHowMany.ScrollBars")));
			this.txtHowMany.Size = ((System.Drawing.Size)(resources.GetObject("txtHowMany.Size")));
			this.txtHowMany.TabIndex = ((int)(resources.GetObject("txtHowMany.TabIndex")));
			this.txtHowMany.Text = resources.GetString("txtHowMany.Text");
			this.txtHowMany.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtHowMany.TextAlign")));
			this.txtHowMany.Visible = ((bool)(resources.GetObject("txtHowMany.Visible")));
			this.txtHowMany.WordWrap = ((bool)(resources.GetObject("txtHowMany.WordWrap")));
			// 
			// btnCalculat
			// 
			this.btnCalculat.AccessibleDescription = resources.GetString("btnCalculat.AccessibleDescription");
			this.btnCalculat.AccessibleName = resources.GetString("btnCalculat.AccessibleName");
			this.btnCalculat.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnCalculat.Anchor")));
			this.btnCalculat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalculat.BackgroundImage")));
			this.btnCalculat.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnCalculat.Dock")));
			this.btnCalculat.Enabled = ((bool)(resources.GetObject("btnCalculat.Enabled")));
			this.btnCalculat.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnCalculat.FlatStyle")));
			this.btnCalculat.Font = ((System.Drawing.Font)(resources.GetObject("btnCalculat.Font")));
			this.btnCalculat.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculat.Image")));
			this.btnCalculat.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCalculat.ImageAlign")));
			this.btnCalculat.ImageIndex = ((int)(resources.GetObject("btnCalculat.ImageIndex")));
			this.btnCalculat.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnCalculat.ImeMode")));
			this.btnCalculat.Location = ((System.Drawing.Point)(resources.GetObject("btnCalculat.Location")));
			this.btnCalculat.Name = "btnCalculat";
			this.btnCalculat.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnCalculat.RightToLeft")));
			this.btnCalculat.Size = ((System.Drawing.Size)(resources.GetObject("btnCalculat.Size")));
			this.btnCalculat.TabIndex = ((int)(resources.GetObject("btnCalculat.TabIndex")));
			this.btnCalculat.Text = resources.GetString("btnCalculat.Text");
			this.btnCalculat.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCalculat.TextAlign")));
			this.btnCalculat.Visible = ((bool)(resources.GetObject("btnCalculat.Visible")));
			this.btnCalculat.Click += new System.EventHandler(this.btnCalculat_Click);
			// 
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			// 
			// label5
			// 
			this.label5.AccessibleDescription = resources.GetString("label5.AccessibleDescription");
			this.label5.AccessibleName = resources.GetString("label5.AccessibleName");
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
			this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
			this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
			this.label5.Enabled = ((bool)(resources.GetObject("label5.Enabled")));
			this.label5.Font = ((System.Drawing.Font)(resources.GetObject("label5.Font")));
			this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
			this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
			this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
			this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
			this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
			this.label5.Name = "label5";
			this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
			this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
			this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
			this.label5.Text = resources.GetString("label5.Text");
			this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
			this.label5.Visible = ((bool)(resources.GetObject("label5.Visible")));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = resources.GetString("label6.AccessibleDescription");
			this.label6.AccessibleName = resources.GetString("label6.AccessibleName");
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
			this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
			// 
			// label7
			// 
			this.label7.AccessibleDescription = resources.GetString("label7.AccessibleDescription");
			this.label7.AccessibleName = resources.GetString("label7.AccessibleName");
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label7.Anchor")));
			this.label7.AutoSize = ((bool)(resources.GetObject("label7.AutoSize")));
			this.label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label7.Dock")));
			this.label7.Enabled = ((bool)(resources.GetObject("label7.Enabled")));
			this.label7.Font = ((System.Drawing.Font)(resources.GetObject("label7.Font")));
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.ImageAlign")));
			this.label7.ImageIndex = ((int)(resources.GetObject("label7.ImageIndex")));
			this.label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label7.ImeMode")));
			this.label7.Location = ((System.Drawing.Point)(resources.GetObject("label7.Location")));
			this.label7.Name = "label7";
			this.label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label7.RightToLeft")));
			this.label7.Size = ((System.Drawing.Size)(resources.GetObject("label7.Size")));
			this.label7.TabIndex = ((int)(resources.GetObject("label7.TabIndex")));
			this.label7.Text = resources.GetString("label7.Text");
			this.label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.TextAlign")));
			this.label7.Visible = ((bool)(resources.GetObject("label7.Visible")));
			// 
			// lblRef
			// 
			this.lblRef.AccessibleDescription = resources.GetString("lblRef.AccessibleDescription");
			this.lblRef.AccessibleName = resources.GetString("lblRef.AccessibleName");
			this.lblRef.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblRef.Anchor")));
			this.lblRef.AutoSize = ((bool)(resources.GetObject("lblRef.AutoSize")));
			this.lblRef.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblRef.Dock")));
			this.lblRef.Enabled = ((bool)(resources.GetObject("lblRef.Enabled")));
			this.lblRef.Font = ((System.Drawing.Font)(resources.GetObject("lblRef.Font")));
			this.lblRef.Image = ((System.Drawing.Image)(resources.GetObject("lblRef.Image")));
			this.lblRef.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRef.ImageAlign")));
			this.lblRef.ImageIndex = ((int)(resources.GetObject("lblRef.ImageIndex")));
			this.lblRef.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblRef.ImeMode")));
			this.lblRef.Location = ((System.Drawing.Point)(resources.GetObject("lblRef.Location")));
			this.lblRef.Name = "lblRef";
			this.lblRef.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblRef.RightToLeft")));
			this.lblRef.Size = ((System.Drawing.Size)(resources.GetObject("lblRef.Size")));
			this.lblRef.TabIndex = ((int)(resources.GetObject("lblRef.TabIndex")));
			this.lblRef.Text = resources.GetString("lblRef.Text");
			this.lblRef.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblRef.TextAlign")));
			this.lblRef.Visible = ((bool)(resources.GetObject("lblRef.Visible")));
			// 
			// ExRate
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.lblRef);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCalculat);
			this.Controls.Add(this.txtHowMany);
			this.Controls.Add(this.txtBelob);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbToCountry);
			this.Controls.Add(this.cmbFromCountry);
			this.Controls.Add(this.cmbDate);
			this.Controls.Add(this.dataGrid1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "ExRate";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.ExRate_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ExRate_Load(object sender, System.EventArgs e)
		{
			_dsExchangeRate = _kl.LoadNationalBankExRate();
			lblRef.Text = "Reference : " + _kl.Author;
			dataGrid1.SetDataBinding(_dsExchangeRate, "Exchange");
			InitCombo();
		}

		private void InitCombo()
		{
			int DkIndex = 0;
			foreach(DataTable t in _dsExchangeRate.Tables)
			{
				foreach(DataRow r in t.Rows)
				{
					foreach(DataColumn c in t.Columns)
					{
						if( "Exchange" == t.TableName )
						{
							if( "Date" == c.ColumnName )
							{
								DateTime dato = (DateTime)r[c];
								cmbDate.Items.Add((object)dato.DayOfWeek + " "+ dato.ToLongDateString());
							}
						}

						if( "Country" == t.TableName )
						{
							if( "Name" == c.ColumnName )
							{
								if( "Euro" == (string)r[c] ) DkIndex++;
								if( DkIndex <= 1 )
								{
									cmbFromCountry.Items.Add((object)r[c]);
									cmbToCountry.Items.Add((object)r[c]);
								}
							}
						}
					}
				}
			}
			cmbDate.SelectedIndex = 0;
			cmbFromCountry.SelectedIndex = 0;
			cmbToCountry.SelectedIndex = 0;
		}

		private void btnCalculat_Click(object sender, System.EventArgs e)
		{
			int Date = cmbDate.SelectedIndex; 
			int FromC = cmbFromCountry.SelectedIndex; 
			int ToC		= cmbToCountry.SelectedIndex; 

			string FromLand = null;
			double dblFromLand = 0;
			string ToLand = null;
			double dblToLand = 0;

			DateTime dato = Convert.ToDateTime(cmbDate.Text);

			try 
			{
				DataRow drFound;

				// Find the Row specified in txtFindArg
				drFound = _dsExchangeRate.Tables["Exchange"].Rows.Find(Date);
				if (drFound == null) 
				{
					MessageBox.Show("No PK matches " + cmbDate.Text);
				}
				else 
				{
					if( Convert.ToDateTime(drFound[0]) == dato )
					{
						int Index = 0;
						foreach( DataRow choiceRow in drFound.GetChildRows("Exchange_Country"))
						{
							if( FromC == Index )
							{
								FromLand = choiceRow["Initial"].ToString();
								dblFromLand = (double)choiceRow["Rate"];
							}

							if( ToC == Index )
							{
								ToLand = choiceRow["Initial"].ToString();
								dblToLand = (double)choiceRow["Rate"];
							}

							Index++;
						}
					}
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.ToString());
			}
			
			label4.Text = FromLand;
			label5.Text = ToLand;
			string II = txtBelob.Text;
			double Input = Convert.ToDouble(II);

			txtHowMany.Text = Convert.ToString(ExRateValue(Input, dblFromLand,dblToLand,lblRef.Text ));
		}


		private static double ExRateValue(double Input, double FromContry, double ToContry, string reference)
		{
			double result = 0;
			if( 0 < reference.IndexOf("Danmarks Nationalbank",0,reference.Length ) )
			{
				if( ToContry == 0 ) return 0;
				result = (Input/ToContry)*FromContry;
			}
			else
			{
				result = (Input/FromContry)*ToContry;
			}
			result = Math.Round(result,2);

			return result;
		}
	}
}
