using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Testing
{
    public class TestAutherizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        private string[]  _role;
        public TestAutherizationAttribute(params string[] roles)
        {
            _role = roles ;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}