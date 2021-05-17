using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class AnswerModel
    {
        public int AnswerId { get; set; }
        public int AnswerGroupId { get; set; }
        public string Answer { get; set; }
    }
}
