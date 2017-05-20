using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;


namespace notepad
{
    public partial class Form1 : Form
    {
        public sql note = new sql("bazadannih.db");

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void add_Click(object sender, EventArgs e)
        {
            formAdd formAdd = new formAdd();
            formAdd.Show();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            formEdit formEdit = new formEdit();
            formEdit.id = 1;
            formEdit.Show();
        }
    }

}