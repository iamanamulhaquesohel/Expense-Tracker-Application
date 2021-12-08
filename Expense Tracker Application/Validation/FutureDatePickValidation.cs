using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_Application.Validation
{
    public class FutureDatePickValidation: ValidationAttribute
    {
        //Custom validation override to prevent future date pick
        public override bool IsValid(object value)
        {
            var date = DateTime.Parse(value.ToString());
            return date.Date <= DateTime.Now.Date;
        }
    }
}
