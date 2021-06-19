using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class UserRoleHasPermitModel
    {
        public int UserRoleId { get; set; }
        public int PermitId { get; set; }
        public bool PermitAllowed { get; set; }
    }
}
