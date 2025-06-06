﻿using FluentValidation;
using INV.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Application.Validation
{
    public class UserDTOValidator : AbstractValidator<NormalUserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required!")
                .MinimumLength(5).WithMessage("Name require five characters")
                .MaximumLength(200).WithMessage("Name too long")
                .NotNull().WithMessage("Name cannot be null");
            RuleFor(p => p.Email)
                 .NotEmpty().WithMessage("Email is required!")
                .MinimumLength(20).WithMessage("Email require minimum twenty characters")
                .MaximumLength(200).WithMessage("Email too long")
                .NotNull().WithMessage("Email cannot be null")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email is not in correct format, check if has a @ sign");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(10).WithMessage("Password require minimum ten characters")
                .MaximumLength(200).WithMessage("Password too long");
        }
    }
}
