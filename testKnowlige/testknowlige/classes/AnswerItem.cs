using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestKnowlige.classes
{
    public class AnswerItem
    {
        public string Text { get; set; }
        public string Correct { get; set; }

        public AnswerItem():this("", "") { }
        public AnswerItem(string text, string correct) {
            Text = text;
            Correct = correct;
        }
    }
}