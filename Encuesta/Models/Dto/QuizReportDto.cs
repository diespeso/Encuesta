using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models.Dto
{
    public class QuizReportDto
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public int Quantity { get; set; }
    }
}
