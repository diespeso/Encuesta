using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Models;
using Encuesta.Models.Dto;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class UserServices
    {
        private UserRepository userRepository = new UserRepository(Program.GetConnectionString());
        private UserRoleRepository _userRoleRepository = new UserRoleRepository(Program.GetConnectionString());
        private static PermitRepository _userPermitRepository = new PermitRepository(Program.GetConnectionString());
        private static UserRoleHasPermitRepository _userPermitRolesRepository = new UserRoleHasPermitRepository(Program.GetConnectionString());
        public static UserModel LoggedUser = null;

        public bool Login(string username, string password)
        {
            try
            {
                LoggedUser = userRepository.GetByUserName(username);
                return SecurePasswordHasher.Verify(password, userRepository.GetByUserName(username).Password);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Procedimiento para guardar nuevo usuario
        public void Registro(UserDto dto)
        {
            try
            {
                UserModel modelo = new UserModel()
                {
                    UserId = dto.UserId,
                    UserName = dto.UserName,
                    Password = SecurePasswordHasher.Hash(dto.Password),
                    RoleId = dto.UserRoleId
                };

                if (dto.UserId == 0)
                    userRepository.Add(modelo);
                else
                    userRepository.Update(modelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en repositorio", ex);
            }
        }

        public List<KeyValuePair<int, string>> GetUserRoles()
        {
            return _userRoleRepository.GetAll().Select(x => new KeyValuePair<int, string>(x.UserRoleId, x.RoleName))
                .ToList();
        }

        public UserDto GetUser(int userId)
        {
            if (userId == 0)
                return new UserDto();
            
            UserModel model = userRepository.Get(userId);
            return new UserDto()
            {
                UserId = model.UserId,
                UserRoleId = model.RoleId,
                UserName = model.UserName,
                Password = model.Password
            };
        }

        public IEnumerable<UserModel> GetMainView()
        {
            return userRepository.GetAll();
        }

        public static bool ValidateAccess(string permitName)
        {
            bool hasPermit = false;

            PermitModel permit = _userPermitRepository.GetByName(permitName);
            try
            {
                hasPermit = _userPermitRolesRepository.Get(permit.PermitId, LoggedUser.RoleId).PermitAllowed;
            }
            catch (Exception ex)
            {
            }

            if (hasPermit == false)
            {
                MessageBox.Show("Permisos insuficientes");
            }

            return hasPermit;
        }

    }

}
