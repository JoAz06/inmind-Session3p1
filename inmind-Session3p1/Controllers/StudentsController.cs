using inmind_Session3p1.Models;
using inmind_Session3p1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace inmind_Session3p1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    //Session3p1
    private readonly inmind_Session3p1.Models.Session3p2Context _context;
    private readonly IMapper _mapper;
    public StudentsController(inmind_Session3p1.Models.Session3p2Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
    [HttpPost("p2/Student")]
    public async Task<ActionResult> AddStudent([FromQuery] Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("p2/Student")]
    public ActionResult<List<Student>> GetStudents()
    {
        return _context.Students.ToList();
    }
    [HttpDelete("p2/Student")]
    public async Task<ActionResult> RemoveStudent([FromQuery] int StudentId)
    {
        _context.Students.Remove(_context.Students.Find(StudentId));
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("p2/Teacher")]
    public async Task<ActionResult> AddTeacher([FromQuery] Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("p2/Teacher")]
    public ActionResult<List<TeacherViewModel>> GetTeachers()
    {
        return _mapper.Map<List<TeacherViewModel>>(_context.Teachers.ToList());
    }
    [HttpDelete("p2/Teacher")]
    public async Task<ActionResult> RemoveTeacher([FromQuery] int TeacherId)
    {
        _context.Teachers.Remove(_context.Teachers.Find(TeacherId));
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("p2/Course")]
    public async Task<ActionResult> AddCourse([FromQuery] int Id, [FromQuery] string name, [FromQuery] int TeacherId)
    {
        _context.Courses.Add(new Course(Id,name,TeacherId));
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("p2/Course")]
    public ActionResult<List<CourseViewModel>> GetCourses()
    {
        return _mapper.Map<List<CourseViewModel>>(_context.Courses.ToList());
    }
    [HttpDelete("p2/Course")]
    public async Task<ActionResult> RemoveCourse([FromQuery] int CourseId)
    {
        _context.Courses.Remove(_context.Courses.Find(CourseId));
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("p2/Enrollment")]
    public async Task<ActionResult> AddEnrollment([FromQuery] int StudentId, [FromQuery] int CourseId, [FromQuery] DateOnly EnrollmentDate)
    {
        _context.Enrollments.Add(new Enrollment(StudentId, CourseId, EnrollmentDate));
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("p2/Enrollment")]
    public ActionResult<List<EnrollmentViewModel>> GetEnrollments()
    {
        return _mapper.Map<List<EnrollmentViewModel>>(_context.Enrollments.ToList());
    }
    [HttpDelete("p2/Enrollment")]
    public async Task<ActionResult> RemoveEnrollment([FromQuery] int StudentId, [FromQuery] int CourseId)
    {
        _context.Enrollments.Remove(_context.Enrollments.Find(StudentId,CourseId));
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}