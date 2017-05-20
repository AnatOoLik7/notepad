using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class formEdit : Form
    {

        private sql note = new sql("bazadannih.db");
        public int id = 0;

        public formEdit()
        {
            InitializeComponent();
        }

        private void formEdit_Load(object sender, EventArgs e)
        {
            notebooks ans = note.singleNote(id);
            firstname.Text = ans.firstname;
            secondname.Text = ans.secondname;
            lastname.Text = ans.lastname;
            sex.Integer = ans.sex;
            date.DataTime = ans.date;
            job.Text = ans.job;
            position.Text = ans.position;
            more.Text = ans.more;



         }
    }
}
