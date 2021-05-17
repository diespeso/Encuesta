using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public int AnswerGroupId { get; set; }
        public string Question { get; set; }
    }
}
