using System.Collections.Generic;
using UserManager.Api.ViewModels;

namespace UserManager.Api.Utils
{
    public static class Responses
    {
        
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Internal server error please try again",
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Sucess = false,
                Data = errors
            };
        }
        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Username or password invalids",
                Sucess = false,
                Data = null
            };
        }


    }
}