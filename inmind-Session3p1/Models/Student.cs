using System;
using System.Collections.Generic;

namespace inmind_Session3p1.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Country { get; set; }
}
