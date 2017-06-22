namespace notepad
{
    partial class shablonView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.close = new System.Windows.Forms.Button();
            this.rebuild = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(12, 226);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // rebuild
            // 
            this.rebuild.Location = new System.Drawing.Point(197, 226);
            this.rebuild.Name = "rebuild";
            this.rebuild.Size = new System.Drawing.Size(75, 23);
            this.rebuild.TabIndex = 1;
            this.rebuild.Text = "Заменить";
            this.rebuild.UseVisualStyleBackColor = true;
            this.rebuild.Click += new System.EventHandler(this.rebuild_Click);
            // 
            // text
            // 
            this.text.BackColor = System.Drawing.SystemColors.Control;
            this.text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text.Dock = System.Windows.Forms.DockStyle.Top;
            this.text.Location = new System.Drawing.Point(5, 5);
            this.text.Margin = new System.Windows.Forms.Padding(40);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.ReadOnly = true;
            this.text.Size = new System.Drawing.Size(274, 220);
            this.text.TabIndex = 2;
            // 
            // shablonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.text);
            this.Controls.Add(this.rebuild);
            this.Controls.Add(this.close);
            this.Name = "shablonView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Просмотр поздравления";
            this.Load += new System.EventHandler(this.shablonView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button rebuild;
        private System.Windows.Forms.TextBox text;
    }
}