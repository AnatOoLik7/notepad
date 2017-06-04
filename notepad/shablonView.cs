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
    public partial class shablonView : Form
    {
        private sql note = new sql("bazadannih.db");
        public int id = 0;

        public shablonView()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void shablonView_Load(object sender, EventArgs e)
        {
            rebuilds();
        }

        private void rebuild_Click(object sender, EventArgs e)
        {
            note.deleteLink(id);
            rebuilds();
        }

        private void rebuilds()
        {
            if (!note.existShablon(id))
            {
                int[] idShablon = note.getIdShablon(id);

                if (idShablon.Length > 0)
                {
                    Random rand = new Random();
                    note.addLink(id, idShablon[rand.Next(0, idShablon.Length - 1)]);
                }
            }

            string temp = note.getSinleShablon(id);

            notebooks answer = note.getSingleNote(id);

            temp = temp.Replace("%firstname%", answer.firstname);
            temp = temp.Replace("%secondname%", answer.secondname);
            temp = temp.Replace("%lastname%", answer.lastname);


            text.Text = temp;
        }
    }
}
