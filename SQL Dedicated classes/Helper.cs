using System.Configuration;

namespace university_database
{
    /// <summary>
    /// Читает информацию из App.config, устанавливая связь с базой SQL
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Возвращает значение строки подключение по названию базы данных
        /// </summary>
        /// <param name="name">Название базы данных</param>
        /// <returns>Возврат строки подключения из App.config</returns>
        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
