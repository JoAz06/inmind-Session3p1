using AutoMapper;
using inmind_Session3p1.Models;
using inmind_Session3p1.ViewModels;

namespace inmind_Session3p1.Mappers;


public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Course, CourseViewModel>().
            ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            .ForMember(c => c.TeacherId, opt => opt.MapFrom(c => c.TeacherId));
        CreateMap<Teacher, TeacherViewModel>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name));
        CreateMap<Enrollment, EnrollmentViewModel>().
            ForMember(c => c.CourseId, opt => opt.MapFrom(c => c.CourseId))
            .ForMember(c => c.StudentId, opt => opt.MapFrom(c => c.StudentId))
            .ForMember(c => c.EnrollmentDate, opt => opt.MapFrom(c => c.EnrollmentDate));
    }
}