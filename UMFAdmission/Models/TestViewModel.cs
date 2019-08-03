using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMFAdmission.Models
{
    public partial class TestViewModel
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public bool A { get; set; }
        public bool CheckA { get; set; }
        public bool B { get; set; }
        public bool CheckB { get; set; }
        public bool C { get; set; }
        public bool CheckC { get; set; }
        public bool D { get; set; }
        public bool CheckD { get; set; }
        public bool E { get; set; }
        public bool CheckE { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string AnswerE { get; set; }
    }
}