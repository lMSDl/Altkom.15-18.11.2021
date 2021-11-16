using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : Entity
    {
        [DisplayName("Login")]
        //[Required(ErrorMessage = "Field is requered")]
        //[MinLength(5, ErrorMessage = "Username minimal length is 5")]
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }


        public override string ToString()
        {
            return string.Join("; ", base.ToString(), $"{nameof(Username)}: {Username}", $"{nameof(Password)}: {Password}");
        }
    }
}
