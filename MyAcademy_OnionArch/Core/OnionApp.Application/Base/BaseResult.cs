using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnionApp.Application.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public List<Error>? Errors { get; set; }
        public bool IsSuccessful => Errors == null;


        public static BaseResult<T> Success(T data)
        {
            return new BaseResult<T>
            {
                Data = data,
                Errors = null
            };
        }

        public static BaseResult<T> Success()
        {
            return new BaseResult<T>
            {
                Errors = null
            };
        }

        public static BaseResult<T> Fail(List<ValidationFailure> validationErrors)
        {
            var errors = (from error in validationErrors
                          select new Error
                          {
                              ErrorMessage = error.ErrorMessage,
                              PropertyName = error.PropertyName
                          }).ToList();

            return new BaseResult<T>
            {
                Errors = errors
            };
        }

        public static BaseResult<T> Fail(string message)
        {
            return new BaseResult<T>
            {
                Errors = new List<Error>
                {
                    new Error{ErrorMessage = message, PropertyName = " "}
                }
            };
        }

    }

    public class Error
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
