using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models.Validations
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty();

            RuleFor(a => a.FirstName)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(a => a.SurName)
                .NotEmpty()
                .Length(2, 200);
        }
    }
}
