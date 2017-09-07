using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing.Models
{
    public class Test1
    {
        public int Id { get; set; }
        public int Age { get; set; }
        
       [Remote("IsValidName","Student",ErrorMessage ="Sorry,username already exist")]
        public string Name { get; set; }

    }


}