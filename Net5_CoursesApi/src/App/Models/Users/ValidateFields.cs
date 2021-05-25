using System.Collections.Generic;

namespace Courses.Models.Users
{
    public class ValidateFields
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateFields(IEnumerable<string> errors)
        {
            Errors = errors;
        }        
                
    }
}