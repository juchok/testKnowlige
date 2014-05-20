using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestKnowlige.classes
{
    public class testItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserId { get; set;}
        public string CategoriesID { get; set; }

        public testItem() { 
        }

        public testItem(string test_id, string name, string user_id, string cat_id)
        {
            ID = test_id;
            Name = name;
            UserId = user_id;
            CategoriesID = cat_id;
        }


    }
}