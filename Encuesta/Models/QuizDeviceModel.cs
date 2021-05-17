using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Models
{
    public class QuizDeviceModel
    {
        public int QuizDeviceId { get; set; }
        public int QuizToApplyId { get; set; }
        public string QuizDeviceName { get; set; }
        public string QuizDeviceLocation { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
