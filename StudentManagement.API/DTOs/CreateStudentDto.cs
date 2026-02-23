using System.ComponentModel.DataAnnotations;
using StudentManagement.API.Validators;

namespace StudentManagement.API.DTOs;

public class CreateStudentDto
{
    //id
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [PastDate]
    public DateTime DateOfBirth { get; set; }
    
    public string PhoneNumber { get; set; }
    [Required]
    public DateTime EnrollmentDate { get; set; }
}