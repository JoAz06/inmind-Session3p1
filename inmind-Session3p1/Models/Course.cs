using System;
using System.Collections.Generic;

namespace inmind_Session3p1.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int TeacherId { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;

    public Course(int Id, string Name, int TeacherId)
    {
        this.Id = Id;
        this.Name = Name;
        this.TeacherId = TeacherId;
    }
}
