using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMFAdmission.Models
{
    public class MultipleChoiceQuestionViewModel
    {
            public int QuestionID { get; set; }
            public string Question { get; set; }
            public bool A { get; set; }
            public bool B { get; set; }
            public bool C { get; set; }
            public bool D { get; set; }
            public bool E { get; set; }
        
    }
}