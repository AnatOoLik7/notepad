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
    public partial class shablon : Form
    {

        private sql note = new sql("bazadannih.db");

        public shablon()
        {
            InitializeComponent();
        }

        private void shablon_Load(object sender, EventArgs e)
        {
            int size = note.getCountShablonDate();
            notebooks[] shablon = note.getShablonDate();
            createFormObject(size, shablon);
        }

        private void view_Click(object sender, EventArgs e)
        {
            shablonView shablonView = new shablonView();
            string[] splits = ((Button)sender).Name.Split('_');
            int id = Convert.ToInt32(splits[1]);
            shablonView.id = id;
            shablonView.Show();
        }

        private void createFormObject(int size, notebooks[] answer)
        {
            for (int i = 0; i < size; i++)
            {
                notes.Controls.Add(new Panel() { Name = "note" + i, Location = new Point(10, i * 25 + 10), Size = new Size(600, 25) });

                Control[] temp = notes.Controls.Find("note" + i, true);
                
                temp[0].Controls.Add(new Label() { Name = "lastname" + i, Text = answer[i].lastname, Location = new Point(0, 5), Size = new Size(120, 20) });
                temp[0].Controls.Add(new Label() { Name = "firstname" + i, Text = answer[i].firstname, Location = new Point(130, 5), Size = new Size(120, 20) });
                temp[0].Controls.Add(new Label() { Name = "secondname" + i, Text = answer[i].secondname, Location = new Point(260, 5), Size = new Size(120, 20) });
                temp[0].Controls.Add(new Label() { Name = "date" + i, Text = answer[i].date.ToString("dd.MM.yyyy"), Location = new Point(390, 5), Size = new Size(90, 20) });

                temp[0].Controls.Add(new Button() { Name = "viewButton_" + answer[i].id, Text = "Просмотр", Location = new Point(490, 0), Size = new Size(90, 20) });

                Control[] temp_l = temp[0].Controls.Find("viewButton_" + answer[i].id, true);
                temp_l[0].Click += new EventHandler(view_Click);
            }

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            
        }

        private void fio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            shablonList shablonList = new shablonList();
            shablonList.Show();
        }
    }
}
