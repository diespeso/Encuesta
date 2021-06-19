using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Encuesta.Models.Dto
{
    public class QuestionDto
    {
        [Browsable(false)]
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}
