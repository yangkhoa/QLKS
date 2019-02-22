using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private string _username;
        private string _password;
        private string _display_name;
        private string _code_position;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Display_name { get => _display_name; set => _display_name = value; }
        public string Code_position { get => _code_position; set => _code_position = value; }


        public Account(string user, string display, string code_pos, string pass = null)
        {
            this.Username = user;
            this.Password = pass;
            this.Display_name = display;
            this.Code_position = code_pos;
        }

        public Account(DataRow row)
        {
            this.Username = row["username"].ToString();
            this.Password = row["password"].ToString();
            this.Display_name = row["display_name"].ToString();
            this.Code_position = row["code_position"].ToString();
        }
    }
}
