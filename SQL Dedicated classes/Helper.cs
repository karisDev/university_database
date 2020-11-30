using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
