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
    public partial class formView : Form
    {
        private sql note = new sql("bazadannih.db");
        public int id = 0;
        private int sex = 0;

        public formView()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void formView_Load(object sender, EventArgs e)
        {
            notebooks answer = note.getSingleNote(id);
            firstname.Text = answer.firstname;
            secondname.Text = answer.secondname;
            lastname.Text = answer.lastname;
            date.Text = answer.date.ToString("dd.MM.yyyy");
            job.Text = answer.job;
            position.Text = answer.position;
            more.Text = answer.more;

            if (answer.sex == 0)
                sex1.Checked = true;
            else
                sex2.Checked = true;

            int size = note.getCountPhone(id);
            if (size > 0)
            {
                phones[] phoneAnswer = note.getSinglePhone(id);

                for (int i = 0; i < size; i++)
                {
                    Control[] temp = phone.Controls.Find("phone" + (i + 1), true);
                    temp[0].Text = phoneAnswer[i].phone;
                    temp = phone.Controls.Find("note" + (i + 1), true);
                    temp[0].Text = phoneAnswer[i].note;
                }
            }

            addresss addressAnswer = note.getSingleAddress(id);
            address.Text = addressAnswer.address;
            city.Text = addressAnswer.city;
            state.Text = addressAnswer.state;
            country.Text = addressAnswer.country;
            postal.Text = addressAnswer.postal;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
