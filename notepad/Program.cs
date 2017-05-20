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

        public notebooks singleNote(int id)
        {
            //Запрос одиночной анкеты
            notebooks request;
            request.firstname = "";
            request.lastname = "";
            request.secondname = "";
            request.sex = "";
            request.date = "";
            request.job = "";
            request.position = "";
            request.more = "";


            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM notebook WHERE id ="+ id+";";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                request.firstname = reader["firstname"].ToString();
                request.lastname = reader["lastname"].ToString();
                request.secondname = reader["secondname"].ToString();
                request.sex = Convert.ToInt32(reader["sex"]);
                request.date = Convert.ToDateTime(reader["date"]);
                request.job = reader["job"].ToString();
                request.position = reader["position"].ToString();
                request.more = reader["more"].ToString();
            }

            closeConnection(ref connection);

            return request;
        }
    }
}