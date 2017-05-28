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

        public int getCountPhone(int id)
        {
            // Получение количества телефонов при записи
            int count = 0;
            SQLiteConnection connection = openConnection();

            string query = "SELECT Count(id) FROM phone WHERE id_notebook =" + id + " limit 4;";
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

        public int getCountAddress(int id)
        {
            // Получение количества телефонов при записи
            int count = 0;
            SQLiteConnection connection = openConnection();

            string query = "SELECT Count(id) FROM address WHERE id_notebook =" + id + ";";
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

        public phones[] getSinglePhone(int id)
        {
            // Получаем номера текущей записи


            phones[] request_phone = new phones[getCountPhone(id)]; ;

            request_phone[0].id = 0;
            request_phone[0].id_notebook = id;
            request_phone[0].phone = "";
            request_phone[0].note = "";

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM phone WHERE id_notebook =" + id + " limit 4;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                request_phone[i].id = Convert.ToInt32(reader["id"]);
                request_phone[i].phone = reader["phone"].ToString();
                request_phone[i].note = reader["note"].ToString();
                i++;
            }
            reader.Close();

            closeConnection(ref connection);

            return request_phone;
        }

        public int getCountShablon()
        {
            int count = 0;

            SQLiteConnection connection = openConnection();

            string query = "SELECT Count(id) FROM notebook WHERE date > (SELECT DATETIME('now', '-7 day'));";
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

        public notebooks[] getShablon()
        {

            notebooks[] request_note = new notebooks[getCountShablon()];

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM notebook WHERE  WHERE (SELECT DATETIME(date, '+1 day')) > (SELECT DATETIME('now', '-7 day')) ORDER BY lastname, firstname, secondname;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                request_note[i].id = Convert.ToInt32(reader["id"]);
                request_note[i].firstname = reader["firstname"].ToString();
                request_note[i].lastname = reader["lastname"].ToString();
                request_note[i].secondname = reader["secondname"].ToString();
                request_note[i].sex = Convert.ToInt32(reader["sex"]);
                request_note[i].date = Convert.ToDateTime(reader["date"]);
                i++;
            }
            reader.Close();

            closeConnection(ref connection);

            return request_note;
        }

        public void setShablon(int id_notebook, int id_shablon)
        {

        }

        public void deleteShablon(int id)
        {

        }

        public addresss getSingleAddress(int id)
        {
            // Получение адреса текущей записи
            addresss request_address;

            request_address.id = 0;
            request_address.id_notebook = id;
            request_address.address = "";
            request_address.city = "";
            request_address.state = "";
            request_address.country = "";
            request_address.postal = "";

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM address WHERE id_notebook =" + id + " limit 1;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                request_address.id = Convert.ToInt32(reader["id"]);
                request_address.address = reader["address"].ToString();
                request_address.city = reader["city"].ToString();
                request_address.state = reader["state"].ToString();
                request_address.country = reader["country"].ToString();
                request_address.postal = reader["postal"].ToString();

            }
            reader.Close();

            closeConnection(ref connection);

            return request_address;
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

        public void addSingleNote(addresss post)
        {
            SQLiteConnection connection = openConnection();

            string query = "INSERT INTO address (id_notebook, address, city, state, country, postal) VALUES ('" + post.id_notebook + "','" + post.address + "','" + post.city + "','" + post.state + "','" + post.country + "','" + post.postal + "');";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);
        }

        public int getLastId()
        {
            int id = 0;

            SQLiteConnection connection = openConnection();

            string query = "SELECT id FROM notebook ORDER BY id DESC LIMIT 1;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.Read())
            {
                id = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            closeConnection(ref connection);

            return id;
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

        public void setSingleNote(addresss post)
        {
            // Изменение записи в таблице address
            if (getCountAddress(post.id_notebook) > 0) { 
            SQLiteConnection connection = openConnection();
            
            string query = "UPDATE address SET address = '" + post.address + "', city = '" + post.city + "', state = '" + post.state + "', postal = '" + post.postal + "' WHERE id_notebook= '" + post.id_notebook + "';";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);

            } else
                addSingleNote(post);
        }

        public void setSingleNote(phones[] post)
        {

            deletePhone(post[0].id_notebook);

            SQLiteConnection connection = openConnection();

            string query = "INSERT INTO phone (id_notebook, phone, note) VALUES ";
            for (int i = 0; i < post.Length; i++)
            {
                query += "('" + post[i].id_notebook + "','" + post[i].phone + "','" + post[i].note + "'),";
            }

            query = query.Substring(0, query.Length - 1);
               

            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);

        }

        public void deletePhone(int id)
        {
            SQLiteConnection connection = openConnection();

            string query = "DELETE FROM phone WHERE id_notebook= '" + id + "';";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);
        }

        public void deleteAddress(int id)
        {
            SQLiteConnection connection = openConnection();

            string query = "DELETE FROM address WHERE id_notebook= '" + id + "';";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            Command.ExecuteNonQuery();

            closeConnection(ref connection);
        }

        public void deleteNote(int id)
        {
            SQLiteConnection connection = openConnection();

            string query = "DELETE FROM notebook WHERE id= '" + id + "';";
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

        public int getCountMultiPhone()
        {
            int count = 0;

            SQLiteConnection connection = openConnection();

            string query = "SELECT Count(id) FROM phone;";
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

        public phones[] getMultiPhone()
        {
            phones[] request_phone = new phones[getCountMultiPhone()];

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM phone ORDER BY id_notebook;";
            SQLiteCommand Command = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = Command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                request_phone[i].id = Convert.ToInt32(reader["id"]);
                request_phone[i].id_notebook = Convert.ToInt32(reader["id_notebook"]);
                request_phone[i].phone = reader["phone"].ToString();
                request_phone[i].note = reader["note"].ToString();
                i++;
            }
            reader.Close();

            closeConnection(ref connection);

            return request_phone;
        }

        public notebooks[] getMultiNote(int count)
        {
            //Запрос всех анкет
            notebooks[] request_note = new notebooks[count];

            SQLiteConnection connection = openConnection();

            string query = "SELECT * FROM notebook ORDER BY lastname, firstname, secondname;";
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