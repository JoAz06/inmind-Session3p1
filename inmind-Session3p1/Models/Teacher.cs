using System;
using System.Collections.Generic;

namespace inmind_Session3p1.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
