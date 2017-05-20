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
        private int sex = 0;

        public formEdit()
        {
            InitializeComponent();
        }

        private void formEdit_Load(object sender, EventArgs e)
        {
            this.Text = (id > 0) ? "Изменить" : "Добавить";
            edit.Text = (id > 0) ? "Изменить" : "Добавить";

            if (id > 0)
            {
                notebooks answer = note.getSingleNote(id);
                firstname.Text = answer.firstname;
                secondname.Text = answer.secondname;
                lastname.Text = answer.lastname;
                date.Value = answer.date;
                job.Text = answer.job;
                position.Text = answer.position;
                more.Text = answer.more;

                if (answer.sex == 0)
                    sex1.Checked = true;
                else
                    sex2.Checked = true;
            }
         }

        private void checkVal(object sender, EventArgs e)
        {
            sex = sex1.Checked ? 0 : 1;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            notebooks request;
            request.id = id;
            request.firstname = firstname.Text;
            request.secondname = secondname.Text;
            request.lastname = lastname.Text;
            request.sex = sex;
            request.date = date.Value;
            request.job = job.Text;
            request.position = position.Text;
            request.more = more.Text;

            if (id > 0)
                note.setSingleNote(request); // Изменить текущую запись
            else
                note.addSingleNote(request); // Добавить новую запись

            this.Close();
        }
    }
}
