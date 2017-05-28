namespace notepad
{
    partial class shablon
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
            this.fio = new System.Windows.Forms.Panel();
            this.add = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fio
            // 
            this.fio.Dock = System.Windows.Forms.DockStyle.Top;
            this.fio.Location = new System.Drawing.Point(0, 0);
            this.fio.Name = "fio";
            this.fio.Size = new System.Drawing.Size(721, 184);
            this.fio.TabIndex = 0;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(620, 191);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(87, 37);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(12, 191);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(87, 37);
            this.close.TabIndex = 2;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            // 
            // shablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 240);
            this.Controls.Add(this.close);
            this.Controls.Add(this.add);
            this.Controls.Add(this.fio);
            this.Name = "shablon";
            this.Text = "Скоро день рождения!";
            this.Load += new System.EventHandler(this.shablon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fio;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button close;
    }
}