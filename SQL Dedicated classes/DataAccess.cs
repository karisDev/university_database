using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data;
// Подключение к серверу MySQL
namespace university_database
{
    class DataAccess // Возможна SQL иньекция, нужно создать отдельную процедуру. Но я этого делать не буду из-за поверхностных знаний SQL
    {
        public List<Profile> SearchProfiles(string search_text, int search_type) // 'дай мне всю информацию из сервера и положи ее в класс профилей'
        {
            // 0 - id, 1 - Last Name, 2 - Date Of Birth
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("UniversityDB")))
            {
                switch(search_type)
                {
                    case 0:
                        return connection.Query<Profile>($"SELECT * FROM profiles WHERE ID LIKE '%{ search_text }%'").ToList();
                    case 1:
                        return connection.Query<Profile>($"SELECT * FROM profiles WHERE last_name LIKE '%{ search_text }%'").ToList();
                    case 2:
                        //2002-06-22 <- 22.06.2002
                        string temp_text = "";
                        foreach(string i in search_text.Split('.').Reverse()) // 2002 06 22
                        {
                            temp_text += i + "-";
                        }// 2002-06-22-
                        temp_text.Remove(temp_text.Length - 1); // 2002-06-22

                        return connection.Query<Profile>($"SELECT * FROM profiles WHERE birth_date LIKE '%{ temp_text }%'").ToList();
                    default:
                        return new List<Profile>();
                }
            }
        }
        public List<Profile> ViewProfiles(int column, bool ascending)
        {
            string[] terms = { "ID", "last_name", "birth_date" };
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("UniversityDB")))
            {
                return connection.Query<Profile>($"SELECT * FROM profiles ORDER BY {terms[column]}").ToList();
            }
        }
    }
}
