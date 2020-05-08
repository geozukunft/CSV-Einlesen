namespace CSV_Einlesen
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernSchließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lboRawData = new System.Windows.Forms.ListBox();
            this.lboSum = new System.Windows.Forms.ListBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInfotext = new System.Windows.Forms.Label();
            this.lblLastChanged = new System.Windows.Forms.Label();
            this.clearUserInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile_toolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernSchließenToolStripMenuItem,
            this.clearUserInputToolStripMenuItem,
            this.löschenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // OpenFile_toolStripMenuItem
            // 
            this.OpenFile_toolStripMenuItem.Name = "OpenFile_toolStripMenuItem";
            this.OpenFile_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.OpenFile_toolStripMenuItem.Text = "Datei öffnen";
            this.OpenFile_toolStripMenuItem.Click += new System.EventHandler(this.OpenFile_toolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // speichernSchließenToolStripMenuItem
            // 
            this.speichernSchließenToolStripMenuItem.Name = "speichernSchließenToolStripMenuItem";
            this.speichernSchließenToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.speichernSchließenToolStripMenuItem.Text = "Speichern und Schließen";
            this.speichernSchließenToolStripMenuItem.Click += new System.EventHandler(this.speichernSchließenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.schließenToolStripMenuItem.Text = "Schließen";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // lboRawData
            // 
            this.lboRawData.FormattingEnabled = true;
            this.lboRawData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lboRawData.Location = new System.Drawing.Point(39, 39);
            this.lboRawData.Name = "lboRawData";
            this.lboRawData.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lboRawData.Size = new System.Drawing.Size(135, 199);
            this.lboRawData.TabIndex = 12;
            // 
            // lboSum
            // 
            this.lboSum.FormattingEnabled = true;
            this.lboSum.Location = new System.Drawing.Point(230, 39);
            this.lboSum.Name = "lboSum";
            this.lboSum.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lboSum.Size = new System.Drawing.Size(129, 199);
            this.lboSum.TabIndex = 13;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(39, 281);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(177, 20);
            this.txtInput.TabIndex = 14;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // lblInfotext
            // 
            this.lblInfotext.AutoSize = true;
            this.lblInfotext.Location = new System.Drawing.Point(36, 304);
            this.lblInfotext.Name = "lblInfotext";
            this.lblInfotext.Size = new System.Drawing.Size(294, 13);
            this.lblInfotext.TabIndex = 15;
            this.lblInfotext.Text = "Daten bitte mit \";\" getrennt einfügen und mit Enter bestätigen";
            // 
            // lblLastChanged
            // 
            this.lblLastChanged.AutoSize = true;
            this.lblLastChanged.Location = new System.Drawing.Point(406, 39);
            this.lblLastChanged.Name = "lblLastChanged";
            this.lblLastChanged.Size = new System.Drawing.Size(35, 13);
            this.lblLastChanged.TabIndex = 16;
            this.lblLastChanged.Text = "label1";
            // 
            // clearUserInputToolStripMenuItem
            // 
            this.clearUserInputToolStripMenuItem.Name = "clearUserInputToolStripMenuItem";
            this.clearUserInputToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.clearUserInputToolStripMenuItem.Text = "Clear User Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 566);
            this.Controls.Add(this.lblLastChanged);
            this.Controls.Add(this.lblInfotext);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lboSum);
            this.Controls.Add(this.lboRawData);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "CSV - Daten";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFile_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernSchließenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.ListBox lboRawData;
        private System.Windows.Forms.ListBox lboSum;
        private System.Windows.Forms.TextBox txtInput;
        public System.Windows.Forms.Label lblInfotext;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.Label lblLastChanged;
        private System.Windows.Forms.ToolStripMenuItem clearUserInputToolStripMenuItem;
    }
}

