﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models.Dto
{
    public class UserDto
    {
        public int usuarioId { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int rol { get; set;}
    }
}
