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
            this.components = new System.ComponentModel.Container();
            this.notes = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notes
            // 
            this.notes.AutoScroll = true;
            this.notes.Dock = System.Windows.Forms.DockStyle.Top;
            this.notes.Location = new System.Drawing.Point(0, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(627, 185);
            this.notes.TabIndex = 0;
            this.notes.Paint += new System.Windows.Forms.PaintEventHandler(this.fio_Paint);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(12, 191);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(87, 37);
            this.close.TabIndex = 2;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Шаблоны";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(627, 239);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.notes);
            this.Name = "shablon";
            this.Text = "Скоро день рождения!";
            this.Load += new System.EventHandler(this.shablon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel notes;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
    }
}