using System.Configuration;

namespace university_database
{
    public static class Helper
    {
        public static string CnnVal(string name) // Возвращает значение строки по названию элемента
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
