using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace notepad
{
    public struct notebooks
    {
        public int id;
        public string lastname;
        public string firstname;
        public string secondname;
        public int sex;
        public DateTime date;
        public string job;
        public string position;
        public string more;
    }

    public struct addresss
    {
        public int id;
        public int id_notebook;
        public string address;
        public string city;
        public string state;
        public string country;
        public string postal;
    }

    public struct phones
    {
        public int id;
        public int id_notebook;
        public string phone;
        public string note;
    }

    public struct shablons
    {
        public int id;
        public int sex;
        public int text;
    }



    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }



    public class sql
    // Работа с SQL
    {
        
        SQLiteFactory factory;
        static string BDName;

        public sql(string baseName)
        {
            // Подключение к базе данных baseName
            BDName = baseName;
            factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
        }

        ~sql()
        {

        }

        private SQLiteConnection openConnection()
        {
            //Открытие соединения с базой данных
            SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection();
            connection.ConnectionString = "Data Source = " + BDName;
            connection.Open();

            return connection;
        }

        private void closeConnection(ref SQLiteConnection connection)
        {
            //Закрытие соединия с базой данных
            connection.Close();
        }

        public notebooks getSingleNote(int id)
        {
            //Запрос одиночной анкеты
            notebooks request_note;
            request_note.id = id;
            request_note.firstname = "";
            request_note.lastname = "";
            request_note.secondname = "";
            request_note.sex = 0;
            request_note.date = Convert.ToDateTime("1900/1/1");
            request_note.job = "";
            request_note.position = "";
            request_note.more = "";


            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM notebook WHERE id =" + id + ";";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                request_note.firstname = reader["firstname"].ToString();
                request_note.lastname = reader["lastname"].ToString();
                request_note.secondname = reader["secondname"].ToString();
                request_note.sex = Convert.ToInt32(reader["sex"]);
                request_note.date = Convert.ToDateTime(reader["date"]);
                request_note.job = reader["job"].ToString();
                request_note.position = reader["position"].ToString();
                request_note.more = reader["more"].ToString();
            }
            reader.Close();

            closeConnection(ref connection);

            return request_note;
        }

        public void addSingleNote(notebooks post)
        {
            // Добавление записи в таблицу notebook
            SQLiteConnection connection = openConnection();

            string query = "INSERT INTO notebook (lastname, firstname, secondname, sex, date, job, position, more) VALUES ('" + post.lastname + "','" + post.firstname + "','" + post.secondname + "','" + post.sex + "','" + post.date.ToString("yyyy-MM-dd HH:mm:ss.sss") + "','" + post.job + "','" + post.position + "','" + post.more + "');";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);
        }

        public void setSingleNote(notebooks post)
        {
            // Изменение записи в таблицу notebook
            SQLiteConnection connection = openConnection();

            string query = "UPDATE notebook SET lastname = '"+ post.lastname +"', firstname = '"+ post.firstname +"', secondname = '"+ post.secondname +"', sex = '"+ post.sex +"', date = '"+ post.date.ToString("yyyy-MM-dd HH:mm:ss.sss") +"', job = '"+ post.job +"', position = '"+ post.position +"', more = '"+ post.more +"' WHERE id = '"+ post.id +"';";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);
        }

        public int getCountNote()
        {
            int count = 0;

            SQLiteConnection connection = openConnection();

            string query = "SELECT Count(id) FROM notebook;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                count = Convert.ToInt32(reader["Count(id)"]);
            }
            reader.Close();
            closeConnection(ref connection);

            return count;
        }

        public notebooks[] getMultiNote(int count)
        {
            //Запрос всех анкет
            notebooks[] request_note = new notebooks[count];

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM notebook;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            int i = 0;
            while(reader.Read())
            {
                request_note[i].id = Convert.ToInt32(reader["id"]);
                request_note[i].firstname = reader["firstname"].ToString();
                request_note[i].lastname = reader["lastname"].ToString();
                request_note[i].secondname = reader["secondname"].ToString();
                request_note[i].sex = Convert.ToInt32(reader["sex"]);
                request_note[i].date = Convert.ToDateTime(reader["date"]);
                request_note[i].job = reader["job"].ToString();
                request_note[i].position = reader["position"].ToString();
                request_note[i].more = reader["more"].ToString();
                i++;
            }
            reader.Close();

            closeConnection(ref connection);

            return request_note;
        }

    }
}