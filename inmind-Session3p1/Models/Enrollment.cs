using System;
using System.Collections.Generic;

namespace inmind_Session3p1.Models;

public partial class Enrollment
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public Course Course { get; set; } = null!;

    public Student Student { get; set; } = null!;

    public Enrollment(int StudentId, int CourseId, DateOnly? EnrollmentDate)
    {
        this.StudentId = StudentId;
        this.CourseId = CourseId;
        this.EnrollmentDate = EnrollmentDate;
    }
}
