namespace notepad
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.add = new System.Windows.Forms.Button();
            this.notes = new System.Windows.Forms.Panel();
            this.grats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(466, 460);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(91, 38);
            this.add.TabIndex = 0;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // notes
            // 
            this.notes.AutoScroll = true;
            this.notes.Dock = System.Windows.Forms.DockStyle.Top;
            this.notes.Location = new System.Drawing.Point(0, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(569, 454);
            this.notes.TabIndex = 1;
            this.notes.Paint += new System.Windows.Forms.PaintEventHandler(this.notes_Paint);
            // 
            // grats
            // 
            this.grats.Location = new System.Drawing.Point(357, 460);
            this.grats.Name = "grats";
            this.grats.Size = new System.Drawing.Size(103, 38);
            this.grats.TabIndex = 2;
            this.grats.Text = "Поздравление";
            this.grats.UseVisualStyleBackColor = true;
            this.grats.Click += new System.EventHandler(this.grats_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(569, 510);
            this.Controls.Add(this.grats);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.add);
            this.Name = "Form1";
            this.Text = "Записная книжка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Panel notes;
        private System.Windows.Forms.Button grats;
    }
}

