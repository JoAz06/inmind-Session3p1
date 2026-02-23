using FluentValidation;
using StudentManagement.API.DTOs;

namespace StudentManagement.API.Validators;

public class CreateStudentValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentValidator() { 
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.FirstName).Length(2, 50).NotEmpty();
        RuleFor(x => x.LastName).Length(2, 50).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Now);
        RuleFor(x => x.PhoneNumber).Matches("^[0-9]{7,15}$");
        RuleFor(x => x.EnrollmentDate).LessThanOrEqualTo(DateTime.Now);
    }
}