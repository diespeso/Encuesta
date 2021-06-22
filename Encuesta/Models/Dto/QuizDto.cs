using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models.Dto
{
    public class QuizDto
    {
        [Browsable(false)]
        public int QuizId { get; set; }
        public string Name { get; set; }
        public ObservableCollection<QuestionDto> Questions { get; set; }
    }
}
