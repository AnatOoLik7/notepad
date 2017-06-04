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
    public partial class shablonEdit : Form
    {
        private sql note = new sql("bazadannih.db");
        public int id = 0;
        private int sex = 2;

        public shablonEdit()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            shablons shablon;
            shablon.id = id;
            shablon.sex = sex;
            shablon.text = text.Text;

            if (id > 0)
            {
                note.setShablon(shablon);
            }
            else
            {
                note.addShablon(shablon);
            }

            shablonList.refresh = true;
            this.Close();
        }

        private void CheckVal1(object sender, EventArgs e)
        {
            sex = 0;
        }

        private void CheckVal2(object sender, EventArgs e)
        {
            sex = 1;
        }

        private void CheckVal3(object sender, EventArgs e)
        {
            sex = 2;
        }

        private void shablonEdit_Load(object sender, EventArgs e)
        {
            this.Text = (id > 0) ? "Изменить" : "Добавить";
            add.Text = (id > 0) ? "Изменить" : "Добавить";

            if (id > 0)
            {
                shablons answer = note.getSingleShablon(id);
                text.Text = answer.text;

                if (answer.sex == 0)
                    radioButton1.Checked = true;
                else if (answer. sex == 1)
                    radioButton2.Checked = true;
                else
                    radioButton3.Checked = true;
            }
        }
    }
}
