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
    public partial class shablonList : Form
    {
        private sql note = new sql("bazadannih.db");
        public static bool refresh = false;

        public shablonList()
        {
            InitializeComponent();
        }

        private void shablonList_Load(object sender, EventArgs e)
        {
            int size = note.getCountShablon();
            shablons[] shablon = note.getShablon();

            createFormObject(size, shablon);
        }

        private void createFormObject(int size, shablons[] answer)
        {
            for (int i = 0; i < size; i++)
            {
                notes.Controls.Add(new GroupBox() { Name = "note" + i, Text = "Шаблон " + answer[i].id.ToString(), Location = new Point(10, i * 300 + 10), Size = new Size(350, 300) });

                Control[] temp = notes.Controls.Find("note" + i, true);

                string sex = "Мужской";
                if (answer[i].sex == 1)
                    sex = "Женский";
                else if (answer[i].sex == 2)
                    sex = "Универсальный";
                temp[0].Controls.Add(new Label() { Name = "sex" + i, Text = sex, Location = new Point(20, 22), Size = new Size(90, 20) });
                temp[0].Controls.Add(new TextBox() {BackColor = SystemColors.Control, ReadOnly = true,  Multiline = true, BorderStyle = BorderStyle.None, Name = "text" + i, Text = answer[i].text, Location = new Point(20, 50), Size = new Size(310, 200) });

                temp[0].Controls.Add(new Button() { Name = "editButton_" + answer[i].id, Text = "Изменить", Location = new Point(120, 20), Size = new Size(90, 20) });
                temp[0].Controls.Add(new Button() { Name = "deleteButton_" + answer[i].id, Text = "Удалить", Location = new Point(220, 20), Size = new Size(90, 20) });

                Control[] temp_l = temp[0].Controls.Find("editButton_" + answer[i].id, true);
                temp_l[0].Click += new EventHandler(edit_Click);
                temp_l = temp[0].Controls.Find("deleteButton_" + answer[i].id, true);
                temp_l[0].Click += new EventHandler(delete_Click);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            string[] splits = ((Button)sender).Name.Split('_');
            int id = Convert.ToInt32(splits[1]);

            string message = "Вы уверены что хотите удалить шаблон?";
            string caption = "Удаление шаблона";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                note.deleteShablon(id);

                refresh = true;
                refreshForm();
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            shablonEdit shablonEdit = new shablonEdit();
            string[] splits = ((Button)sender).Name.Split('_');
            int id = Convert.ToInt32(splits[1]);
            shablonEdit.id = id;
            shablonEdit.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            shablonEdit shablonEdit = new shablonEdit();
            shablonEdit.id = 0;
            shablonEdit.Show();
        }

        private void refreshForm()
        {
            if (refresh == true)
            {
                notes.Controls.Clear();

                int size = note.getCountShablon();
                shablons[] shablon = note.getShablon();

                createFormObject(size, shablon);

                refresh = false;
            }
        }

        private void shablonList_Activated(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
