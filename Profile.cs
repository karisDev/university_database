using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_database
{
    /// <summary>
    /// Хранение и создание профилей из SQL
    /// </summary>
    public class Profile
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public DateTime birth_date { get; set; }
        public string institute { get; set; }
        public string inst_group { get; set; }
        public int course { get; set; }
        public int average_score { get; set; }
    }
}
