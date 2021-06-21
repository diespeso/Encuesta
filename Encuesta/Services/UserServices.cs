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
        private UserRepository userRepository = new UserRepository(Program.GetConnectionString());
        public bool Login(string username, string password)
        {
            return true;
        }

        //Procedimiento para guardar nuevo usuario
        public void Registro(UserDto dto)
        {
            if (dto.usuarioId == 0)
            {
                try
                {
                    UserModel modelo = new UserModel()
                    {
                        UserId = dto.usuarioId,
                        UserName = dto.usuario,
                        Password = dto.contrasena,
                        RoleId = dto.rol
                    };
                    userRepository.Add(modelo);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en repositorio",ex);
                }
            }
        }
    
    }

}
