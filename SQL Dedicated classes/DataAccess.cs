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
    /// <summary>
    /// Обработка запросов в MySQL
    /// </summary>
    class DataAccess // Возможна SQL иньекция, нужно создать отдельную процедуру. Но я этого делать не буду из-за поверхностных знаний SQL
    {
        readonly string[] terms =
        {
            "id",
            "last_name",
            "first_name",
            "middle_name",
            "birth_date",
            "institute",
            "inst_group",
            "course",
            "average_score"
        };
        /// <summary>
        /// Поиск информации в базе данных
        /// </summary>
        /// <param name="search_text">Ключевое слово для поиска</param>
        /// <param name="search_type">Поле, по которому производится поиск</param>
        /// <returns>Возврат всех объектов класса Profiles, в которых найдено совпадение</returns>
        public List<Profile> SearchProfiles(string search_text, int search_type) // 'дай мне всю информацию из сервера и положи ее в список класса Profiles'
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.ConnectionString("UniversityDB")))
            {
                if(search_type == 4) // форматирование даты для SQL 01.02.1970 --> 1970-02-01
                {
                    string temp_text = "";
                    foreach (string i in search_text.Split('.').Reverse())
                    {
                        temp_text += i + "-";
                    }
                    temp_text = temp_text.Remove(temp_text.Length - 1);
                    search_text = temp_text;
                }
                return connection.Query<Profile>($"SELECT * FROM profiles WHERE { terms[search_type] } LIKE '%{ search_text }%'").ToList();
            }
        }
        /// <summary>
        /// Вывод всех профилей в определенной последовательности
        /// </summary>
        /// <param name="column">Категория для поиска</param>
        /// <param name="ascending">True если по возрастанию, False если по убыванию</param>
        /// <returns>Возврат полной отсортированной таблицы</returns>
        public List<Profile> ViewProfiles(int column, bool ascending)
        {
            string order = "DESC";
            if (ascending) { order = "ASC"; }
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.ConnectionString("UniversityDB")))
            {
                return connection.Query<Profile>($"SELECT * FROM profiles ORDER BY { terms[column] } { order }").ToList();
            }
        }
    }
}
