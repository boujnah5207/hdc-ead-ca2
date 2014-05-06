using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CA_Mini_Project_V4.Validation
{
    public sealed class RemoteUID_Attribute : ValidationAttribute
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string ParameterName { get; set; }
        public string RouteName { get; set; }

        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
