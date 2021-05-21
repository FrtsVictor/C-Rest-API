using System;
using System.Linq;
using Courses.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Courses.Filters
{
    public class CustomValidateModelState : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            validateModelState(context);
        }
        private void validateModelState(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var validateFields = new ValidateFields(context.ModelState.SelectMany( sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validateFields);
            }
        }
    }
}