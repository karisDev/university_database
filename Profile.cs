using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// класс через который будут создаваться профили из SQL
namespace university_database
{
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
        public string full_info
        {
            get
            {
                string temp_date = "";
                foreach(string i in birth_date.ToString().Split(' ')[0].Split('-').Reverse())
                {
                    temp_date += i;
                }
                return $"{ id } { last_name } { first_name } { middle_name } { temp_date } { institute } { inst_group } { course } { average_score }";
            }
        }
    }
}
