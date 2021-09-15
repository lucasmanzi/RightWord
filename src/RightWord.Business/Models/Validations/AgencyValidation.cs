using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models.Validations
{
    public class AgencyValidation : AbstractValidator<Agency>
    {
        public AgencyValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty();

            RuleFor(a => a.Name)
                .NotEmpty()
                .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);

            //RuleFor(a => a.Name)
            //    .NotEmpty()
            //    .Length(2, 200);
        }

    }
}
