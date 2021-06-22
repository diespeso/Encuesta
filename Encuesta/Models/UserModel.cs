using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class UserModel
    {
        [Browsable(false)]
        public int UserId { get; set; }
        
        [Browsable(false)]
        public int RoleId { get; set; }
        public string UserName { get; set; } 
        
        [Browsable(false)]
        public string Password { get; set; }
    }
}
