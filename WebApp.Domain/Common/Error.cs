using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Common
{
    public class Error
    {                
        public string  Code { get; set; }

        public string Message { get; set; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public static class Errors
    {
        public static class General
        {
            static Error NotFound(Guid? id= null)
            {
                var forId = id == null ? "": $"for id {id}";
                return new ("record.not.found", $"Record not found {forId}");

            }

            public static Error ValueIsRequired(string? field = null)=>
                new Error("Value.is.required",$"Value is Required {field}");
            public static Error ValueIsInvalid(string? field = null) =>
                new Error("Value.is.invalid", $"Value is Invalid {field}");

            public static Error InvalidLength(string? name=null)
            {
                var label = name == null ? "" : $"for id {name}";
                return new ("invalid.length", $"Invalid {label} length");

            }

        }
        public static class Place
        {
            public static Error ValueIsRequired() =>
                new Error("Place.is.required", "Place is Required");


        }
    }
}
