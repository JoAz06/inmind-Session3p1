using inmind_Session3p1.Models;
using Microsoft.AspNetCore.Mvc;

namespace inmind_Session3p1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    //Session3p1
    private readonly inmind_Session3p1.Models.Session3p2Context _context;
    public StudentsController(inmind_Session3p1.Models.Session3p2Context context)
    {
        _context = context;
    }
    
    [HttpGet("courseById")]
    public ActionResult<List<Student>> GetEnrolledIn([FromQuery] int course_id, [FromQuery] bool asc = true)
    {
        if(asc)
            return _context.Enrollments.Where(enroll => enroll.CourseId == course_id).OrderBy(enroll => enroll.EnrollmentDate).Select(stud => stud.Student).ToList();
        return _context.Enrollments.Where(enroll => enroll.CourseId == course_id).OrderByDescending(enroll => enroll.EnrollmentDate).Select(stud => stud.Student).ToList();
        //Order is getting scrambled after selecting students
    }

    [HttpGet("groupByYear")]
    public ActionResult<List<List<Student>>> GetStudentGroupedByYear()
    {
        return _context.Students.GroupBy(x => x.Dob.Value.Year).Select(group => group.ToList()).ToList();
    }
    
    [HttpGet("groupByYearCountry")]
    public ActionResult<List<List<Student>>> GetStudentGroupedByYearCountry()
    {
        return _context.Students.GroupBy(x => new {x.Dob.Value.Year , x.Country}).Select(group => group.ToList()).ToList();
    }
    
    [HttpGet("studentCount")]
    public ActionResult<int> GetStudentCount()
    {
        return _context.Students.Count();
    }
    
    [HttpGet("paginate")] //pages start from 1
    public ActionResult<List<Enrollment>> GetPaginated([FromQuery] int pageSize ,[FromQuery] int pageNumber)
    {
        return _context.Enrollments.Skip(pageSize*(pageNumber-1)).Take(pageSize).ToList();
    }
    // end Session3p1
    
    //Session3p2
    
    
}