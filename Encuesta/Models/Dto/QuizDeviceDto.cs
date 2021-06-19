using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models.Dto
{
    public class QuizDeviceDto
    {
        [Browsable(false)]
        public int QuizDeviceId { get; set; }
        
        [Browsable(false)]
        public int QuizToApplyId { get; set; }
        public string QuizDeviceName { get; set; }
        public string QuizDeviceLocation { get; set; }
        public string QuizName { get; set; }
    }
}
