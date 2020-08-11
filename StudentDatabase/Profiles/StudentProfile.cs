using AutoMapper;
using CourseLibrary.API.Helpers;
using StudentDatabase.Entities;
using StudentDatabase.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Profiles
{
    public class StudentProfile :Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName } {src.FirstName} {src.MiddleName}"))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                 .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes.ToString()))
                 .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.ToString()))
                 .ForMember(dest => dest.Age, opt => opt.MapFrom(src => $"{src.DateOfBirth.GetCurrentAge()}"));


            CreateMap<StudentCreation, Student>()
                .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(de => de.State, opt => opt.MapFrom(src => src.State))
                .ForMember(de => de.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(de => de.Classes, opt => opt.MapFrom(src => src.Classes));
        }
    }
}
