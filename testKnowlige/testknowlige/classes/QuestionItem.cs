using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestKnowlige.classes
{
    public class QuestionItem
    {
        public string Text { get; set; }
        public string Points { get; set; }
        public string TestID { get; set; }

        public QuestionItem():this("","","") { 
        }
        public QuestionItem(string text, string points):this(text, points, "") { 

        }
        public QuestionItem(string text, string points, string test_id) {
            Text = text;
            Points = points;
            TestID = test_id;
        }


    }
}