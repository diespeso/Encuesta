using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using Encuesta.Models.Dto;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class UserServices
    {
        public bool Login(string username, string password)
        {
            return true;
        }

        //Procedimiento para guardar nuevo usuario
        public void Registro(int roleId,string userName, string contrasena)
        {
            private UserRepository _userRepository = new UserRepository(Program.GetConnectionString());
        }
    }


}
