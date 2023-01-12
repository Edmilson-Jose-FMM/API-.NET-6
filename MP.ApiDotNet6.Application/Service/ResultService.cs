using MP.ApiDotNet6.Application.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Application.Service
{
    public class ResultService
    {
       public bool IsSuccess { get; set; }
       public string   Message { get; set;}
       public ICollection<ErrorValidation> Errors { get; set; }    
        public static ResultService RequestErrors(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x., Message = x.ErrorMessage }).toList();
            }
        }
    }
    public class ResultService<T> : ResultService
    {
        public T Data { get; set;  }
    }
}
