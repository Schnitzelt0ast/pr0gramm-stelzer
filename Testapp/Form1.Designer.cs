namespace Testapp
{
    partial class Benisvergleich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Benisvergleich));
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.userInput = new System.Windows.Forms.TextBox();
            this.benisInput = new System.Windows.Forms.NumericUpDown();
            this.bannedInput = new System.Windows.Forms.CheckBox();
            this.output = new System.Windows.Forms.Label();
            this.versionlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.benisInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.label1.Name = "label1";
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.submit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // userInput
            // 
            resources.ApplyResources(this.userInput, "userInput");
            this.userInput.Name = "userInput";
            // 
            // benisInput
            // 
            resources.ApplyResources(this.benisInput, "benisInput");
            this.benisInput.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.benisInput.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.benisInput.Name = "benisInput";
            // 
            // bannedInput
            // 
            resources.ApplyResources(this.bannedInput, "bannedInput");
            this.bannedInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.bannedInput.Name = "bannedInput";
            this.bannedInput.UseVisualStyleBackColor = true;
            // 
            // output
            // 
            resources.ApplyResources(this.output, "output");
            this.output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.output.Name = "output";
            // 
            // versionlabel
            // 
            resources.ApplyResources(this.versionlabel, "versionlabel");
            this.versionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.versionlabel.Name = "versionlabel";
            // 
            // Benisvergleich
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.output);
            this.Controls.Add(this.bannedInput);
            this.Controls.Add(this.benisInput);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Benisvergleich";
            ((System.ComponentModel.ISupportInitialize)(this.benisInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.NumericUpDown benisInput;
        private System.Windows.Forms.CheckBox bannedInput;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Label versionlabel;
    }
}

