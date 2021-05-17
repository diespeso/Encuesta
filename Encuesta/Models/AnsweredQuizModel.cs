using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class AnsweredQuizModel
    {
        public int AnsweredQuizId { get; set; }
        public int QuizDeviceId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
