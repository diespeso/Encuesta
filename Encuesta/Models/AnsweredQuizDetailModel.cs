using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class AnsweredQuizDetailModel
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int AnsweredQuizId { get; set; }
        public TimeSpan ElapsedSeconds { get; set; }
    }
}
