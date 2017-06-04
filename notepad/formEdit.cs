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

            addresss addressRequest;
            addressRequest.id = 0;
            addressRequest.id_notebook = id;
            addressRequest.address = address.Text;
            addressRequest.city = city.Text;
            addressRequest.state = state.Text;
            addressRequest.country = country.Text;
            addressRequest.postal = postal.Text;

            phones[] phoneRequest = new phones[4];

            for (int i = 0; i < 4; i++)
            {
                Control[] temp = phone.Controls.Find("phone" + (i + 1), true);
                phoneRequest[i].id_notebook = id;
                phoneRequest[i].phone = temp[0].Text;
                temp = phone.Controls.Find("note" + (i + 1), true);
                phoneRequest[i].note = temp[0].Text;
            }


            if (id > 0)
            {
                note.setSingleNote(request); // Изменить текущую запись
                note.setSingleNote(addressRequest);
                note.setSingleNote(phoneRequest);
            }
            else
            {
                note.addSingleNote(request); // Добавить новую запись
                addressRequest.id_notebook = note.getLastId();
                for (int i = 0; i < 4; i++)
                    phoneRequest[i].id_notebook = addressRequest.id_notebook;

                note.addSingleNote(addressRequest);
                note.setSingleNote(phoneRequest);
            }

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
