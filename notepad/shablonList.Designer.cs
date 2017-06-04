namespace notepad
{
    partial class shablonList
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
            this.notes = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notes
            // 
            this.notes.AutoScroll = true;
            this.notes.Dock = System.Windows.Forms.DockStyle.Top;
            this.notes.Location = new System.Drawing.Point(0, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(380, 458);
            this.notes.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(281, 464);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(87, 37);
            this.add.TabIndex = 4;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // shablonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 513);
            this.Controls.Add(this.add);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.notes);
            this.Name = "shablonList";
            this.Text = "Список шаблонов";
            this.Activated += new System.EventHandler(this.shablonList_Activated);
            this.Load += new System.EventHandler(this.shablonList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel notes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button add;
    }
}